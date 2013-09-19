using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;

namespace Concepts.Ring8.Tunity
{
    public class MySyncData:Something
    {
        public String EMail; //Email that recieved link if user is External (Person = null)
        public Person Person;

        public DateTime Created;
        public Person CreatedBy;

        public String Message;

        public IEnumerable<Document> Documents()
        {
            return ImplicitlyRelatedObjects<Document, MySyncDocument>();
        }

        public void AddDocument(Document doc)
        {
            MySyncDocument msd = new MySyncDocument();
            msd.SetDocument(doc);
            msd.SetMySyncData(this);
        }
        
        protected override void OnDelete()
        {
            base.OnDelete();
            foreach (MySyncDocument relation in ImplicitRoles<MySyncDocument>())
            {
                relation.Delete();
            }
        }
    }

    public class MySyncDocument : Relation
    {
     
        /// <summary>
        /// The object addressed by the Production
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly MySyncData MySyncData;
        public void SetMySyncData(MySyncData mySyncData)
        {
            SetToWhat(mySyncData);
        }



        /// <summary>
        /// The Production that belongs to a owner
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Document Document;
        public void SetDocument(Document document)
        {
            SetWhatIs(document);
        }
    }
}
