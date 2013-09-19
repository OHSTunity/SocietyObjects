using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;

namespace Concepts.Ring8.Tunity
{
    public class LoginGuid:Something
    {
        public LoginGuid()
        {
        }
       
        
        public String Application;
        
        public SystemUser User;

        public Something Data;

        public ushort ContainerId()
        {
            return 0;// DbHelper.GetContainerID(User);
        }
    }
}
