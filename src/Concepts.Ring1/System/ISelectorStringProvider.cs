// Not a persistent object. Not part of the Society Objects Ring system.
// Provide an example of what subsystem uses this interface.
/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/System/ISelectorStringProvider.cs#1 $
      $DateTime: 2008/03/27 13:06:50 $
      $Change: 10885 $
      $Author: hentil $
      =========================================================
*/

namespace Concepts.Ring1
{
    /// <summary>
    /// Any object implementing this interface is able to return an ID that is unique within the current context.
    /// </summary>
    public interface IToSelectorString
    {
        string ToSelectorString();
        string SelectorString
        {
            get;
        }
    }
}
