using AlexaWorld.SkillKit.Objects;
using AlexaWorld.SkillKit.Requests;

namespace AlexaWorld.SkillKit.AlexaSessions
{
	public interface ISessionManager
	{
		Session Session { get; }
		bool Initialize(SessionRequest sessionRequest);
	}
}
