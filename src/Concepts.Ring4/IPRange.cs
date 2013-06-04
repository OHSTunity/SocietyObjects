using System;
using System.Collections.Generic;
using System.Text;
using Starcounter.Data;
using Ring2.Communication.URI;

namespace Ring4
{
	public class IPRange : Ring1.Something
	{
		public new class Kind : Ring1.Something.Kind { }

		public InternetAddress FromIP;

		public InternetAddress ToIP;

		[Ignore]
		public String FromIPString
		{
			get
			{
				if (FromIP == null)
				{
					return "";
				}
				return FromIP.ToString();
			}
			set
			{
				FromIP = (InternetAddress._ as InternetAddress.Kind).Assure(value);
			}
		}

		[Ignore]
		public String ToIPString
		{
			get
			{
				if (ToIP == null)
				{
					return "";
				}
				return ToIP.ToString();
			}
			set
			{
				ToIP = (InternetAddress._ as InternetAddress.Kind).Assure(value);
			}
		}

		public bool IsInRange(String address)
		{
			if (FromIP == null || ToIP == null || address == null)
			{
				return false;
			}
			UInt64 nAddress = (InternetAddress._ as InternetAddress.Kind).ToNumber(address);
			return nAddress >= FromIP.ToNumber() && nAddress <= ToIP.ToNumber();
		}

		public bool IsInRange(InternetAddress address)
		{
			return IsInRange(address.IpAddress);
		}
	}
}
