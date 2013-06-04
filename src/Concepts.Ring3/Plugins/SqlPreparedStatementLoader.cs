/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Plugins/SqlPreparedStatementLoader.cs#8 $
      $DateTime: 2007/07/13 17:57:22 $
      $Change: 4843 $
      $Author: careri $
      =========================================================
*/


using System;
using Starcounter;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring2;
using Kind = Concepts.Ring1.Something.Kind;
using Concepts.Ring3.SystemX;

namespace Concepts.Ring3.Plugins
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
            Activate();
        }

        public void Activate()
        {
            if (!_isActivated)
            {
                Transaction t = Transaction.NewCurrent();
                try
                {
                    string query = "";
                    SystemUserGroup.FindByName = Sql.GetPrepared(
                        string.Format(
                            "SELECT g FROM {0} g " +
                            "WHERE g.Name=VAR(String, Name)",
                            new object[] { typeof(SystemUserGroup).FullName }));

                    #region Author

                    Author.Kind.AssureSQLStatement = Sql.GetPrepared(
                        string.Format(
                            "SELECT author FROM {0} author " +
                            "WHERE author.WhatIs=variable({1}, author) AND author.ToWhat=variable({2}, literaryWorkKind)",
                            new object[] { Kind.GetInstance<Author.Kind>().FullInstanceClassName, 
                                           Kind.GetInstance<Somebody.Kind>().FullInstanceClassName, 
                                           Kind.GetInstance<Something.Kind>().FullInstanceClassName }));

                    Author.Kind.GetAuthorSQLStatement = Sql.GetPrepared(
                        string.Format(
                            "SELECT authors FROM {0} authors " +
                            "WHERE authors.LiteraryWorkKind=variable({1},literaryWorkKind)",
                            new object[] { Kind.GetInstance<Author.Kind>().FullInstanceClassName, 
                                           Kind.GetInstance<Artifact.Kind>().FullClassName }));
                    #endregion
                    #region ComputerSystem
                    
                    query = String.Format("SELECT c FROM {0} c WHERE c.ConnectedTo=VAR({0},ConnectedTo)",
                        typeof(ComputerSystem).FullName);
                    ComputerSystem.SqlPreparedChildren = Sql.GetPrepared(query);


                    query = String.Format("SELECT c FROM {0} c WHERE c.InheritsFrom=VAR({0},InheritsFrom)",
                        typeof(Configuration).FullName);
                    Configuration.SqlPreparedChildConfigurations = Sql.GetPrepared(query);
                    
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