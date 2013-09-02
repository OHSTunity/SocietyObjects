using System;
using Starcounter;
using Concepts.Ring1;
using System.Collections.Generic;
using Concepts.Ring8.Tunity;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductionOrderRowDetail : Something
    {
        public ProductionOrderRowDetail()
        {
           
        }

       
        //From something, Name, Description and Quantity is used)
        
        /// <summary>
        /// The order row that owns this details.
        /// </summary>
        public ProductionOrderRow OrderRow;

        
        /// <summary>
        /// Content of Detail.
        /// </summary>
        private string _ContentData;
        public string ContentData
        {
            get { return _ContentData; }
            set { _ContentData = value; }
        }


        /// <summary>
        /// Title of property.
        /// </summary>
        private string _ContentTitle;
        public string ContentTitle
        {
            get { return _ContentTitle; }
            set { _ContentTitle = value; }
        }

        /// <summary>
        /// Key of property.
        /// </summary>
        private string _ContentKey;
        public string ContentKey
        {
            get { return _ContentKey; }
            set { _ContentKey = value; }
        }

       
        
        /// <summary>
        /// Type/result of property
        /// </summary>
        private DetailType _Type;
        public DetailType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// Specific description of detail. 
        /// </summary>
        [SynonymousTo("Description")]
        public String DetailDescription;
        
        
    }

    public enum DetailType
    {
        /// <summary>
        /// A String 
        /// </summary>
        Text = 0,
        /// <summary>
        /// Numeric 
        /// </summary>
        Numeric = 1,
        /// <summary>
        /// An Image
        /// </summary>
        Image = 2,
        /// <summary>
        /// A Boolean
        /// </summary>
        YesNo = 3
    }

}
