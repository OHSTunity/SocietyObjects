using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring2;
using Concepts.Ring3;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Interface for all notifications
    /// </summary>
    public interface IModificationTarget
    {
        void ModificationAdded(Modification mod);
        
        void ModificationRemoved(Modification mod);
    }
}

