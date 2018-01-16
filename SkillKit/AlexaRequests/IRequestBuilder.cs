using AlexaWorld.SkillKit.Requests;

namespace AlexaWorld.SkillKit.AlexaRequests
{
	public interface IRequestBuilder
	{
		IRequest Build(RequestBody requestBody);
	}
}