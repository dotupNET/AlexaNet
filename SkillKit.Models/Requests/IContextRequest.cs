using AlexaWorld.SkillKit.Objects;

namespace AlexaWorld.SkillKit.Requests
{
	public interface IContextRequest: IRequest
	{
		Context Context { get; set; }
	}
}