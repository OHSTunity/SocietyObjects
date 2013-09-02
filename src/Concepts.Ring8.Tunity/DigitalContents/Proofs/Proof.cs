/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/DigitalContents/Document.cs#7 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;
using Concepts.Ring4;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    public class Proof : Something
    {
    
        public Proof()
        {
        }

        public Proof(Something target)
        {
            Target = target;
        }

        public ProofType Type;

        public ProofStatus Status;

        public DateTime ProofDate;
        
        public Person Creator;

        public Boolean Locked;


        [SynonymousTo("Name")]
        public String ProofHQFileID;

        [SynonymousTo("Description")]
        public String ProofHQVersion;


        public IEnumerable<Reviewer> Reviewers
        {
            get
            {
                return Db.SQL<Reviewer>("SELECT a FROM Reviewer a WHERE a.Proof=?", this);
            }
        }

        /// <summary>
        /// The target of the proof, can be a document/version for example.
        /// </summary>
        public Something Target;

        public T GetTarget<T>() where T : Something
        {
            return Target as T;
        }



    }

    public enum ProofType
    {
        PREPAREPDF = 0,
        PROOFHQ = 1
    }
}