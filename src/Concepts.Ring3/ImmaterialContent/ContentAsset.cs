#region Using directives

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;

#endregion

namespace Concepts.Ring3
{
    /// <summary>
    /// A content assets relation to a content. For instance, an audio file (content asset) may play the part of directors comments (ContentAssetRole) to a movie (Content).
    /// </summary>
    public class ContentAssetRole : Relation
    {
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
        public new class Kind : Relation.Kind { }
		#endregion
		
		/// <summary>
        /// The content asset that is part of the content.
        /// </summary>
        /// <see cref="ContentAssetRole"/>
        [SynonymousTo("WhatIs")]
        public readonly ContentBearingObject ContentAsset;
        public void SetContentAsset(ContentBearingObject contentAsset)
        {
            SetWhatIs(contentAsset);
        }

        /// <summary>
        /// The content for which this asset plays a role.
        /// </summary>
        /// <remarks>
        /// For instance, an audio file (content asset) may play the part of directors comments (ContentAssetRole) to a movie (Content).
        /// </remarks>
        [SynonymousTo("ToWhat")]
        public readonly Content Content;
        public void SetContent(Content content)
        {
            SetToWhat(content);
        }

    }
}
