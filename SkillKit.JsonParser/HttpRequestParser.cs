using AlexaWorld.SkillKit.Objects;
using AlexaWorld.SkillKit.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace AlexaWorld.SkillKit.JsonParser
{
	public class HttpRequestParser
	{
		private static JsonSerializerSettings DeserializationSettings = new JsonSerializerSettings()
		{
			MissingMemberHandling = MissingMemberHandling.Ignore
		};

		public RequestBody Parse(SkillRequest SkillRequest)
		{
			var sr = new StreamReader(SkillRequest.Body, Encoding.UTF8);
			var content = sr.ReadToEnd();

			Guard.NotNullOrEmpty(content, "Request content is empty");

			var jObject = JsonConvert.DeserializeObject<JObject>(content, DeserializationSettings);

			// Version
			var version = jObject.GetString("version");

			// Session
			var sessionParser = new SessionParser();
			var session = sessionParser.Parse(SkillRequest, jObject.Value<JObject>("session"));

			// Context
			var contextParser = new ContextParser();
			var context = contextParser.Parse(SkillRequest, jObject.Value<JObject>("context"));

			// REquest
			var requestParser = new RequestParser();
			Request request = requestParser.Parse(SkillRequest, jObject.Value<JObject>("request"));

			return new RequestBody()
			{
				Version = version,
				Session = session,
				Context = context,
				Request = request,
				SkillRequest = SkillRequest,
				Json = jObject
			};
		}
	}
}
