using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Class that stores one access right setting
    /// (name->value)
    /// </summary>
    public class StoredRight : Something
    {
        private Boolean _value;

        public Boolean Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public AccessRightGroup Owner;
    }
}

