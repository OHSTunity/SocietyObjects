// Provide examples on who uses this concept.
// Can it be put in a higher ring?

/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/System/Sequence.cs#1 $
      $DateTime: 2008/03/27 13:06:50 $
      $Change: 10885 $
      $Author: hentil $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;

namespace Concepts.Ring1
{
    public class Sequence : Something
    {

        public Sequence AddNextSequence()
        {
            Sequence seq = (Sequence)Activator.CreateInstance(this.GetType());
            //Not the last in this sequence
            if (Next != null)
            {
                Next.Previous = seq;
                seq.Next = Next;
            }

            this.Next = seq;
            seq.Previous = this;
            return seq;
        }

        public Sequence Next;

        public Sequence Previous;

        
        public Sequence FirstInSequence
        {
            get
            {
                Sequence previous = this;
                while (previous != null)
                {
                    if (previous.Previous == null)
                    {
                        break;
                    }
                    previous = previous.Previous;
                }
                return previous;
            }
        }

        
        public Sequence LastInSequence
        {
            get
            {
                Sequence next = this;
                while (next != null)
                {
                    if (next.Next == null)
                    {
                        break;
                    }
                    next = next.Next;
                }
                return next;
            }
        }
    }
}
