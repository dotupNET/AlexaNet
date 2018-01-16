using AlexaWorld.SkillKit.Models;
using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.Responses;
using System.Threading.Tasks;

namespace AlexaWorld.SkillKit.AlexaRequests
{
	public interface IRequestHandler<T> where T : IRequest
	{
		Task<IResponse> Handle(T request);
	}
}
