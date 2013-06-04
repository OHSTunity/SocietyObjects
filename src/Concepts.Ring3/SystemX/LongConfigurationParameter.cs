using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring3.SystemX
{
    public class LongConfigurationParameter : ConfigurationParameter
    {
        public new class Kind : ConfigurationParameter.Kind
        {
            /// <summary>
            /// Returns a LongConfigurationParameter for the given identifier and owner.
            /// </summary>
            /// <param name="owner"></param>
            /// <param name="usedByType"></param>
            /// <returns></returns>
            public LongConfigurationParameter GetParameter(
                IConfigurationParameterOwner owner,
                Type usedByType)
            {
                return Get(ID, owner, usedByType) as LongConfigurationParameter;
            }
            
            
            public override object DefaultValue
            {
                get
                {
                    return LongDefaultValue;
                }
            }

            public long LongDefaultValue;

            /// <summary>
            /// Returns the min allowed value
            /// </summary>
            public long MinValue;

            /// <summary>
            /// Returns the max allowed value
            /// </summary>
            public long MaxValue;
        }

        public long LongValue;

        
        public override object Value
        {
            get
            {
                return LongValue;
            }
            set
            {
                LongValue = (long)value;
            }
        }
    }
}