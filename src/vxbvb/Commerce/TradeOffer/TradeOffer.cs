/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/TradeOffer.cs#10 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Starcounter;

using System.Collections;

namespace Concepts.Ring2
{
    /// <summary>
    /// Trade offers for consumers. Synonymous to Campaign.
    /// </summary>
    public class TradeOffer : AgreedCompensation
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="AgreedCompensation.Kind"/>
        public new class Kind : AgreedCompensation.Kind
        {

            /// <summary>
            /// Assures a new Campaign type.
            /// </summary>
            /// <param name="name">Name of Campaign</param>
            /// <returns>TradeOffer</returns>
            public virtual TradeOffer.Kind AssureCampaignType(string name, string description)
            {
                TradeOffer.Kind campaign = null;
                if (name != null)
                {
                    using (SqlEnumerator sqlEnumerator = Sql.GetEnumerator(
                        "SELECT result FROM Concepts.Ring2.TradeOffer.Kind result WHERE result.Name=variable(String, name)"))
                    {
                        sqlEnumerator.SetVariable("name", name);

                        while (sqlEnumerator.MoveNext())
                        {
                            campaign = sqlEnumerator.Current as TradeOffer.Kind;
                        }
                        if (campaign == null)
                        {
                            campaign = Kind.GetInstance<TradeOffer.Kind>().Derive() as TradeOffer.Kind;
                            campaign.Name = name;
                            if (description != null)
                            {
                                campaign.Description = description;
                            }
                        } 
                    }
                }
                else
                {
                    throw new ArgumentException("Cannot create new Concepts.Ring2.TradeOffer.Kind if variable Name is null.");
                }
                return campaign;
            }
        }
        #endregion
    }
}
