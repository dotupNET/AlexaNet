using AlexaWorld.SkillKit.Directives;

namespace AlexaWorld.SkillKit.Responses.AudioPlayer.Directives
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#clearqueue
	/// </summary>
	public class AudioPlayerClearQueueDirective : Directive
	{
		public AudioPlayerClearQueueDirective() : 
			base(AMAZON.AudioPlayerDirectives.AudioPlayerClearQueue)
		{ }

		public ClearBehaviorEnum ClearBehavior { get; set; }

		public enum ClearBehaviorEnum
		{
			CLEAR_ENQUEUED,
			CLEAR_ALL
		}
	}
}