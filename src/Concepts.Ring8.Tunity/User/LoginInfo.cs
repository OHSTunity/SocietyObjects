/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/User/LoginInfo.cs#5 $
      $DateTime: 2009/10/08 13:14:28 $
      $Change: 25901 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Holds information about a users logins
    /// (Right now it saves datetime/version/application about the users last two logins)
    /// </summary>
    public class LoginInfo: Something
    {
        //////////////////////////////////////////////
        /// Login
        //////////////////////////////////////////////
        private Login _lastLogin; //The logindate before current Login
        private Login _currentLogin;

        public Login LastLogin
        {
            get
            {
                return _lastLogin;
            }
        }

        public Login CurrentLogin
        {
            get
            {
                return _currentLogin;
            }
        }

        public void NewLogin(SystemUser user, String serverVersion, String application)
        {
            _lastLogin = _currentLogin;
            _currentLogin = new Login(user, DateTime.Now, serverVersion, application);
        }
    }

    [Database]
    public class Login
    {
        private DateTime _time;
        private String _serverVersion;
        private String _application;
        private SystemUser _user;

        public Login(SystemUser user, DateTime time, String serverVersion, String application)
        {
            _time = time;
            _serverVersion = serverVersion;
            _application = application;
            _user = user;
        }

        public DateTime Time
        {
            get { return _time; }
        }

        public SystemUser User
        {
            get { return _user; }
        }

        public String ServerVersion
        {
            get { return _serverVersion;  }
        }

        public String Application
        {
            get { return _application; }
        }

    }
}
