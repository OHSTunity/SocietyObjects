using System;
using System.Collections.Generic;
using System.Text;
using Ring3;
using Ring1;

namespace Ring4.Artifacts
{
    /// <summary>
    /// This is a Communication Port
    /// </summary>
    public class ComPort : ComputerSystem
    {
        #region Kind

        public new class Kind : ComputerSystem.Kind { }

        #endregion

        /// <summary>
        /// Adress
        /// </summary>
        public byte IOAddress;

        /// <summary>
        /// Interrupt Request
        /// </summary>
        public int IRQ;

        /// <summary>
        /// Usually 9600
        /// </summary>
        public int Baud;

        /// <summary>
        /// Usually 9 or 25
        /// </summary>
        public int NrPins;


       
    }
}
