using AlexaWorld.SkillKit.Objects;

namespace AlexaWorld.SkillKit.Requests
{
	public interface ISessionRequest : IContextRequest
	{
		Session Session { get; set; }
	}
}