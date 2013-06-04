using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring3.SystemX
{

    public class DecimalConfigurationParameter : ConfigurationParameter
    {
        public new class Kind : ConfigurationParameter.Kind
        {
            /// <summary>
            /// Returns a DecimalConfigurationParameter for the given identifier and owner.
            /// </summary>
            /// <param name="owner"></param>
            /// <param name="usedByType"></param>
            /// <returns></returns>
            public DecimalConfigurationParameter GetParameter(
                IConfigurationParameterOwner owner,
                Type usedByType)
            {
                return Get(ID, owner, usedByType) as DecimalConfigurationParameter;
            }
            
            
            public override object DefaultValue
            {
                get
                {
                    return DecimalDefaultValue;
                }
            }

            /// <summary>
            /// Returns the default decimal value
            /// </summary>
            public decimal DecimalDefaultValue;


            /// <summary>
            /// Returns the min allowed value
            /// </summary>
            public decimal MinValue;

            /// <summary>
            /// Returns the max allowed value
            /// </summary>
            public decimal MaxValue;
        }

        /// <summary>
        /// The value stored in the database, this value is also the target of the Value property.
        /// </summary>
        public decimal DecimalValue;

        
        public override object Value
        {
            get
            {
                return DecimalValue;
            }
            set
            {
                DecimalValue = (Decimal) value;
            }
        }
    }
}