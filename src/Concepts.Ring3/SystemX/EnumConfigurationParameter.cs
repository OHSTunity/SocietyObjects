using System;
using Starcounter;

namespace Concepts.Ring3.SystemX
{
    public class EnumConfigurationParameter : ConfigurationParameter
    {
        public new class Kind : ConfigurationParameter.Kind
        {
            /// <summary>
            /// Returns a EnumConfigurationParameter for the given identifier and owner.
            /// </summary>
            /// <param name="owner"></param>
            /// <param name="usedByType"></param>
            /// <returns></returns>
            public EnumConfigurationParameter GetParameter(
                IConfigurationParameterOwner owner,
                Type usedByType)
            {
                return Get(ID, owner, usedByType) as EnumConfigurationParameter;
            }


            public override object DefaultValue
            {
                get
                {
                    if (EnumType != null)
                    {
                        Array values = Enum.GetValues(EnumType);
                        if (values != null && values.Length > 0)
                            return values.GetValue(0);
                    }
                    return 0;
                }
            }


            public virtual Type EnumType
            {
                get
                {
                    if (DataType == null)
                        return null;
                    Type type = Type.GetType(DataType);
                    if (type == null || type.IsEnum == false)
                        return null;
                    return type;
                }

                set
                {
                    if (value != null && value.IsEnum)
                        DataType = value.AssemblyQualifiedName;
                }
            }

            private string DataType;
        }


        public Type EnumType
        {
            get
            {
                Kind k = InstantiatedFrom as Kind;
                return k.EnumType;
            }
        }

        public Int64 EnumVal;


        public override object Value
        {
            get
            {
                return Enum.ToObject(EnumType, EnumVal);
            }
            set
            {
                // TODO, replace IsDefined, according to Blogs this is really slow.
                if (Enum.IsDefined(EnumType, value))
                {
                    String enumFieldValueAsString = (value as Enum).ToString("D");
                    EnumVal = Int64.Parse(enumFieldValueAsString);
                }
            }
        }
    }
}