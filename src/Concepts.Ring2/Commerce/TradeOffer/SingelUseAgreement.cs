/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/SingelUseAgreement.cs#5 $
      $DateTime: 2008/01/07 10:54:39 $
      $Change: 8713 $
      $Author: hentil $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using System.Collections;

namespace Concepts.Ring2
{
    /// <summary>
    /// A singel use agreement is used for CompensationProvision instances that
    /// only is valid for one time use. E.g. manual agreements that are made
    /// outside of regular price lists, extra discount that is added during the
    /// sale that is outside of regular discount agreements.
    /// </summary>
    public class SingelUseAgreement : AgreedCompensation
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="AgreedCompensation.Kind"/>
        public new class Kind : AgreedCompensation.Kind
        {

        }
        #endregion

    }
}
