/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeEvents/Trade/TradesideConfiguration.cs#31 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;

using System.Text;

namespace Concepts.Ring2
{
    /// <summary>
    /// TODO: Summary for class:  TradesideConfiguration
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: TradesideConfiguration
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: TradesideConfiguration
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: TradesideConfiguration
    /// This is an example of how to use this class.
    /// </example>
    public class TradesideConfiguration : Something
    {
        #region Kind

        public new class Kind : Something.Kind
        {
            /// <summary>
            /// Assures that a TradesideConfiguration for a specific Kind exists,
            /// the configuration only contains one Item pointing to the wanted Kind
            /// and multiplier.
            /// </summary>
            /// <param name="tradedKind"></param>
            /// <param name="multiplier"></param>
            /// <returns></returns>
            public TradesideConfiguration Assure(Something.Kind tradedKind, decimal multiplier)
            {
                TradesideConfiguration tc = null;
                IEnumerable<TradesideConfigurationItem> matchingItems = GetMatchingItems(tradedKind, multiplier);

                foreach (TradesideConfigurationItem item in matchingItems)
                {
                    TradesideConfiguration configuration = item.TradesideConfiguration;

                    if (configuration.CountItems() == 1)
                    {
                        // Found a match, break!
                        tc = configuration;
                        break;
                    }
                }

                if (tc == null)
                {
                    tc = new TradesideConfiguration();
                    tc.TradedKind = tradedKind;
                    tc.AddItem(multiplier);
                }

                return tc;
            }


            /// <summary>
            /// Finds a TradesideConfiguration which has an item for each row in the dictionary.
            /// </summary>
            /// <param name="name"></param>
            /// <param name="tradedKind"></param>
            /// <returns></returns>
            public TradesideConfiguration Assure(string name, Something.Kind tradedKind, ICollection<decimal> itemsDefinition)
            {
                TradesideConfiguration tc = null;
                Dictionary<TradesideConfiguration, List<TradesideConfigurationItem>> dict = new Dictionary<TradesideConfiguration, List<TradesideConfigurationItem>>();

                foreach (decimal multiplier in itemsDefinition)
                {
                    foreach (TradesideConfigurationItem item in GetMatchingItems(tradedKind, multiplier))
                    {
                        // Build a dictionary per TC
                        TradesideConfiguration configuration = item.TradesideConfiguration;

                        if (name == null || name.Equals(name))
                        {
                            List<TradesideConfigurationItem> list = null;

                            // Passed the name filter
                            if (dict.ContainsKey(tc))
                            {
                                list = dict[tc];
                            }
                            else
                            {
                                list = new List<TradesideConfigurationItem>();
                                dict.Add(tc, list);
                            }
                            list.Add(item);
                        }
                    }
                }

                int count = itemsDefinition.Count;
                // Check the built dictionary for matches.
                foreach (KeyValuePair<TradesideConfiguration, List<TradesideConfigurationItem>> pair in dict)
                {
                    List<TradesideConfigurationItem> list = new List<TradesideConfigurationItem>(pair.Value);
                    List<decimal> matched = new List<decimal>();

                    if (list.Count >= count)
                    {
                        // The list is long enough to match the itemsDefinition. Lets check
                        foreach (decimal multiplier in itemsDefinition)
                        {
                            foreach (TradesideConfigurationItem item in list)
                            {
                                if (item.Multiplier.Equals(multiplier))
                                {
                                    // Found a match
                                    list.Remove(item);
                                    matched.Add(multiplier);
                                    break;
                                }
                            }
                        }

                        if (matched.Count.Equals(itemsDefinition.Count))
                        {
                            // We got a match! No more matching is needed
                            tc = pair.Key;
                            break;
                        }
                    }
                }

                if (tc == null)
                {
                    // No match, create a new configuration
                    tc = new TradesideConfiguration();
                    tc.Name = name;
                    tc.TradedKind = tradedKind;
                    tc.AddItems(itemsDefinition);
                }

                return tc;
            }

            private IEnumerable<TradesideConfigurationItem> GetMatchingItems(Something.Kind tradedKind, decimal multiplier)
            {
                foreach (TradesideConfiguration side in IndexedQueryHelper.GetRelatesTo<TradesideConfiguration>(tradedKind, "TradedKind"))
                {
                    foreach (TradesideConfigurationItem item in IndexedQueryHelper.GetRelatesTo<TradesideConfigurationItem>(side, "TradesideConfiguration"))
                    {
                        if (item.Multiplier == multiplier)
                        {
                            yield return item;
                        }
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// The traded Kind that this configuration regards.
        /// </summary>
        public Something.Kind TradedKind;

        public IEnumerable<TradesideConfigurationItem> Items
        {
            get { return GetItems<TradesideConfigurationItem>(); }
        }
        public IEnumerable<T> GetItems<T>() where T : TradesideConfigurationItem
        {
            return IndexedQueryHelper.GetRelatesTo<T>(this, "TradesideConfiguration");
        }

        /// <summary>
        /// Returns the total multiplier of all the items.
        /// </summary>

        public virtual decimal TotalMultiplier
        {
            get
            {
                // Returns the total quantity of the connected items.
                decimal tq = 0;

                foreach (TradesideConfigurationItem item in GetItems< TradesideConfigurationItem>())
                {
                    tq += item.Multiplier;
                }

                return tq;
            }
        }


        private TradesideConfigurationItem AddItem(decimal multiplier)
        {
            TradesideConfigurationItem item = new TradesideConfigurationItem();
            item.TradesideConfiguration = this;
            item.Multiplier = multiplier;

            return item;
        }

        private TradesideConfigurationItem AddItem(Something instance)
        {
            TradesideConfigurationItem item = AddItem(1);
            item.SpecificInstance = instance;
            return item;
        }

        private ICollection<TradesideConfigurationItem> AddItems(ICollection<decimal> definition)
        {
            List<TradesideConfigurationItem> items = new List<TradesideConfigurationItem>();

            foreach (decimal multiplier in definition)
            {
                items.Add(AddItem(multiplier));
            }

            return items;
        }

        public int CountItems()
        {
            int i = 0;
            foreach (TradesideConfigurationItem item in GetItems<TradesideConfigurationItem>())
            {
                i++;
            }
            return i;
        }


        public virtual string ToTradeDebugXML()
        {
            return ToTradeDebugXML(0);
        }

        public virtual string ToTradeDebugXML(int indent)
        {
            string rootIndent = (indent > 0) ? " ".PadRight(indent) : string.Empty;
            string indentStr = " ".PadRight(indent + 1);
            StringBuilder sb = new StringBuilder();

            if (indent == 0)
            {
                sb.AppendLine("<?xml version=\"1.0\"?>");
            }

            sb.Append(rootIndent).Append("<TradesideConfiguration Type=\"").Append(ToReadableString()).AppendLine("\">");
            sb.Append(indentStr).Append("<TradedKind>").Append(TradedKind.ToReadableString()).AppendLine("</TradedKind>");
            sb.Append(indentStr).Append("<TotalMultiplier>").Append(TotalMultiplier.ToString()).AppendLine("</TotalMultiplier>");
            sb.Append(indentStr).AppendLine("<Items>");

            foreach (TradesideConfigurationItem item in GetItems<TradesideConfigurationItem>())
            {
                sb.AppendLine(item.ToTradeDebugXML(indent + 1));
            }
            sb.Append(indentStr).AppendLine("</Items>");
            sb.Append(rootIndent).AppendLine("</TradesideConfiguration>");

            return sb.ToString();
        }
    }
}
