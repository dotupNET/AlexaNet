using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaWorld.SkillKit.Responses
{
	public class Address
	{
		public string StateOrRegion { get; set; }
		public string City { get; set; }
		public string CountryCode { get; set; }
		public string PostalCode { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string AddressLine3 { get; set; }
		public string DistrictOrCounty { get; set; }
	}
}
