/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/ComplexOffer.cs#4 $
      $DateTime: 2007/09/29 21:55:05 $
      $Change: 5848 $
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
    public class ComplexOffer : TradeOffer
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="TradeOffer.Kind"/>
        public new class Kind : TradeOffer.Kind
        {
        }
        #endregion
    }
}
