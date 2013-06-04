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
        public new class Kind : DigitalAddress.Kind
        {


		
			/// <summary>
			/// 
			/// </summary>
			/// <param name="name"></param>
			/// <returns></returns>
			public URIPath AssurePath(String name)
			{
                string query = String.Format("SELECT path FROM {0} path WHERE path.Name=VAR(String,name)", FullInstanceClassName);
                URIPath path;
                
                using (SqlEnumerator<URIPath> e = Sql.GetEnumerator<URIPath>(query))
                {
                    e.SetVariable("name", name);
                    path = e.FirstOrDefault<URIPath>();

                    if (path == null)
                    {
                        path = New<URIPath>();
                        path.AddressID = name;
                    } 
                }

				return path;

			}

		}


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
