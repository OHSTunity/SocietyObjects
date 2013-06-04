/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Participant/ParticipatingKind.cs#1 $
      $DateTime: 2008/03/27 13:06:50 $
      $Change: 10885 $
      $Author: hentil $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
namespace Concepts.Ring2
{
    /// <summary>
    /// TODO: Summary for class:  ParticipatingKind
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: ParticipatingKind
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: ParticipatingKind
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: ParticipatingKind
    /// This is an example of how to use this class.
    /// </example>
    public class ParticipatingKind : ParticipatingThing
    {
        public new class Kind : ParticipatingThing.Kind { }

        [SynonymousTo("WhatIs")]
        public readonly Something.Kind ParticipantKind;
        public void SetParticipantKind(Something.Kind kind)
        {
            SetWhatIs(kind);
        }
    }
}
