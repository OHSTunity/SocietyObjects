#region Using directives

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;


#endregion

namespace Concepts.Ring2
{
    public class URIPath : DigitalAddress
	{
       


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override String ToString()
		{
			if (AddressID == null)
				return null;

			StringBuilder ret=new StringBuilder();
			GetPathString(this,ret);

			//Make sure we do not have any back-slashes and always end with a slash

			ret.Replace('\\', '/');


			return ret.ToString();

		}

		void GetPathString(URIPath path, StringBuilder ret)
		{

			if (path.PartOf != null)
			{
				GetPathString((URIPath)path.PartOf, ret);
			}

			ret.Append(path.AddressID);
			

		
		}

		



	}
}
