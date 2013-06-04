/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Plugins/SqlPreparedStatementLoader.cs#13 $
      $DateTime: 2007/07/13 17:57:22 $
      $Change: 4843 $
      $Author: careri $
      =========================================================
*/


using System;
using Starcounter;
using Concepts.Ring1;
using Kind = Concepts.Ring1.Something.Kind;
namespace Concepts.Ring2.Plugins
{
    /// <summary>
    /// Loads Prepared SQL-queries.
    /// </summary>
    public class SqlPreparedStatementLoader : IDetectable
    {
        

        public static bool _isActivated;


        #region IDetectable Members

        public void Detected(HostContext hostContext)
        {
            hostContext.HostStarted += new HostStartedEventHandler(hostContext_HostStarted);
        }

        void hostContext_HostStarted(object sender, HostStartedEventArgs args)
        {
            if (!_isActivated)
            {
                Transaction t = Transaction.NewCurrent();
                try
                {

                    string query = "";
                    #region Trade agreement
                    PriceConfiguration.Kind.FindOnPriceKey = Sql.GetPrepared(
                        string.Format(
                        "SELECT result FROM {0} result " +
                        "WHERE result.PriceKey=variable(String, PriceKey) ",
                        typeof(PriceConfiguration).FullName));

                    #endregion

                    #region Identifiers
                    Identifier.Kind.FullIdentifierMatchSql = Sql.GetPrepared(
                        string.Format(
                        "SELECT result FROM {0} result " +
                        "WHERE result.Identifies=variable({1}, Identifies) " +
                        "AND result.Name=variable(String, Identifier)",
                        Kind.GetInstance<Identifier.Kind>().FullInstanceClassName,
                        Kind.GetInstance<Something.Kind>().FullInstanceClassName));

                    Identifier.Kind.IdentifierSql = Sql.GetPrepared(
                        string.Format(
                        "SELECT result FROM {0} result " +
                        "WHERE result.Name=variable(String, Identifier)",
                        Kind.GetInstance<Identifier.Kind>().FullInstanceClassName));

                    Identifier.Kind.IdentifiesSql = Sql.GetPrepared(
                        string.Format(
                        "SELECT result FROM {0} result " +
                        "WHERE result.Identifies=variable({1}, Identifies)",
                        Kind.GetInstance<Identifier.Kind>().FullInstanceClassName,
                        Kind.GetInstance<Something.Kind>().FullInstanceClassName));


                    #endregion
                    
#region Tradable

                    Tradable.Kind._PreparedFindVendible = Sql.GetPrepared(
                        String.Format("SELECT t FROM {0} t "
                        + "WHERE t.WhatIs=variable(Concepts.Ring1.Something, whatIs) AND"
                        + "      t.ToWhat=variable(Concepts.Ring1.Something, supplier)",
                        Kind.GetInstance<Tradable.Kind>().FullInstanceClassName));
                    #endregion

                    #region ChargeOrDeduction
                    query = String.Format("SELECT cod FROM {0} cod WHERE cod.TradableNeedsToExist=VAR({1},vKind)", 
                        typeof(ChargeOrDeduction).FullName, 
                        typeof(Tradable).FullName);
                    ChargeOrDeduction.SqlPreparedTradableNeedsToExist = Sql.GetPrepared(query);

                    query = String.Format("SELECT cod FROM {0} cod WHERE cod.TradeAgreement=VAR({1},ta)",
                        typeof(ChargeOrDeduction).FullName, 
                        typeof(TradeAgreement).FullName);
                    TradeAgreement.SqlPreparedOffers = Sql.GetPrepared(query);


                    query = String.Format("SELECT co FROM {0} co",typeof(ComplexOffer).FullName);
                    ChargeOrDeduction.SqlPreparedAllComplexOffers = Sql.GetPrepared(query);
                    #endregion
                    _isActivated = true;
                }
                catch (System.Exception e)
                {
                    throw new ApplicationException("Failed to assure SQL-statements!", e);
                }
                finally
                {
                    t.Dispose(); 
                }
            }
        }

        #endregion
    }
}
