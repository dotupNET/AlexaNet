namespace AlexaWorld.SkillKit.Directives
{
	/// <summary>
	/// https://developer.amazon.com/de/docs/custom-skills/request-and-response-json-reference.html#system-object
	/// </summary>
	public class AudioPlayerInterface : ISupportedInterface
	{
		public InterfaceType Type => InterfaceType.AudioPlayer;
	}
}