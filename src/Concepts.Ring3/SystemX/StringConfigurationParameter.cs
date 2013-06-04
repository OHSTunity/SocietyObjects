using System;
using Starcounter;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// Configures a parameter that consists of a single string.
    /// </summary>
    public class StringConfigurationParameter : ConfigurationParameter
    {
        public new class Kind : ConfigurationParameter.Kind
        {
            /// <summary>
            /// Returns a StringConfigurationParameter for the given identifier and owner.
            /// </summary>
            /// <param name="owner"></param>
            /// <param name="usedByType"></param>
            /// <returns></returns>
            public StringConfigurationParameter GetParameter(
                IConfigurationParameterOwner owner,
                Type usedByType)
            {
                return Get(ID, owner, usedByType) as StringConfigurationParameter;
            }
            
            
            public override object DefaultValue
            {
                get
                {
                    return StringDefaultValue;
                }
            }

            public string StringDefaultValue;
        }

        
        public override object Value
        {
            get
            {
                return StrValue;
            }

            set
            {
                StrValue = value as string;
            }
        }

        public string StrValue;
    }
}