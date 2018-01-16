using AlexaWorld.SkillKit.Objects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace AlexaWorld.SkillKit.JsonParser
{
	public static class JObjectExtensions
	{

		public static string GetString(this JObject jObject, string name)
		{
			return jObject.Value<string>(name);
		}

		public static Application GetApplication(this JObject jObject)
		{
			var json = jObject.Value<JObject>("application");
			if (json == null)
				return null;

			return new Application()
			{
				ApplicationId = json.GetString("applicationId")
			};
		}

		// TODO Parser
		public static Intent GetIntent(this JObject jObject)
		{
			var jIntent = jObject.Value<JObject>("intent");
			if (jIntent == null)
				return null;

			var sp = new SlotParser();

			var slots = sp.Parse(jIntent);

			Enum.TryParse<ConfirmationStatusEnum>(jIntent.GetString("confirmationStatus"), out var confirmationStatus);

			return new Intent
			{
				Name = jIntent.GetString("name"),
				ConfirmationStatus = confirmationStatus,
				Slots = slots ?? new Dictionary<string, Slot>()
			};
		}


	}
}
