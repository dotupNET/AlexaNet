using AlexaWorld.SkillKit.Objects;
using AlexaWorld.SkillKit.Requests.SlotResolutions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlexaWorld.SkillKit.JsonParser
{
	public class SlotParser
	{
		public Dictionary<string, Slot> Parse(JObject intent)
		{
			IEnumerable<JProperty> slots = intent.Value<JObject>("slots")?.Children<JProperty>();
			var result = slots.ToDictionary(s => s.Name, s => GetSlotObject(s.Value as JObject));
			return result;
		}

		private Slot GetSlotObject(JObject slot)
		{
			if (slot == null)
				return null;

			Enum.TryParse(slot.GetString("confirmationStatus"), out ConfirmationStatusEnum confirmationStatus);

			return new Slot
			{
				Id = slot.GetString("id"),
				Name = slot.GetString("name"),
				Value = slot.GetString("value"),
				ConfirmationStatus = confirmationStatus,
				Resolutions = GetResolutions(slot)
			};
		}

		public Resolutions GetResolutions(JObject slot)
		{
			var json = slot.Value<JObject>("resolutions");
			if (json == null)
				return null;

			return new Resolutions
			{
				ResolutionsPerAuthority = GetResolutionsPerAuthority(json)
			};
		}

		private List<ResolutionsPerAuthority> GetResolutionsPerAuthority(JObject jObject)
		{
			var resolutionsPerAuthority = jObject.Value<JArray>("resolutionsPerAuthority")?.Children().AsJEnumerable();

			return resolutionsPerAuthority.Select(r =>
			{
				return new ResolutionsPerAuthority
				{
					Authority = jObject.Value<string>("authority"),
					Status = GetResolutionsPerAuthorityStatusCode(r.Value<JObject>("status")),
					Values = GetResolutionsPerAuthorityValues(r.Value<JObject>("values"))
				};
			}).ToList();

		}

		private ResolutionsPerAuthorityStatusCode GetResolutionsPerAuthorityStatusCode(JObject jObject)
		{
			return new ResolutionsPerAuthorityStatusCode()
			{
				Code = jObject.GetString("code")
			};
		}

		private ResolutionsPerAuthorityValues GetResolutionsPerAuthorityValues(JObject json)
		{
			if (json == null)
				return null;
			var values = json.Value<JArray>("values")?.Children()
					.Select(x => GetResolutionsPerAuthorityValuesValue(x.Value<JObject>()));

			return new ResolutionsPerAuthorityValues(values.ToList());
		}

		private ResolutionsPerAuthorityValuesValue GetResolutionsPerAuthorityValuesValue(JObject jObject)
		{
			var json = jObject.Value<JObject>("value");
			return new ResolutionsPerAuthorityValuesValue()
			{
				Id = json.GetString("id"),
				Name = json.Value<string>("name")
			};
		}

	}
}
