/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Artifacts/Printer.cs#6 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
using Concepts.Ring3.SystemX;
using System.Collections.Generic;
using System;
using System.Linq;
using Starcounter;


namespace Concepts.Ring3
{
    /// <summary>
    /// A printer is a computer peripheral device that produces 
    /// a hard copy (permanent human-readable text and/or graphics, 
    /// usually on paper) from data stored in a computer connected to it.
    /// </summary>
    public class Printer : ComputerSystem
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : ComputerSystem.Kind
        {

            public Printer Assure(String printerName)
            {
                Printer printer = null;
                SqlEnumerator<Printer> e = null;
                if (printerName != null && printerName.Length > 0)
                {
                    string query = String.Format("SELECT printer FROM {0} printer WHERE printer.Name=VAR(String,name)", FullInstanceClassName);
                    
                    using (e = Sql.GetEnumerator<Printer>(query))
                    {
                        e.SetVariable("name", printerName);
                        printer = e.FirstOrDefault<Printer>(); 
                    }
                }

                if (printer == null)
                {
                    printer = new Printer();
                    printer.Name = printerName;
                }

                return printer;
            }
        }

        #endregion
    }
}
