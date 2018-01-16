namespace AlexaWorld.SkillKit.Objects
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/request-and-response-json-reference.html#context-object
	/// </summary>
	public class Context
	{
		public SystemObject System { get; set; }

		public AudioPlayer AudioPlayer { get; set; }
	}
}