using AlexaWorld.SkillKit.Objects;

namespace AlexaWorld.SkillKit.Requests
{
	/// <summary>
	/// Standard request types (LaunchRequest, IntentRequest, and SessionEndedRequest) include the session object.
	/// Requests from interfaces such as AudioPlayer and PlaybackController are not sent in the context of a session, so they do not include the session object. The context.System.user and context.System.application objects provide the same user and application information as the same objects within session – see Context Object.
	/// </summary>
	public class SessionRequest : ContextRequest, ISessionRequest
	{
		public Session Session { get; set; }
	}
}
