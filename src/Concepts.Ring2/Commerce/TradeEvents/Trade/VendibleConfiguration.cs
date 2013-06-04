/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeEvents/Trade/VendibleConfiguration.cs#11 $
      $DateTime: 2010/02/18 17:12:49 $
      $Change: 29486 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;


namespace Concepts.Ring2
{
    /// <summary>
    /// TODO: Summary for class:  VendibleConfiguration
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: VendibleConfiguration
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: VendibleConfiguration
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: VendibleConfiguration
    /// This is an example of how to use this class.
    /// </example>
    public class VendibleConfiguration : Something
    {
        #region Kind

        public new class Kind : Something.Kind
        {

            
            /// <summary>
            /// Assures that a VendibleConfiguration for a specific Vendible exists,
            /// the configuration only contains one Item pointing to the wanted Vendible
            /// and multiplier.
            /// </summary>
            /// <param name="name">Optional: Name of the VendibleConfiguration</param>
            /// <param name="vendible"></param>
            /// <param name="multiplier"></param>
            /// <returns></returns>
            public VendibleConfiguration Assure(string name, Vendible vendible, decimal multiplier)
            {
                VendibleConfiguration tc = null;
                IEnumerable<VendibleConfigurationItem> matchingItems = GetMatchingItems(vendible, multiplier);

                foreach (VendibleConfigurationItem item in matchingItems)
                {
                    VendibleConfiguration vendibleConfiguration = item.VendibleConfiguration;
                    
                    if (vendibleConfiguration.Name.Equals(name) && vendibleConfiguration.CountItems() == 1)
                    {
                        // Found a match, break!
                        tc = vendibleConfiguration;
                        break;
                    }
                }
                
                if (tc == null)
                {
                    tc = new VendibleConfiguration();
                    tc.Name = name;
                    tc.AddItem(vendible, multiplier);
                }
                
                return tc;
            }

            /// <summary>
            /// Assures a VendibleConfiguration for a specific artifact.
            /// </summary>
            /// <param name="name">Optional: Name of the configuration</param>
            /// <param name="specificArtifact"></param>
            /// <returns></returns>
            public VendibleConfiguration Assure(string name, Artifact specificArtifact)
            {
                VendibleConfiguration tc = null;
                
                using (SqlEnumerator sqlEnumerator = Sql.GetEnumerator(
                    "SELECT tci FROM " + VendibleConfigurationItem.Kind.GetInstance<VendibleConfigurationItem.Kind>().FullInstanceClassName + " item "
                    + "                JOIN " + VendibleConfiguration.Kind.GetInstance<VendibleConfiguration.Kind>().FullInstanceClassName + " conf ON item.VendibleConfiguration=conf "
                    + "WHERE item.SpecificArtifact=variable(" + Artifact.Kind.GetInstance<Artifact.Kind>().FullInstanceClassName + ", specificArtifact)"))
                {
                    sqlEnumerator.SetVariable("specificArtifact", specificArtifact);

                    while (sqlEnumerator.MoveNext())
                    {
                        VendibleConfigurationItem item = sqlEnumerator.Current as VendibleConfigurationItem;
                        VendibleConfiguration vendibleConfiguration = item.VendibleConfiguration;

                        if (vendibleConfiguration.Name.Equals(name) && vendibleConfiguration.CountItems() == 1)
                        {
                            // Found a match, break!
                            tc = vendibleConfiguration;
                            break;
                        }
                    } 
                }

                if (tc == null)
                {
                    tc = new VendibleConfiguration();
                    tc.Name = name;
                    tc.AddItem(specificArtifact);
                }

                return tc;
            }
            
            /// <summary>
            /// Finds a VendibleConfiguration which has an item for each row in the dictionary.
            /// </summary>
            /// <param name="name"></param>
            /// <param name="itemsDefinition"></param>
            /// <returns></returns>
            public VendibleConfiguration Assure(string name, Dictionary<Vendible, decimal> itemsDefinition)
            {
                VendibleConfiguration tc = null;
                Dictionary<VendibleConfiguration, List<VendibleConfigurationItem>> dict = new Dictionary<VendibleConfiguration, List<VendibleConfigurationItem>>();
                
                foreach (KeyValuePair<Vendible, decimal> pair in itemsDefinition)
                {
                    foreach (VendibleConfigurationItem item in GetMatchingItems(pair.Key, pair.Value))
                    {
                        // Build a dictionary per TC
                        VendibleConfiguration vendibleConfiguration = item.VendibleConfiguration;
                        
                        if (name == null || name.Equals(name))
                        {
                            List<VendibleConfigurationItem> list = null;
                            
                            // Passed the name filter
                            if (dict.ContainsKey(tc))
                            {
                                list = dict[tc];
                            }
                            else
                            {
                                list = new List<VendibleConfigurationItem>();
                                dict.Add(tc, list);
                            }
                            list.Add(item);
                        }
                    }
                }

                int count = itemsDefinition.Count;
                // Check the built dictionary for matches.
                foreach (KeyValuePair<VendibleConfiguration, List<VendibleConfigurationItem>> pair in dict)
                {
                    List<VendibleConfigurationItem> list = new List<VendibleConfigurationItem>(pair.Value);
                    List<KeyValuePair<Vendible, decimal>> matched = new List<KeyValuePair<Vendible, decimal>>();
                    
                    if (list.Count >= count)
                    {
                        // The list is long enough to match the itemsDefinition. Lets check
                        foreach (KeyValuePair<Vendible, decimal> valuePair in itemsDefinition)
                        {
                            foreach (VendibleConfigurationItem item in list)
                            {
                                if (item.Vendible.Equals(valuePair.Key as Something)
                                    && item.Multiplier.Equals(valuePair.Value))
                                {
                                    // Found a match
                                    list.Remove(item);
                                    matched.Add(valuePair);
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
                    tc = new VendibleConfiguration();
                    tc.Name = name;
                    tc.AddItems(itemsDefinition);
                }

                return tc;
            }

            private IEnumerable<VendibleConfigurationItem> GetMatchingItems(Vendible vendible, decimal multiplier)
            {
                using (SqlEnumerator<VendibleConfigurationItem> sqlEnumerator = Sql.GetEnumerator<VendibleConfigurationItem>(
                    "SELECT item FROM " + VendibleConfigurationItem.Kind.GetInstance<VendibleConfigurationItem.Kind>().FullInstanceClassName + " item "
                    + "WHERE item.Vendible=variable(" + Something.Kind.GetInstance<Something.Kind>().FullInstanceClassName + ", vendible) AND"
                    + "      item.Multiplier=variable(Decimal, multiplier)"))
                {
                    sqlEnumerator.SetVariable("vendible", vendible);
                    sqlEnumerator.SetVariable("multiplier", multiplier);

                    // By using yield return we make sure that the enumerator is disposed
                    foreach (var v in sqlEnumerator)
                    {
                        yield return v;
                    }
                }
            }
        }

        #endregion

        public IEnumerable<VendibleConfigurationItem> Items
        {
            get { return GetItems<VendibleConfigurationItem>(); }
        }
        public IEnumerable<T> GetItems<T>() where T : VendibleConfigurationItem
        {
            return IndexedQueryHelper.GetRelatesTo<T>(this, "VendibleConfiguration");
        }


        private VendibleConfigurationItem AddItem(Vendible vendible, decimal multiplier)
        {
            VendibleConfigurationItem item = new VendibleConfigurationItem();
            item.VendibleConfiguration = this;
            item.Vendible = vendible;
            item.Multiplier = multiplier;

            return item;
        }

        public int CountItems()
        {
            int i = 0;
            foreach (VendibleConfigurationItem item in GetItems<VendibleConfigurationItem>())
            {
                i++;
            }
            return i;
        }
        private VendibleConfigurationItem AddItem(Artifact artifact)
        {
            throw new NotImplementedException("How do we get the Vendible from an Artifact-instance?");
//            VendibleConfigurationItem item = AddItem(artifact.UnitKind, 1);
//            item.SpecificArtifact = artifact;
//            
//            return item;
        }

        private IEnumerable<VendibleConfigurationItem>  AddItems(Dictionary<Vendible, decimal> definition)
        {
            foreach (KeyValuePair<Vendible, decimal> pair in definition)
            {
                yield return AddItem(pair.Key, pair.Value);
            }
        }
    }
}
