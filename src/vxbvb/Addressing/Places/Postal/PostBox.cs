using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    /// <ontlogy>
    /// <equal>wordnet:X</equal>
    /// <equal>sumo:X</equal>
    /// </ontlogy>
    public class PostBox : PostalAddress
    {
        #region Kind
        /// <summary>
        /// Specific Box
        /// </summary>
        /// <seealso cref="SpatialAddress.Kind"/>
        public new class Kind : PostalAddress.Kind 
        {
            
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        [SynonymousTo("Name")]
        public string BoxID;

        /// <summary>
        /// 
        /// </summary>
        public override string MultiLineAddress
        {
            get
            {
                Address next = PartOf;
                String cityName = String.Empty,
                postCodeName = String.Empty;

                while (next != null)
                {
                    if (next is City)
                    {
                        cityName = next.Name;
                    }
                    else if (next is Postcode)
                    {
                        postCodeName = next.Name;
                    }
                    next = next.PartOf;
                }
                return BoxID + "\r\n" + postCodeName + " " + cityName;
            }
            set
            {
                base.MultiLineAddress = value;
            }
        }
    }
}
