/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/AgreedCompensation.cs#16 $
      $DateTime: 2011/09/27 10:20:40 $
      $Change: 48485 $
      $Author: hentil $
      =========================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using Starcounter;
using Concepts.Ring1;


namespace Concepts.Ring2
{
    /// <summary>
    /// An agreement between a supplier and one or more consumers. The agreement can have one or more 
    /// offers (CompensationProvision(s)) availible for the consumer. 
    /// </summary>
    public class AgreedCompensation : Agreement
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="Agreement.Kind"/>
        public new class Kind : Agreement.Kind
        {
            /// <summary>
            /// Template attribute for use on instances.
            /// </summary>
            public Consumer Offeree;

            /// <summary>
            /// List all trade agreements of a specified type.
            /// </summary>
            /// <typeparam name="T">Type specification of trade agreements to search for.</typeparam>
            /// <param name="consumer">Consumer. If null; template offeree on this kind will be used.</param>
            /// <returns>List of instances of the specified type</returns>
            public IEnumerable<AgreedCompensation> AgreedCompensationForConsumer(Consumer consumer)
            {
                if (consumer == null)
                {
                    throw new ApplicationException("No consumer for new AgreedCompensation is specified");
                }
                string sqlStatement =
                    string.Format("SELECT agreedComp FROM {0} agreedComp " +
                                  "WHERE agreedComp.Consumer=VAR({1},consumer)",
                       this.FullInstanceClassName,
                       Kind.GetInstance<Consumer.Kind>().FullInstanceClassName);

                using (SqlEnumerator<AgreedCompensation> sqlEnum =
                    Sql.GetEnumerator<AgreedCompensation>(sqlStatement))
                {
                    sqlEnum.SetVariable("consumer", consumer);

                    foreach (AgreedCompensation agreement in sqlEnum)
                    {
                        if (agreement.InstantiatedFrom.Equals(this) && IsValidInTime(agreement))
                        {
                            yield return agreement;
                        }
                    } 
                }
            }

            /// <summary>
            /// Validates if a trade agreement is valid in time.
            /// </summary>
            /// <param name="agreement"></param>
            /// <returns></returns>
            protected Boolean IsValidInTime(AgreedCompensation agreement)
            {
                return (agreement.ValidFrom < DateTime.Now) && (agreement.ValidTo > DateTime.Now);
            }

            /// <summary>
            /// Assures a trade agreement instance that is valid in time and
            /// valid for the given consumer.
            /// </summary>
            /// <typeparam name="T">Type specification of the wanted instance</typeparam>
            /// <param name="consumer">Consumer</param>
            /// <returns>trade agreement of the specificed type T</returns>
            public AgreedCompensation AssureAgreement(Consumer consumer)
            {
                AgreedCompensation agreement = null;
                foreach (AgreedCompensation item in AgreedCompensationForConsumer(consumer))
                {
                    agreement = item;
                    break;
                }

                if (agreement == null)
                {
                    agreement = New<AgreedCompensation>();
                    agreement.Offeree = consumer;
                    agreement.ValidFrom = DateTime.MinValue;
                    agreement.ValidTo = DateTime.MaxValue;
                }
                return agreement;
            }
        }

        #endregion

        /// <summary>
        /// Offeree of this agreement.
        /// </summary>
        private Consumer _offeree;


        [SynonymousTo("_offeree")]
        public readonly Consumer Consumer;

        /// <summary>
        /// Offeree participant of the agreement.
        /// </summary>
        public Consumer Offeree
        {
            get
            {
                return _offeree;
            }
            set
            {
                _offeree = value;
            }
        }

        /// <summary>
        /// The Offeror participant of the agreement.
        /// </summary>
        public Somebody Offeror
        {
            get
            {
                Somebody offeror = null;

                if (Offeree != null)
                {
                    offeror = Offeree.ToWhom;
                }

                return offeror;
            }
        }

        /// <summary>
        /// Inactivate this object.
        /// </summary>
        public override void InActivate()
        {
            base.InActivate();
            foreach (CompensationProvision compensationProvision in Offers)
            {
                compensationProvision.InActivate();
            }
        }

