using System;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring2;

using System.Collections.Generic;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    ///
    /// </summary>
    public class  CustomerCompany : Role
    {
        

        [SynonymousTo("WhatIs")]
        public readonly Company Company;

        public void SetCompany(Company company)
        {
            SetWhatIs(company);
        }
    }
}