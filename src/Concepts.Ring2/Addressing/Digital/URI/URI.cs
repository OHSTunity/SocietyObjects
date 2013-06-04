#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;

#endregion

namespace Concepts.Ring2
{
	/// <summary>
	/// 
	/// </summary>
    /// TODO! Glöm inte parametrar/Data
    public class URI : DigitalAddress
	{

     
		public String Scheme;

		public InternetAddress Host;

		public Port Port;

		public URIPath Path;

		public String UserInfo;



		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override String ToString()
		{
			StringBuilder ret = new StringBuilder();

			ret.Append(Scheme);
			ret.Append("://");
			if (this.UserInfo != null)
				ret.Append(this.UserInfo.ToString() + "@");
			ret.Append(this.Host.ToString());
			if (this.Port != null)
				ret.Append(":" + this.Port.ToString());

			if(!this.Path.ToString().StartsWith("/"))
				ret.Append('/');
			ret.Append(this.Path.ToString());
			return ret.ToString();


		}


    }

}
