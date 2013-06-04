using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace Ring3.Artifacts
{
    /// <summary>
    /// A peripheral (truncation of “peripheral device”) is any computer 
    /// device that is not part of the essential computer (the processor, 
    /// memory, and data paths) but is situated relatively close by. Some 
    /// peripherals are mounted in the same case with the main part of the 
    /// computer, as are the hard disk drive, CD-ROM drive, and NIC. Other 
    /// peripherals are outside the computer case, such as the printer and 
    /// image scanner, attached by a wired or wireless connection.
    /// Source: www.mcsx.co.uk/articles/glossary.htm
    /// </summary>
    public class PeripheralDevice : ComputerSystem
    {
        #region Kind
        public new class Kind : ComputerSystem.Kind { }
        #endregion

        /// <summary>
        /// Uniquely identifies this PeripheralDevice (e.g. object ID);
        /// </summary>
        public ulong ID
        {
            get { return this.ObjectID; }
        }


        
    }
}
