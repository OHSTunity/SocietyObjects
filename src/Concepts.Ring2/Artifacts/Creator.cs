/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Artifacts/Creator.cs#10 $
      $DateTime: 2008/01/25 14:07:26 $
      $Change: 9326 $
      $Author: ollgus $
      =========================================================
*/

using System;
using Concepts.Ring1;
using Concepts.Ring2;
using Starcounter;
using System.Collections;
using System.Collections.Generic;

namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    public class Creator : SomebodiesRelation
    {
     
        [SynonymousTo("ToWhat")]
        public readonly Artifact Artifact;
        public void SetArtifact(Artifact artifact)
        {
            SetToWhat(artifact);
        }

    }
}
