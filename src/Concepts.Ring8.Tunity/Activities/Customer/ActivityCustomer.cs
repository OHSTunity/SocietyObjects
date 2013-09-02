/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/TunityProjectEventInfo.cs#4 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring2;
using Concepts.Ring4;
using Concepts.Ring8.Tunity;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// A Customeractivity is a role for an activity.
    /// 
    /// (More or less connecting an activity with a customercompany and a customer reference)
    /// 
    /// </summary>
    public class CustomerActivity : Role
    {

        public CustomerActivity()
        {
        }

        [SynonymousTo("WhatIs")]
        public readonly TunityActivity Activity;

        public void SetActivity(TunityActivity activity)
        {
            SetWhatIs(activity);
        }

        private Company _company;

        public Company Company
        {
            get { return _company; }
            set { _company = value; }
        }

        private Person _reference;

        public Person Reference
        {
            get { return _reference; }
            set { _reference = value; }
        }
     }
}
