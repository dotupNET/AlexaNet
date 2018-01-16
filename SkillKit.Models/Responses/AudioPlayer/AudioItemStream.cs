namespace AlexaWorld.SkillKit.Responses.AudioPlayer
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#play
	/// </summary>
	public class AudioItemStream
	{
		public string Url { get; set; }

		public string Token { get; set; }

		public string ExpectedPreviousToken { get; set; }

		public long OffsetInMilliseconds { get; set; }
	}
}