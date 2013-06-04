/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/ICompensationProvisionFactory.cs#5 $
      $DateTime: 2009/12/21 12:32:06 $
      $Change: 28341 $
      $Author: hentil $
      =========================================================
*/

using System;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// Interface for creating new CompensationProvision instances.
    /// </summary>
    public interface ICompensationProvisionFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wantedType"></param>
        /// <param name="includedIn"></param>
        /// <param name="consumer"></param>
        /// <param name="persistentObject"></param>
        /// <param name="amount"></param>
        /// <param name="quantity"></param>
        /// <param name="currencyKind"></param>
        /// <param name="validFrom"></param>
        /// <param name="validTo"></param>
        /// <returns></returns>
        CompensationProvision NewCharge(
            CompensationProvision.Kind wantedType,
            AgreedCompensation includedIn, 
            Something persistentObject,
            Decimal amount,
            Decimal quantity,
            Currency.Kind currencyKind,
            DateTime validFrom,
            DateTime validTo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wantedType"></param>
        /// <param name="includedIn"></param>
        /// <param name="persistentObject"></param>
        /// <param name="percent"></param>
        /// <param name="quantity"></param>
        /// <param name="validFrom"></param>
        /// <param name="validTo"></param>
        /// <returns></returns>
        CompensationProvision NewRelativeDeduction(
            CompensationProvision.Kind wantedType,
            AgreedCompensation includedIn,
            Something persistentObject,
            Decimal percent,
            Decimal quantity,
            DateTime validFrom,
            DateTime validTo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wantedType"></param>
        /// <param name="includedIn"></param>
        /// <param name="persistentObject"></param>
        /// <param name="percent"></param>
        /// <param name="quantity"></param>
        /// <param name="validFrom"></param>
        /// <param name="validTo"></param>
        /// <returns></returns>
        CompensationProvision NewRelativeCharge(
            CompensationProvision.Kind wantedType,
            AgreedCompensation includedIn,
            Something persistentObject,
            Decimal percent,
            Decimal quantity,
            DateTime validFrom,
            DateTime validTo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newKind"></param>
        /// <param name="persistentObject"></param>
        /// <param name="quantity"></param>
        /// <param name="validFrom"></param>
        /// <param name="validTo"></param>
        /// <returns></returns>
        CompensationProvision NewCompensationProvision(
            CompensationProvision.Kind newKind, 
            Something persistentObject,
            Decimal quantity,
            DateTime validFrom,
            DateTime validTo);
    }
}
