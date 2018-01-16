
using AlexaWorld.SkillKit.Directives;

namespace AlexaWorld.SkillKit.Responses.AudioPlayer.Directives
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#stop
	/// </summary>
	public class AudioPlayerStopDirective : Directive
	{
		public AudioPlayerStopDirective() :
			base(AMAZON.AudioPlayerDirectives.AudioPlayerStop)
		{ }
	}
}