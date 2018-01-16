using System;

namespace AlexaWorld.SkillKit.Requests
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#requests
	/// </summary>
	public class AudioPlayerRequest : ContextRequest //ExtendedSpeechletRequest
	{
		public string Token { get; set; }

		public long OffsetInMilliseconds { get; set; }
	}
}