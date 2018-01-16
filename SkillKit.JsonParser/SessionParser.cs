using AlexaWorld.SkillKit.Objects;
using AlexaWorld.SkillKit.Requests;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AlexaWorld.SkillKit.JsonParser
{
	public class SessionParser
	{
		public Session Parse(SkillRequest SkillRequest, JObject jObject)
		{
			if (jObject == null)
				return null;

			var userParser = new UserParser();
			var user = userParser.Parse(jObject);

			return new Session
			{
				IsNew = jObject.Value<bool>("new"),
				SessionId = jObject.GetString("sessionId"),
				Application = jObject.GetApplication(),
				Attributes = GetAttributes(jObject),
				User = user
			};
		}

		private Dictionary<string, string> GetAttributes(JObject jObject)
		{
			var result = new Dictionary<string, string>();

			var jsonAttributes = jObject.Value<JObject>("attributes");
			if (jsonAttributes == null)
				return result;

			foreach (var item in jsonAttributes.Children())
				result.Add(item.Value<JProperty>().Name, item.Value<JProperty>().Value.ToString());

			return result;
		}
	}
}
