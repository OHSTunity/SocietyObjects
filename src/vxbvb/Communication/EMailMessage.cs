#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
#endregion

namespace Concepts.Ring2
{
    public class EMailMessage : Message
    {
        public new class Kind : Message.Kind { }

        [SynonymousTo("Text")]
        public String Body;

        public String Subject;

        /// <summary>
        /// ReadOnly
        /// </summary>
        
        public EMailAddress[] To
        {
            get
            {
                List<EMailAddress> list = new List<EMailAddress>();
                foreach (MessageRecipient mr in Recipients)
                {
                    EMailRelation er = mr.Participant.Role<EMailRelation>();
                    if (er != null)
                    {
                        list.Add(er.Address as EMailAddress);
                    }
                }
                return list.ToArray();
            }
        }

        /// <summary>
        /// ReadOnly
        /// </summary>
        
        public EMailAddress From
        {
            get
            {
                EMailAddress address = null;
                Something sender = Sender;
                if (sender != null)
                {
                    EMailRelation eRole = sender.Role<EMailRelation>();
                    if (eRole != null && eRole.Address != null)
                    {
                        address = eRole.Address as EMailAddress;
                    }
                }

                return address;
            }
        }

        //public ICollection<EMailAddress> Bcc;

        //public ICollection<EMailAddress> CC;
    }
}
