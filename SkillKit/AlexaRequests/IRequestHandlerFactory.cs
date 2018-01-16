using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.Responses;
using System;
using System.Threading.Tasks;

namespace AlexaWorld.SkillKit.AlexaRequests
{
	public interface IRequestHandlerFactory
	{
		dynamic CreateDynamic(Type type);
		Func<IRequest, Task<IResponse>> Create(Type type);
	}
}
