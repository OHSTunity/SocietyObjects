using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocietyObjects.ApplicationStartup;
using Starcounter;
using Concepts.Ring3.SystemX;
using Kind = Concepts.Ring1.Something.Kind;
using System.IO;
using System.Timers;

namespace Concepts.Ring3.Plugins
{
    public class ConfigurationParameterHistory : IPrioritizedApplicationStartupPlugin
    {
        private static readonly HistoryRepository _history = new HistoryRepository();
        public const int DumpInterval = 1000 * 30; // 30 seconds
        public static bool IsExecuted { get; private set; }
        public const string HistoryFile = @"Configuration\History.dat";

        #region IPrioritizedApplicationStartupPlugin Members

        public int Priority
        {
            get { return int.MaxValue - 1; }
        }

        #endregion

        #region IApplicationStartupPlugin Members

        public IApplicationStartupPlugin[] Dependencies
        {
            get { return null; }
        }

        public void Execute(Starcounter.HostContext hostContext, StartupLog startupLog)
        {
            // Build a history log of the used configuration parameters
            if (!IsExecuted)
            {
                // Setting the history file will also load it.
                _history.File = new FileInfo(Path.Combine(
                    hostContext.OutputDirectory,
                    HistoryFile));
            }
        }

        #endregion

        internal static void Log(ConfigurationParameter configurationParameter, Type type)
        {
            _history.Log(configurationParameter, type);
        }

        internal static Dictionary<String, DateTime> GetUsage(ConfigurationParameter cp)
        {
            return _history.GetUsage(cp);
        }

        private class HistoryRepository
        {
            private readonly Dictionary<string, HistoryItem> _history =
                new Dictionary<string, HistoryItem>();
            private FileInfo _file;
            private Timer _dumpTimer;
            private bool _isModified;
            private bool _isDumping;

            internal HistoryRepository()
            {
                _dumpTimer = new Timer(DumpInterval);
                _dumpTimer.Enabled = true;
                _dumpTimer.Elapsed += new ElapsedEventHandler(OnDumpTimer);
            }

            void OnDumpTimer(object sender, ElapsedEventArgs e)
            {
                DumpLog();
            }

            ~HistoryRepository()
            {
                DumpLog();
                _dumpTimer.Dispose();
            }

            private void DumpLog()
            {
                if (!_isDumping && _isModified)
                {
                    _isDumping = true;
                    try
                    {
                        List<HistoryItem> items = new List<HistoryItem>(_history.Values);
                        _isModified = false;
                        _file.Directory.Create();

                        using (var stream = _file.Open(FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            using (StreamWriter writer = new StreamWriter(stream))
                            {
                                foreach (var item in items)
                                {
                                    writer.WriteLine(item.ToString());
                                }
                            }
                        }
                    }
                    catch
                    {
                        // A exception shall not stop the server
                    }
                    _isDumping = false;
                }
            }

            internal FileInfo File
            {
                get { return _file; }
                set
                {
                    if (_file != null)
                    {
                        throw new ApplicationException("The history file cant be changed!");
                    }
                    _file = value;

                    if (value != null)
                    {
                        InitHistory();
                    }
                }
            }

            private void InitHistory()
            {
                if (_file.Exists)
                {
                    try
                    {
                        // Read existing history
                        using (var stream = _file.OpenRead())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                string line;

                                while ((line = reader.ReadLine()) != null)
                                {
                                    var item = HistoryItem.Parse(line);
                                    _history[item.ParameterName] = item;
                                }
                            }
                        }
                    }
                    catch
                    {
                        // The history isnt vital and should not stop the server from starting
                    }
                }
            }

            internal Dictionary<String, DateTime> GetUsage(ConfigurationParameter cp)
            {
                Dictionary<string, DateTime> usage = new Dictionary<string, DateTime>();
                HistoryItem item;
                string key = cp.GetType().FullName;

                if (_history.TryGetValue(key, out item))
                {
                    foreach (var pair in item.TimeByUser)
                    {
                        usage[pair.Key] = new DateTime(pair.Value);
                    }
                }

                return usage;
            }

            internal void Log(ConfigurationParameter configurationParameter, Type type)
            {
                try
                {
                    HistoryItem item;
                    string key = configurationParameter.GetType().FullName;

                    if (!_history.TryGetValue(key, out item))
                    {
                        _history[key] = item = new HistoryItem(key);
                        item.AddUser(type);
                    }
                    _isModified = true;
                }
                catch
                {
                    // A exception shall not stop the server
                }
            }

            /// <summary>
            /// A log that was loaded from the database
            /// </summary>
            /// <param name="cp"></param>
            /// <param name="?"></param>
            internal void LoadedLog(ConfigurationParameter cp, Dictionary<string, DateTime> usersDic)
            {
                try
                {
                    HistoryItem item;
                    string key = cp.GetType().FullName;

                    if (!_history.TryGetValue(key, out item))
                    {
                        _history[key] = item = new HistoryItem(key);
                    }

                    foreach (var pair in usersDic)
                    {
                        item.AddUser(pair.Key, pair.Value);
                    }
                }
                catch
                {
                    // A exception shall not stop the server
                }
            }

            private class HistoryItem
            {
                private readonly Dictionary<string, long> _users =
                    new Dictionary<string, long>();

                internal static HistoryItem Parse(string line)
                {
                    // Get the type
                    string[] parts = line.Split('=');
                    string cp = parts[0];
                    string[] users = parts[1].Split('|');

                    HistoryItem item = new HistoryItem(cp);

                    foreach (var usingInfo in users)
                    {
                        string[] usingParts = usingInfo.Split(':');
                        string user = usingParts[0];
                        long when = 0;
                        long.TryParse(usingParts[1], out when);
                        item.AddUser(user, new DateTime(when));
                    }

                    return item;
                }

                internal HistoryItem(string cp)
                {
                    ParameterName = cp;
                }

                internal readonly string ParameterName;

                internal void AddUser(Type user)
                {
                    AddUser(user.FullName, DateTime.Now);
                }

                internal void AddUser(string user, DateTime when)
                {
                    _users[user] = when.Ticks;
                }

                internal Dictionary<string, long> TimeByUser
                {
                    get
                    {
                        return new Dictionary<string, long>(_users);
                    }
                }

                public sealed override string ToString()
                {
                    List<string> users = new List<string>();

                    foreach (var pair in _users)
                    {
                        users.Add(pair.Key + ":" + pair.Value);
                    }

                    return ParameterName + "=" + string.Join("|", users.ToArray());
                }
            }
        }
    }
}
