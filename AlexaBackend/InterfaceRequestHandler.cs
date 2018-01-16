using AlexaWorld.SkillKit.AlexaRequests;
using AlexaWorld.SkillKit.Models;
using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.Responses;
using System.Threading.Tasks;

namespace AlexaBackend
{
	public class InterfaceRequestHandler : IRequestHandler<IRequest>
	{
		public async Task<IResponse> Handle(IRequest request)
		{
			return await Response.FromTextAsync("OK");
		}
	}
}
