/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Plugins/ConfigurationParameterControler.cs#15 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/


using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;
using Starcounter;
using Kind = Concepts.Ring1.Something.Kind;

using SocietyObjects.ApplicationStartup;

namespace Concepts.Ring3.Plugins
{
    /// <summary>
    /// Assures that all IDs are unique for ConfigurationParameter.Kinds
    /// </summary>
    public class ConfigurationParameterControler : IApplicationStartupPlugin
    {
        #region IApplicationStartupPlugin Members

        public IApplicationStartupPlugin[] Dependencies
        {
            get { return new IApplicationStartupPlugin[] { new SingletonStartupPlugin() } ; }
        }

        public void Execute(HostContext hostContext, StartupLog startupLog)
        {
            Transaction t = Transaction.NewCurrent();
            try
            {
                Dictionary<Int64, ConfigurationParameter.Kind> existingIDs =
                new Dictionary<Int64, ConfigurationParameter.Kind>();
                String query = string.Format(
                    "SELECT cpk FROM {0} cpk ",
                    Kind.GetInstance<ConfigurationParameter.Kind>().FullClassName);
                
                // Assure that each plugin has a Unique ID.
                using (SqlEnumerator sqlEnumerator = Sql.GetEnumerator(query))
                {
                    if (sqlEnumerator.MoveNext())
                    {
                        ConfigurationParameter.Kind cpk = sqlEnumerator.Current as ConfigurationParameter.Kind;
                        Int64 id = cpk.ID;

                        if (existingIDs.ContainsKey(id))
                        {
                            ConfigurationParameter.Kind addedKind = existingIDs[id];
                            throw new ApplicationException(
                                string.Format("{0} and {1} uses the same ID: {3}, this is not allowed!",
                                              cpk.FullClassName, addedKind.FullClassName, id));
                        }
                        else
                        {
                            existingIDs.Add(id, cpk);
                        }
                    } 
                }
                existingIDs.Clear();
            }
            catch (System.Exception e)
            {
                throw new ApplicationException("Failed to assure SQL-statements!", e);
            }
            finally
            {
                t.Dispose();
            }
        }

        #endregion
    }
}
