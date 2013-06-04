using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    public abstract class PostalAddressRelation : AddressRelation
    {
        public new class Kind : AddressRelation.Kind 
        {
            public override string ToSelectorString()
            {
                String KindClassName = FullClassName;

                if (!String.IsNullOrEmpty(Name))
                {
                    return Name;
                }

                /// If we use the kinclassname as selector string we can leave out the
                /// word "Addresss"
                KindClassName = KindClassName.Substring(0, KindClassName.LastIndexOf("."));
                KindClassName = KindClassName.Substring(KindClassName.LastIndexOf(".") + 1);
                KindClassName = KindClassName.Replace("Address", "");
                return KindClassName;
            }
        }
    }
}
