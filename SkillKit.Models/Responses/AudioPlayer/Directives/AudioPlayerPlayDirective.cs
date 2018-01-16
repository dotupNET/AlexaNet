using AlexaWorld.SkillKit.Directives;

namespace AlexaWorld.SkillKit.Responses.AudioPlayer.Directives
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#play
	/// </summary>
	public class AudioPlayerPlayDirective : Directive
	{
		public AudioPlayerPlayDirective() :
			base(AMAZON.AudioPlayerDirectives.AudioPlayerPlay)
		{ }

		public PlayBehaviorEnum PlayBehavior { get; set; }

		public AudioItem AudioItem { get; set; }

		public enum PlayBehaviorEnum
		{
			REPLACE_ALL,
			ENQUEUE,
			REPLACE_ENQUEUED
		}
	}
}