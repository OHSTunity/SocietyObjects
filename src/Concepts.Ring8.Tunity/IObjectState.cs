using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring2;
using Concepts.Ring3.SystemX;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Interface for all notifications
    /// </summary>
    public interface IObjectState
    {
        ObjectState ObjectState { get; set; }
    }
}

