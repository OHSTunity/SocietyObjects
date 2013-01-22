/*
 * Mark:                        Society Objects Mark II
 * Concept approval:            Meeting #?
 * Implementation approval:     pending
 * Introduced by:               Joachim Wester
 * Authors:                     Joachim Wester
 * 
 * Not approved. Issues identified.
 * 
 * Status:      Global instance is not created. Should be supplied in XML file that is automatically read when a new database is created or updated with a new version of Society Objects.
 */

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;


namespace Concepts.Ring1
{
    /// <summary>
    /// A group that contains Everybody.
    /// </summary>
    /// <remarks>
    /// This group should be specially handled so that each member does not have to be
    /// explictly added as a member of this group.
    /// </remarks>
    /// <seealso cref="Concepts.Ring1.GroupMember"/>
    public class Everybody : Group
    {
    }
}
