#region Using directives

using System;
using System.Collections.Generic;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring2;

#endregion

namespace Concepts.Ring3
{
    /// <ontology>
    /// <equal>sumo:ContentBearingObject</equal>
    /// <equal>wordnet:03493860</equal>
    /// </ontology>
    public abstract class ContentBearingObject : Role
    {
		
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HasContent()
        {
            return true; //TODO: this.Is<ContentAssetRole>();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnDelete()
        {
            /*TODO
            IEnumerable<ContentAssetRole> assetRoles = this.Roles<ContentAssetRole>();
            foreach (ContentAssetRole role in assetRoles)
            {
                role.Delete();
            }*/
            base.OnDelete();
        }

        /// <summary>
        /// Responible for puting information into a public arena.
        /// </summary>
        public Publisher Publisher;

        /// <summary>
        /// Revision of the content bearing object.
        /// </summary>
        public string Edition;

        /// <summary>
        /// Date of publishing.
        /// </summary>
        public DateTime PublicationDate;

        /// <summary>
        /// Language of the content bearing object.
        /// </summary>
        public Language Language;

        /// <summary>
        /// Example: To get the person or company holding a copyright to a book that you just sold in a bookstore you do the following:
        /// SalesItem receiptRow;
        /// Somebody copyrightOwner;
        /// copyrightOwner = receiptRow.Vendible.InstantiatedFrom.ContentBearingObject.Copyright.Owner;
        /// </summary>
        public Vendible Copyright;
    }
}
