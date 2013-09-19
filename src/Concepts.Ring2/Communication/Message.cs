#region Using directives
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Starcounter;
using Concepts.Ring1;

#endregion

namespace Concepts.Ring2
{
    [Database]
    public class Message : Event
    {
       
        /// <summary>
        /// 
        /// </summary>
        public Boolean IsSent;

        /// <summary>
        /// 
        /// </summary>
        public String Text;

        /// <summary>
        /// 
        /// </summary>
        public Something Sender;

        /// <summary>
        /// ReadOnly
        /// </summary>
        
        public IEnumerable<MessageRecipient> Recipients
        {
            get
            {
                /*TODO
                return ParticipantRoles<MessageRecipient>();
                 */
                return null;
            }
        }
    }
}
