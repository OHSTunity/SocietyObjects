using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;
using Kind = Concepts.Ring1.Something.Kind;

namespace Concepts.Ring4.Plugins
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
                string query = "";
                try
                {
                    #region ProjectEventKindInfo

                    query = String.Format("SELECT c FROM {0} c WHERE c.Superset=VAR({1},Event)", 
                        Kind.GetInstance<LegalEventChild.Kind>().FullClassName, 
                        Kind.GetInstance<Event.Kind>().FullClassName);
                    ProjectEventKindInfo.SqlPreparedLegalChildren = Sql.GetPrepared(query);

                    query = String.Format("SELECT eventRole.ParentEventKind FROM {0} eventRole WHERE eventRole.Subset=VAR({1},Event)",
                            Kind.GetInstance<LegalEventParent.Kind>().FullClassName,
                            Kind.GetInstance<Event.Kind>().FullClassName);
                    ProjectEventKindInfo.SqlPreparedLegalParents = Sql.GetPrepared(query);
                    #endregion
                    _isActivated = true;
                }
                catch (System.Exception e)
                {
                    throw new ApplicationException(String.Format("Failed to assure SQL-statements!  {0}",query), e);
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
