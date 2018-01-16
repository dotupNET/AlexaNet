using AlexaWorld.SkillKit.Objects;
using AlexaWorld.SkillKit.Requests;
using Newtonsoft.Json.Linq;

namespace AlexaWorld.SkillKit.JsonParser
{
	public class RequestParser
	{
		internal Request Parse(SkillRequest SkillRequest, JObject jObject)
		{
			if (jObject == null)
				return null;

			return new Request()
			{
				Type = jObject.GetString("type"),
				Timestamp = AlexaDate.FromString(jObject.GetString("timestamp")),
				RequestId = jObject.GetString("requestId"),
				Locale = jObject.GetString("locale")
			};
		}

	}
}
