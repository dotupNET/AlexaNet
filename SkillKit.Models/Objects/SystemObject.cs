
namespace AlexaWorld.SkillKit.Objects
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/request-and-response-json-reference.html#system-object
	/// </summary>
	public class SystemObject
	{
		public string ApiAccessToken { get; set; }

		public string ApiEndpoint { get; set; }

		public Application Application { get; set; }

		public Device Device { get; set; }

		public User User { get; set; }
	}
}