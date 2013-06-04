using System.Collections;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;


namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// 
    /// </summary>
    public class Configuration : Something
    {
		

    	/// <summary>
        /// The configuration is recursive and reference it's parent configuration.
        /// </summary>
        public Configuration InheritsFrom;

        /// <summary>
        /// All configuration that inherits from this instance. Just one level below.
        /// </summary>
        
        public IEnumerable<Configuration> ChildConfigurations
        {
            get
            {
                /* todo
                SqlEnumerator<Configuration> e = Sql.GetEnumerator<Configuration>(
                    string.Format("SELECT c FROM {0} c WHERE c.InheritsFrom=VAR({0},InheritsFrom)",
                        FullClassName));
                e.SetVariable("InheritsFrom", this);

                foreach (var config in e)
                {
                    yield return config;
                }
                 * */
                return new List<Configuration>();
            }
        }

        /// <summary>
        /// Adds configs to a list and recursive adds all its children.
        /// </summary>
        /// <param name="parent">parent config</param>
        /// <param name="list">List of <c>Configuration</c></param>
        private void AddChilds(Configuration parent, ref List<Configuration> list)
        {
            list.Add(parent);
            foreach(Configuration childConfig in parent.ChildConfigurations)
            {
                AddChilds(childConfig, ref list);
            }
        }

        /// <summary>
        /// Finds all configs that implicit inherits from this config.
        /// </summary>
        
        public List<Configuration> AllChildConfiguration
        {
            get
            {
                List<Configuration> list = new List<Configuration>();
                foreach(Configuration config in ChildConfigurations)
                {
                    AddChilds(config, ref list);
                }
                return list;
            }
        }
    }
}
