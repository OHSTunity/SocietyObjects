/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/ConfigurationParameter.cs#29 $
      $DateTime: 2011/01/21 07:37:56 $
      $Change: 40501 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring1.SystemX;
using Starcounter;



namespace Concepts.Ring3
{
    /// <summary>
    /// Instances of this class represents single things that can be
    /// configured. For instance "VAT rates", "SMTP Server", 
    /// "COM port for receipt printer", etc...
    /// </summary>
    public class ConfigurationParameter : Something
    {

         

        protected override void OnDelete()
        {
            // Disconnect
            _belongsTo = null;

        }

        /// <summary>
        /// The ID of this configuration paramater.
        /// </summary>
        public Int64 ID
        {
            get;
            set;
        }

        [SynonymousTo("_belongsTo")]
        public readonly Something BelongsTo;

        private Something _belongsTo;

        /// <summary>
        /// This property should be set on all instances. There can be
        /// multiple instances of a same parameter kind, For instance a
        /// default COM Port Baud rate belonging to the whole chain,
        /// and another one that is overridden for a given computer.
        /// 
        /// Needs to be of type Persistent since the possible owners in
        /// SocietyObjects might be ComputerSystem(Something : Persistent) or
        /// SystemUserExtension(Extension : Persistent)
        /// </summary>
        public void SetOwner(IConfigurationParameterOwner owner)
        {
            _belongsTo = (Something)owner;
        }

        
        public virtual object Value
        {
            get { return null; }
            set { }
        }

        protected override void OnNew()
        {
        }

        public override T Clone<T>()
        {
            return null;
        }

        
      
        /// <summary>
        /// Returns a dictionary contaning the full name of the type using this 
        /// parameter and the timestamp when it was last read for that type. 
        /// </summary>
        
        public Dictionary<String, DateTime> UsedBy
        {
            get
            {
                return null; //TODO: ConfigurationParameterHistory.GetUsage(this);
            }
        }

        /// <summary>
        /// All using types are registred in a history string.
        /// </summary>
        /// <param name="type"></param>
        public void AssureUsingType(Type type)
        {
            //TODO:ConfigurationParameterHistory.Log(this, type);
        }
    }
}
