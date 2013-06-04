#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;
#endregion

namespace Concepts.Ring2
{
    public class SMSMessage : Message
    {
        public new class Kind : Message.Kind { }

        /// <summary>
        /// ReadOnly
        /// </summary>
        
        public TelephoneNumber SmsSender
        {
            get
            {
                TelephoneNumber address = null;
                Something sender = Sender;
                if (sender != null)
                {
                    MobilePhoneNumber phoneno = sender.Role<MobilePhoneNumber>();
                    if (phoneno != null && phoneno.Address != null)
                    {
                        address = phoneno.Address as TelephoneNumber;
                    }
                }
                return address;
            }
        }

        /// <summary>
        /// ReadOnly
        /// </summary>
        
        public TelephoneNumber[] SmsRecipients
        {
            get
            {
                List<TelephoneNumber> list = new List<TelephoneNumber>();
                foreach (MessageRecipient mr in base.Recipients)
                {
                    MobilePhoneNumber phoneno = mr.Participant.Role<MobilePhoneNumber>();
                    if (phoneno != null && phoneno.Address != null)
                    {
                        list.Add(phoneno.Address as TelephoneNumber);
                    }
                }
                return list.ToArray();
            }
        }
    }
}
