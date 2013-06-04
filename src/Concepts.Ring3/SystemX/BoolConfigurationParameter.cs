using System;
using Starcounter;

namespace Concepts.Ring3.SystemX
{

    public class BoolConfigurationParameter : ConfigurationParameter
    {
        public new class Kind : ConfigurationParameter.Kind
        {
            /// <summary>
            /// Returns a BoolConfigurationParameter for the given identifier and owner.
            /// </summary>
            /// <param name="owner"></param>
            /// <param name="usedByType"></param>
            /// <returns></returns>
            public BoolConfigurationParameter GetParameter(
                IConfigurationParameterOwner owner,
                Type usedByType)
            {
                return Get(ID, owner, usedByType) as BoolConfigurationParameter;
            }
            
            
            public override object DefaultValue
            {
                get
                {
                    return BoolDefaultValue;
                }
            }

            public bool BoolDefaultValue;
        }

        public bool BoolValue;

        
        public override object Value
        {
            get
            {
                return BoolValue;
            }
            set
            {
                BoolValue = (bool)value;
            }
        }
    }
}