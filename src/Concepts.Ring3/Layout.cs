using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring3
{   
    /// <summary>
    /// <remarks>
    /// A layout is the placement of art and text in 
    /// relation to eachother on a media.
    /// </remarks>
    /// There is a relation between the layout and its
    /// media. 
    /// 
    /// <example>
    /// A set of graphical objects are together
    /// the layout of a media.
    /// </example>
    /// </summary>
    public class Layout : Relation
    {
        #region Kind
        
        public new class Kind : Relation.Kind { }
        
        #endregion

        [SynonymousTo("WhatIs")]
        public readonly Something TheLayout;
        public void SetTheLayout(Something theLayout)
        {
            SetWhatIs(theLayout);
        }

        [SynonymousTo("ToWhat")]
        public readonly Something Media;
        public void SetMedia(Something media)
        {
            SetToWhat(media);
        }


    }
}
