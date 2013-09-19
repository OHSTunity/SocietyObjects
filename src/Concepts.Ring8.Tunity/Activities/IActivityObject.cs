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
    /// Interface for objects that somehow belongs to one or many activities
    /// (Therefore can give the activity back)
    /// </summary>
    public interface IActivityObject
    {
        TunityActivity ParentActivity(); 
    }
}