        /// <summary>
        /// Start date of the trade agreement.
        /// </summary>
        [SynonymousTo("BeginTime")]
        public DateTime ValidFrom;

        /// <summary>
        /// Stop date of the trade agreement.
        /// </summary>
        [SynonymousTo("EndTime")]
        public DateTime ValidTo;

        /// <summary>
        /// Validates if the trade agreement is valid for the specified participants
        /// </summary>
        /// <param name="consumer">Constains both the offeror and offeree:
        /// consumer.WhatIs = offeree
        /// consumer.ToWhat = offeror</param>
        /// <returns></returns>
        public Boolean IsAgreedCompensationUsable(Consumer consumer)
        {
            Boolean isUsable = false;

            //Direct match.
            if (consumer.Equals(Offeree))
            {
                isUsable = true;
            }
            //Check participators.
            else
            {
                isUsable = IsSomebodyAValidOfferor(consumer.ToWhom) && IsSomebodyValidAsOfferee(consumer.WhoIs);
            }
            return isUsable;
        }

        /// <summary>
        /// Validates if a specific <c>Somebody</c> is a valid consumer of the trade agreement.
        /// Excluding agreements that os valid for <c>Everybody._.GetInstance()</c>
        /// </summary>
        /// <param name="offereeCandidate"></param>
        /// <returns></returns>
        public Boolean IsValidExclEverybodyConsumers(Somebody offereeCandidate)
        {
            Boolean isMatching = false;

            //Everybody is consumer, not what we are looking for here.
            if (Offeree.ToWhom.Equals(Kind.GetInstance<Everybody.Kind>().Singleton))
            {
                isMatching = false;
            }
            //Validate offeree candidate.
            else if (IsSomebodyValidAsOfferee(offereeCandidate))
            {
                isMatching = true;
            }
            return isMatching;

        }

        /// <summary>
        /// Validates if a <c>Somebody</c> is a valid offeror.
        /// </summary>
        /// <param name="offerorCandidate"></param>
        /// <returns></returns>
        public Boolean IsSomebodyAValidOfferor(Somebody offerorCandidate)
        {
            Boolean isMatching = false;

            //Direct match.
            if (Offeror.Equals(offerorCandidate))
            {
                isMatching = true;
            }
            //Is a part of a group that offers this agreement.
            else if (Offeror is Group)
            {
                isMatching = ((Group)Offeror).IsMember(offerorCandidate);
            }
            return isMatching;
        }

        /// <summary>
        /// Validation of a offeree candidate.
        /// </summary>
        /// <param name="offereeCandidate"></param>
        /// <returns></returns>
        public Boolean IsSomebodyValidAsOfferee(Somebody offereeCandidate)
        {
            Boolean isMatching = false;

            //This trade agreement is valid for only one consumer
            if (Offeree.WhoIs.Equals(offereeCandidate))
            {
                isMatching = true;
            }
            else if (Offeree.WhoIs.Equals(Kind.GetInstance<Everybody.Kind>().Singleton))
            {
                isMatching = true;
            }
            //Check if this agreement is valid for the offereeCandidate,
            //since this agreement is valid for a group of somebodies.
            else if (Offeree.WhoIs is Group)
            {
                isMatching = ((Group)Offeree.WhoIs).IsMember(offereeCandidate);
            }
            return isMatching;
        }

        /// <summary>
        /// List of all connected CompensationProvision instances that 
        /// are connected to this agreement.
        /// </summary>
        public IEnumerable<CompensationProvision> Offers
        {
            get
            {
                SqlEnumerator<CompensationProvision> e = Sql.GetEnumerator<CompensationProvision>(
                    string.Format("SELECT cod FROM {0} cod WHERE cod.AgreedCompensation=VAR({1},ta)",
                        Kind.GetInstance<CompensationProvision.Kind>().FullInstanceClassName,
                        Kind.GetInstance<AgreedCompensation.Kind>().FullInstanceClassName));
                e.SetVariable("ta", this);

                // By using yield return we make sure that the enumerator is disposed
                foreach (var cp in e)
                {
                    yield return cp;
                }


            }
        }
    }
}
