/*
 * Mark:                        Society Objects Mark II
 * Concept approval:            Meeting #?
 * Implementation approval:     pending
 * Introduced by:               Unknown
 * 
 * Not approved. Several issues found.
 * 
 * Status:  Should be moved to Ring3 (Biometrics)
 *          We should point to a specific finger. Null would indicate that the finger is unknown.
 *          Other mammals have fingerprints. Human should be mammal.
 *          Rename EncodedFingerprint with FingerprintChecksum?
 *          Put in biometrics subfolder
 *          Should inherit Ring2.Identifier.
 **/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;

namespace Concepts.Ring1
{
    /// <summary>
    /// A representation of a fingerprint. The fingerprint is a two dimensional identifier used to identify
    /// a human or another mammal biometrically.
    /// </summary>
    public class Fingerprint : Identifier
    {
        /// <summary>
        /// The Kind class is a fundamental concept in Society Objects. 
        /// Read more about it in the basic introduction to Society Objects.
        /// </summary>
        public new class Kind : Identifier.Kind { }

        /// <summary>
        /// The human carrying the fingerprint.
        /// </summary>
        /// TODO: Review joawes
        //public Mammal Mammal;
        
        /// <summary>
        /// A checksum that is fairly unique to this fingerprint. The fingerprint cannot be
        /// recreated from this checksum. Although highly unlikely, there can theoretically be
        /// more than one fingerprint with the same checksum.
        /// </summary>
        public static UInt64 FingerprintChecksum;

    }
}
