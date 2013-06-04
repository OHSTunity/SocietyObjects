#region Using directives

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Starcounter;
using Concepts.Ring1;


#endregion

namespace Concepts.Ring2
{
	/// <summary>
	/// 
	/// </summary>
	public class InternetAddress : DigitalAddress
	{
        /* TODO
        public new class Kind : DigitalAddress.Kind 
		{
			public InternetAddress Assure(String ipAddress)
			{
                string query = String.Format("SELECT address FROM {0} address WHERE address.AddressID=VAR(String,id)",FullInstanceClassName);
                InternetAddress address;

                using (SqlEnumerator<InternetAddress> e = Sql.GetEnumerator<InternetAddress>(query))
                {
                    e.SetVariable("id", ipAddress);
                    address = e.FirstOrDefault<InternetAddress>();
                    if (address == null)
                    {
                        address = New<InternetAddress>();
                        address.IpAddress = ipAddress;
                    } 
                }
				return address;
			}

			
		}
        */

        /// <summary>
        /// Returns a numerical representation of the IP address. TODO: Handle IPv6
        /// </summary>
        /// <returns></returns>
        public UInt64 ToNumber(String ipAddress)
        {
            // Verify a correctly formated ip address
            IPAddress ip = IPAddress.Parse(ipAddress);

            String[] parts = ipAddress.Split('.');
            UInt64 p1 = UInt64.Parse(parts[0]);
            UInt64 p2 = UInt64.Parse(parts[1]);
            UInt64 p3 = UInt64.Parse(parts[2]);
            UInt64 p4 = UInt64.Parse(parts[3]);
            UInt64 ret = p1 * 16777216 + p2 * 65536 + p3 * 256 + p4;
            return ret;
        }

//        [SynonymousTo("AddressID")]
		public String IpAddress
		{
			get
			{
				return AddressID;
			}
			set
			{
				// Verify a correctly formated ip address
				IPAddress.Parse(value);
				AddressID = value;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override String ToString()
		{
			return IpAddress;
		}


		/// <summary>
		/// Returns a numerical representation of the IP address.
		/// </summary>
		/// <returns></returns>
		public UInt64 ToNumber()
		{
			return ToNumber(IpAddress);
		}

	}
}
