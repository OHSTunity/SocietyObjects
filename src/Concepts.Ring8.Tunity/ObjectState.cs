using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// The different possible statuses for tunity objects
    /// </summary>
    /// 
    public enum ObjectState
    {
        [DescriptionValue("ObjectStatus.Active")]
        Active = 0,
        [DescriptionValue("ObjectStatus.Arhived")]
        Archived = 1,
        [DescriptionValue("ObjectStatus.Removed")]
        Removed = 2
    }

}

