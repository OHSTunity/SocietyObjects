/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/User/LoginRole.cs#7 $
      $DateTime: 2008/12/16 10:06:38 $
      $Change: 17570 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;

namespace Concepts.Ring8.Tunity
{
    public class ExternalDocumentOwner : Role
    {
        //This is the data used when creating the external folder.
        public String UsedProjectNumber;
        public String UsedProjectName;
        public String UsedCustomerName;
    }
}
