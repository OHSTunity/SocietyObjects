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
        #region Kind
        public new class Kind : SomebodiesRelation.Kind
        {

            /// <summary>
            /// Assures an creator to its artifact kind.
            /// </summary>
            /// <param name="somebody">Somebody</param>
            /// <param name="artifactName">String</param>
            /// <returns>Creator</returns>
            public virtual Creator Assure(Somebody somebody, String artifactName)
            {
                Artifact.Kind artifactKind = null;

                if (artifactName != null)
                {
                    artifactKind = Kind.GetInstance <Artifact.Kind>().AssureKindByName<Artifact.Kind>(artifactName);
                }
                return Assure(somebody, artifactKind);
            }


            /// <summary>
            /// Assures an creator to its artifact kind.
            /// </summary>
            /// <param name="somebody">Somebody</param>
            /// <param name="artifactKind">Artifact.Kind</param>
            /// <returns>Creator</returns>
            public virtual Creator Assure(Somebody somebody, Artifact.Kind artifactKind)
            {
                return Kind.GetInstance<Creator.Kind>().Relate<Creator>(somebody, artifactKind);
            }

            /// <summary>
            /// Creators of a Artifact.Kind
            /// </summary>
            /// <param name="artifactKind"></param>
            /// <returns></returns>
            public IEnumerable<Creator> GetCreators(Artifact.Kind artifactKind)
            {
                return artifactKind.ImplicitRoles<Creator>(this);
            }
        }
        #endregion

        [SynonymousTo("ToWhat")]
        public readonly Artifact.Kind ArtifactKind;
        public void SetArtifactKind(Artifact.Kind artifactKind)
        {
            SetToWhat(artifactKind);
        }

    }
}
