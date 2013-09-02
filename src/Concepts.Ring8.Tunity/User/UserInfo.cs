/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/User/PersonInfo.cs#5 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using Starcounter;
using System;
using Concepts.Ring3.SystemX;

namespace Concepts.Ring8.Tunity
{
    public class TunityUser : SystemUser
    {
        private Boolean _hidden;
        private Boolean _active;
        private String _startSite;
        private String _comment;
        private String _emailSignature;

        protected override void OnNew()
        {
            base.OnNew();
            _active = true;
            _hidden = false;
            Organizer = false;
            Warehouse = false;
            DefaultProofEmailSetting = ProofEmail.AllNewComments;
        }


        //Following is ugly but a user can be either/both or none.
        //Only way to get indexed searches
        //Is it a organizer user
        public Boolean Organizer;
        //Is it a warehouse user
        public Boolean Warehouse;

        /// <summary>
        /// TODO: Summary for class:  Person
        /// </summary>
        public Boolean Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }

        public Boolean Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public String StartSite
        {
            get { return _startSite; }
            set { _startSite = value; }
        }

        //Comment on startsite
        public String Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public String EmailSignature
        {
            get { return _emailSignature; }
            set { _emailSignature = value; }
        }

        public ProofEmail DefaultProofEmailSetting;

        
        //***********************************
        // Portfolio
        //***********************************
        public TaskType PreferredTaskType;
        public TaskType PreferredDocumentTaskType;
        public TaskType PreferredTodoTaskType;

    }
}
