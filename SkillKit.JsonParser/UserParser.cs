using AlexaWorld.SkillKit.Objects;
using Newtonsoft.Json.Linq;

namespace AlexaWorld.SkillKit.JsonParser
{
	public class UserParser
	{
		public User Parse(JObject jObject)
		{
			var json = jObject.Value<JObject>("user");
			if (json == null)
				return null;

			return new User
			{
				UserId = json.GetString("userId"),
				AccessToken = json.GetString("accessToken"),
				Permissions = GetUserPermissions(json.Value<JObject>("permissions"))
			};
		}

		private UserPermissions GetUserPermissions(JObject jObject)
		{
			if (jObject == null)
				return null;

			return new UserPermissions()
			{
				ConsentToken = jObject.GetString("consentToken")
			};
		}
	}
}
