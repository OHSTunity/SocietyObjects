using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;
using SocietyObjects.ApplicationStartup;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// A group of ConfigurationParameterKinds, there is no reason to instanciate this class.
    /// Derive it into new Kinds!
    /// </summary>
    public class ConfigurationParameterGroup : Something
    {
        public new class Kind : Something.Kind, ITempPrototypeKind
        {


            public IEnumerable<ConfigurationParameter.Kind> Items
            {
                get { return GetItems<ConfigurationParameter.Kind>(); }
            }
            /// <summary>
            /// A collection of all the ConfigurationParameterKinds that belong to this group.
            /// </summary>
            public IEnumerable<T> GetItems<T>() where T : ConfigurationParameter.Kind
            {
                return IndexedQueryHelper.GetRelatesTo<T>(this, "_Group");
            }

            /// <summary>
            /// The parent of this group.
            /// </summary>
            public ConfigurationParameterGroup.Kind Parent;

            #region ITempPrototypeKind Members

            public virtual void TempPrototypeKindInit()
            {
            }

            #endregion
        }
    }
}