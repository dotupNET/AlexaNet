using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaWorld.SkillKit.Objects
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#playbackfailed
	/// </summary>
	public class PlaybackState
	{
		public string Token { get; set; }
		public long? OffsetInMilliseconds { get; set; }
		public PlayerActivityEnum PlayerActivity { get; set; }
	}
}
