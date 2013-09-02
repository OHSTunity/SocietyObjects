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
    public class LoginRole : Relation
    {
        private String comments;

        public String Comments
        {
            get { return comments; }
            set { comments = value; }
        }

    }
}
