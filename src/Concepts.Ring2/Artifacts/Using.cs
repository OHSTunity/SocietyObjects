#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;

#endregion

namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    public class Using : Relation
    {
        /// <summary>
        /// 
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Artifact User;
        public void SetUser(Artifact user)
        {
            SetWhatIs(user);
        }

        /// <summary>
        /// 
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Artifact IsUsing;
        public void SetIsUsing(Artifact isUsing)
        {
            SetToWhat(isUsing);
        }
    }
}
