using AlexaWorld.SkillKit.Extensions;
using AlexaWorld.SkillKit.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlexaWorld.SkillKit.Helpers
{
	public class AmazonHttpRequest
	{
		private string token;

		public AmazonHttpRequest(string token)
		{
			this.token = token;
		}

		public async Task<JObject> GetAsync(string url)
		{
			using (var client = GetClient())
			{
				var result = await client.GetAsync(url);

				var stream = await result.Content.ReadAsStreamAsync();
				var sr = new StreamReader(stream, Encoding.UTF8);
				var content = sr.ReadToEnd();

				Guard.NotNullOrEmpty(content, "Request content is empty");

				var jObject = JsonConvert.DeserializeObject<JObject>(content);
				return jObject;
			}
		}

		public async Task<Address> GetAddressAsync(string apiEndpoint, string deviceId)
		{
			var url = $"{apiEndpoint}/v1/devices/{deviceId}/settings/address";
			var jAddress = await GetAsync(url);
			var result = new Address()
			{
				AddressLine1 = jAddress.GetString("addressLine1"),
				AddressLine2 = jAddress.GetString("addressLine2"),
				AddressLine3 = jAddress.GetString("addressLine3"),
				City = jAddress.GetString("city"),
				CountryCode = jAddress.GetString("countryCode"),
				DistrictOrCounty = jAddress.GetString("districtOrCounty"),
				PostalCode = jAddress.GetString("postalCode"),
				StateOrRegion = jAddress.GetString("stateOrRegion")
			};
			return result;
		}

		private HttpClient GetClient()
		{
			var authValue = new AuthenticationHeaderValue("Bearer", token);
			var client = new HttpClient()
			{
				DefaultRequestHeaders = { Authorization = authValue }
			};
			return client;
		}

	}
}
