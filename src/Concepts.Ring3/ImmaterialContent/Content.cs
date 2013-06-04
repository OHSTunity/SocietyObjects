#region Using directives

using System;
using System.Collections.Generic;
using Starcounter;

#endregion

namespace Concepts.Ring3
{
    /// <summary>
    /// An immaterial object that carries information. In order to exist, it needs at least one copy.
    /// This is the abstact and immaterial entity of a book, a movie or other type of information where the
    /// physical object is merely a way to communicate or store the content.
    /// </summary>
    public class Content : Concepts.Ring1.Something
    {
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
		public new class Kind : Concepts.Ring1.Something.Kind { }
		#endregion

        
        public IEnumerable<ContentAssetRole> Assets
        {
            get
            {
                return this.ImplicitRoles<ContentAssetRole>();
            }
        }

        public void AddAsset(ContentBearingObject asset)
        {
            ContentAssetRole role = new ContentAssetRole();
            role.SetContent(this);
            role.SetContentAsset(asset);
        }

        public void RemoveAsset(ContentBearingObject asset)
        {
            ContentAssetRole role = asset.RelationTo<ContentAssetRole>(this);
            if (role != null)
            {
                role.Delete();
            }
        }

        protected override void OnDelete()
        {
            IEnumerable<ContentAssetRole> assetRoles = this.ImplicitRoles<ContentAssetRole>();
            foreach (ContentAssetRole role in assetRoles)
            {
                role.Delete();
            }
            base.OnDelete();
        }

    }
}
