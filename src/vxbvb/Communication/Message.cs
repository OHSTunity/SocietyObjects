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
    public class Message : Event
    {
        public new class Kind : Event.Kind 
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public virtual Message.Kind AssureMessageKind(string name)
            {
                Message.Kind MessageKind = null;
                if (name != null)
                {
                    using (SqlEnumerator sqlEnumerator = Sql.GetEnumerator(
                        "SELECT result FROM Concepts.Ring2.Message.Kind result WHERE result.Name=variable(String, name)"))
                    {
                        sqlEnumerator.SetVariable("name", name);

                        while (sqlEnumerator.MoveNext())
                        {
                            MessageKind = sqlEnumerator.Current as Message.Kind;
                        }
                        if (MessageKind == null)
                        {
                            MessageKind = Kind.GetInstance<Message.Kind>().Derive() as Message.Kind;
                            MessageKind.Name = name;
                        } 
                    }
                }
                else
                {
                    throw new ArgumentNullException("Name cannot be null when assuring Concepts.Ring2.Message.Kind");
                }
                return MessageKind;
            }
        }

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
                return ParticipantRoles<MessageRecipient>();
            }
        }
    }
}
