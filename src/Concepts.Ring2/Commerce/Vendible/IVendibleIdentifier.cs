using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring2
{
    public interface IVendibleIdentifier
    {
        /// <summary>
        /// Tells the ToWhat of the ParticipatingVendible-relation to identify the
        /// instance in the system.
        /// </summary>
        void IdentifyVendibles();

        DateTime Created();
    }
}
