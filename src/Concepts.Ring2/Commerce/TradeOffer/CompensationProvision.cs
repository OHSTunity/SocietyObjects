/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/CompensationProvision.cs#38 $
      $DateTime: 2012/06/02 20:23:33 $
      $Change: 58550 $
      $Author: hentil $
      =========================================================
*/

using System;
using System.Linq;
using System.Collections.Generic;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    public enum DateValidationType
    {
        HISTORICAL,
        ACTIVE,
        ACTIVE_AND_FUTURE,
        FUTURE,
        ALL
    }

    /// <summary>
    /// Base for offers. Hold information about amount, percentage, currency, unit and quantity that 
    /// a price offer refer to. It also holds information about condition for this offer to be valid.
    /// </summary>
    public class CompensationProvision : Something, ICombinedIndexed
    {
        #region Kind
        /// <summary>
        /// </summary>
        /// <seealso cref="Something.Kind"/>
        public new class Kind : Something.Kind, ICompensationProvisionFactory
        {
            #region ICompensationProvisionFactory

            /// <summary>
            /// 
            /// </summary>
            /// <param name="wantedType"></param>
            /// <param name="includedIn"></param>
            /// <param name="persistentObject"></param>
            /// <param name="amount"></param>
            /// <param name="quantity"></param>
            /// <param name="currencyKind"></param>
            /// <param name="validFrom"></param>
            /// <param name="validTo"></param>
            /// <returns></returns>
            public CompensationProvision NewCharge(
                CompensationProvision.Kind wantedType,
                AgreedCompensation includedIn,
                Something persistentObject,
                Decimal amount,
                Decimal quantity,
                Currency.Kind currencyKind,
                DateTime validFrom,
                DateTime validTo)
            {
                //Instantiate the new charge.
                CompensationProvision compensationProvision = NewCompensationProvision(wantedType, persistentObject, quantity, validFrom, validTo);

                //Initiate
                compensationProvision.CurrencyKind = currencyKind;
                compensationProvision.SetAppliesTo(persistentObject);
                compensationProvision.SetAgreedCompensation(includedIn);
                compensationProvision.Amount = amount;
                compensationProvision.IsRelative = false;
                return compensationProvision;
            }

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
            public CompensationProvision NewRelativeDeduction(
                CompensationProvision.Kind wantedType,
                AgreedCompensation includedIn,
                Something persistentObject,
                Decimal percent,
                Decimal quantity,
                DateTime validFrom,
                DateTime validTo)
            {
                //Instantiate the new charge.
                CompensationProvision compensationProvision = NewCompensationProvision(
                    wantedType,
                    persistentObject,
                    quantity,
                    validFrom,
                    validTo);

                //Initiate
                compensationProvision.SetAppliesTo(persistentObject);
                compensationProvision.SetAgreedCompensation(includedIn);
                compensationProvision.AddPercent = -percent;
                compensationProvision.IsRelative = true;
                return compensationProvision;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="wantedType"></param>
            /// <param name="agreement"></param>
            /// <param name="persistentObject"></param>
            /// <param name="percent"></param>
            /// <param name="quantity"></param>
            /// <param name="validFrom"></param>
            /// <param name="validTo"></param>
            /// <returns></returns>
            public CompensationProvision NewRelativeCharge(
                CompensationProvision.Kind wantedType,
                AgreedCompensation agreement,
                Something persistentObject,
                Decimal percent,
                Decimal quantity,
                DateTime validFrom,
                DateTime validTo)
            {
                //Instantiate the new charge.
                CompensationProvision compensationProvision = NewCompensationProvision(
                    wantedType,
                    persistentObject,
                    quantity,
                    validFrom,
                    validTo);

                //Initiate
                compensationProvision.SetAppliesTo(persistentObject);
                compensationProvision.SetAgreedCompensation(agreement);
                compensationProvision.AddPercent = percent;
                compensationProvision.IsRelative = true;

                return compensationProvision;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="newKind"></param>
            /// <param name="persistentObject"></param>
            /// <param name="conditionQuantity"></param>
            /// <param name="validFrom"></param>
            /// <param name="validTo"></param>
            /// <returns></returns>
            public CompensationProvision NewCompensationProvision(
                CompensationProvision.Kind newKind,
                Something persistentObject,
                Decimal conditionQuantity,
                DateTime validFrom,
                DateTime validTo)
            {
                CompensationProvision compensationProvision;
                //New instance of the specified type.
                if (newKind != null)
                {
                    compensationProvision = (CompensationProvision)newKind.New();
                }
                else
                {
                    compensationProvision = new CompensationProvision();
                }

                //Initiate.
                compensationProvision.ConditionQuantity = conditionQuantity;
                compensationProvision.SetAppliesTo(persistentObject);
                compensationProvision.ValidFrom = validFrom;
                compensationProvision.ValidTo = validTo;
                compensationProvision.IsClosed = false;

                return compensationProvision;
            }

            #endregion

            #region Collecting price elements

            public IEnumerable<CompensationProvision> MatchingOffers(Consumer consumer,
                Something persistentObject,
                Decimal quantity,
                DateValidationType dateValidationType)
            {
                if (consumer == null || persistentObject == null)
                {
                    throw new ArgumentException("Missing offeror or object in price evaluation.");
                }

                List<CompensationProvision> validElements = new List<CompensationProvision>();
                IEnumerable<CompensationProvision> offerCandidates = GetOffers(persistentObject);

                foreach (CompensationProvision cod in offerCandidates)
                {
                    //Validate participating parts
                    if (!cod.AgreedCompensation.IsAgreedCompensationUsable(consumer))
                    {
                        continue; //No match, check next offer.
                    }
                    if (CanAddElement(cod, dateValidationType))
                    {
                        validElements.Add(cod);
                    }
                }

                return validElements;
            }

            public IEnumerable<CompensationProvision> MatchingOffers(Somebody offeror,
                Something persistentObject,
                DateValidationType dateValidationType)
            {
                if (offeror == null || persistentObject == null)
                {
                    throw new ArgumentException("Missing offeror or object in price evaluation.");
                }

                List<CompensationProvision> validElements = new List<CompensationProvision>();
                IEnumerable<CompensationProvision> offerCandidates = GetOffers(persistentObject);

                foreach (CompensationProvision cod in offerCandidates)
                {
                    //Validate participating parts
                    if (!cod.AgreedCompensation.IsSomebodyAValidOfferor(offeror))
                    {
                        continue; //No match, check next offer.
                    }
                    if (CanAddElement(cod, dateValidationType))
                    {
                        validElements.Add(cod);
                    }
                }
                return validElements;
            }

            private Boolean CanAddElement(CompensationProvision element, DateValidationType dateValidationType)
            {
                Boolean isValid = false;
                switch (dateValidationType)
                {
                    case DateValidationType.ALL:
                        isValid = true;
                        break;
                    case DateValidationType.HISTORICAL:
                        if (DateTime.Compare(element.ValidTo, DateTime.Now) < 0)
                        {
                            isValid = true;
                        }
                        break;
                    case DateValidationType.ACTIVE:
                        if (!element.IsClosed &&
                            DateTime.Compare(element.ValidFrom, DateTime.Now) < 0 &&
                            DateTime.Compare(element.ValidTo, DateTime.Now) > 0)
                        {
                            isValid = true;
                        }
                        break;
                    case DateValidationType.ACTIVE_AND_FUTURE:
                        if (!element.IsClosed)
                        {
                            if (DateTime.Compare(element.ValidFrom, DateTime.Now) < 0 &&
                                DateTime.Compare(element.ValidTo, DateTime.Now) > 0) //Active
                            {
                                isValid = true;
                            }
                            if (DateTime.Compare(element.ValidFrom, DateTime.Now) > 0) //Future
                            {
                                isValid = true;
                            }
                        }
                        break;
                    case DateValidationType.FUTURE:
                        if (!element.IsClosed &&
                            DateTime.Compare(element.ValidFrom, DateTime.Now) > 0)
                        {
                            isValid = true;
                        }
                        break;
                    default:
                        isValid = false;
                        break;
                }

                return isValid;
            }

            private IEnumerable<CompensationProvision> GetOffers(
                Something something)
            {
                SqlEnumerator<CompensationProvision> e = Sql.GetEnumerator<CompensationProvision>(
                    string.Format("SELECT cod FROM {0} cod WHERE cod.AppliesTo=VAR({1},something)",
                    Kind.GetInstance<CompensationProvision.Kind>().FullInstanceClassName,
                        something.FullClassName));
                e.SetVariable("something", something);

                // By using yield return we make sure that the enumerator is disposed
                foreach (var cp in e)
                {
                    yield return cp;
                }
            }

            #endregion
        }
        #endregion

        private int _combinedIndex;
        /// <summary>
        /// TODO, remove this when Starcounter supports real combined indexes.
        /// Temporary solution to speed up relation searches.
        /// </summary>
        [SynonymousTo("_combinedIndex")]
        public readonly int CombinedIndex;

        public void RegenerateIndex()
        {
            UpdateCombinedIndex(AppliesTo, AgreedCompensation);
        }

        private void UpdateCombinedIndex(Something appliesTo, AgreedCompensation agreedCompensation)
        {
            int combinedIndex;
            CombinedIndexHelper.TryGet(appliesTo, agreedCompensation, true, out combinedIndex);/*Ok*/
            _combinedIndex = combinedIndex;

        }

        /// <summary>
        /// For simple conditions that are based on the fact that a single kind of Vendible exists
        /// the associated Condition can be null and this field can be used instead.
        /// PLEASE OBSERVE! The Condition field must be null if this field is not null.
        /// </summary>
        public Vendible VendibleNeedsToExist;

        private Something _appliesTo;
        /// <summary>
        /// This shall apply to a certain object. 
        /// </summary>
        [SynonymousTo("_appliesTo")]
        public readonly Something AppliesTo;

        public void SetAppliesTo(Something something)
        {
            UpdateCombinedIndex(something, AgreedCompensation);
            _appliesTo = something;
        }

        /// <summary>
        /// The minimum quantity that is needed to be fullfilled the condition
        /// of this CompensationProvision.
        /// </summary>
        public decimal ConditionQuantity;

        /// <summary>
        /// Specifies if this charge or deduction is reletive an other charge or deduction.
        /// If it is relative, it can't create an offer on it's own, hence it needs a base to be 
        /// applied to.
        /// </summary>
        public Boolean IsRelative;

        /// <summary>
        /// If the value is an amount, CurrencyKind specifies the currency of the amount.
        /// </summary>
        public Currency.Kind CurrencyKind;

        /// <summary>
        /// The amount of the charge or deduction.
        /// </summary>
        public Decimal Amount;

        /// <summary>
        /// The percent to add or remove.
        /// </summary>
        public Decimal AddPercent;

        /// <summary>
        /// The condition to fullfill to receive the charge or deduction
        /// </summary>
        public Condition Condition;

        /// <summary>
        /// An offer can be closed if it's will not be used anymore, but can't be
        /// removed since it is referenced by (has been used on) a sale.
        /// </summary>
        public Boolean IsClosed;

        /// <summary>
        /// Indicates if this CompensationProvision can be update or not.
        /// </summary>
        /// <returns>True if update i allowed.</returns>
        public Boolean IsUsedOnPrice;

        /// <summary>
        /// End time of this offer. If value equals DateTime.MinValue, value is taken from
        /// TradeOfferAgreement.
        /// </summary>
        private DateTime _stopTime;

        /// <summary>
        /// End time of this offer. If value equals DateTime.MinValue, value is taken from
        /// TradeOfferAgreement.
        /// </summary>
        [SynonymousTo("_stopTime")]
        public readonly DateTime StopTime;

        /// <summary>
        /// Begin time of this offer. If value equals DateTime.MinValue, value is taken from
        /// TradeOfferAgreement.
        /// </summary>
        private DateTime _startTime;

        /// <summary>
        /// Begin time of this offer. If value equals DateTime.MinValue, value is taken from
        /// TradeOfferAgreement.
        /// </summary>
        [SynonymousTo("_startTime")]
        public readonly DateTime StartTime;

        private AgreedCompensation _agreedCompensation;
        /// <summary>
        /// Parts that concerns this offer.
        /// </summary>
        [SynonymousTo("_agreedCompensation")]
        public readonly AgreedCompensation AgreedCompensation;

        /// <summary>
        /// Updates the agreement.
        /// </summary>
        /// <param name="agreedCompensation"></param>
        public void SetAgreedCompensation(AgreedCompensation agreedCompensation)
        {
            UpdateCombinedIndex(AppliesTo, agreedCompensation);
            _agreedCompensation = agreedCompensation;
        }

        /// <summary>
        /// Begin time of offer.
        /// </summary>
        public DateTime ValidFrom
        {
            get
            {
                if (_startTime.Equals(DateTime.MinValue))
                {
                    return AgreedCompensation.ValidFrom;
                }
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        /// <summary>
        /// End time of offer.
        /// </summary>
        public DateTime ValidTo
        {
            get
            {
                if (_stopTime.Equals(DateTime.MinValue))
                {
                    return AgreedCompensation.ValidTo;
                }
                return _stopTime;
            }
            set
            {
                _stopTime = value;
            }
        }

        /// <summary>
        /// Validates if this CompensationProvision has the correct unit and
        /// the correct quantity of that unit.
        /// Implemented for an equal match on unit and equal or greater than on the quantity.
        /// </summary>
        /// <param name="quantity">Quantity of the unit</param>
        /// <param name="vendible">Unit</param>
        /// <returns>Matching status of this CompensationProvision</returns>
        protected Boolean CheckUnitAndQuantity(Decimal quantity)
        {
            Boolean match = false;
            //No unit or quantity connected to a TAX.
            if (AgreedCompensation is TaxAgreement)
            {
                match = true;
            }
            // TODO, Math Abs is a temporary solution for allowing return of vendibles.
            else if (ConditionQuantity <= Math.Abs(quantity)) //Check quantity of the unit
            {
                match = true; //Correct match
            }
            return match;
        }

        #region ICombinedIndexed Members

        public string IndexField
        {
            get { return "CombinedIndex"; }
        }

        public Something RelatedObject1
        {
            get { return AppliesTo; }
        }

        public Something RelatedObject2
        {
            get { return AgreedCompensation; }
        }

        #endregion
    }
}
