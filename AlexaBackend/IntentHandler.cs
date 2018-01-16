using AlexaWorld.NetSkills.ResponseBuilders;
using AlexaWorld.SkillKit.AlexaRequests;
using AlexaWorld.SkillKit.Models;
using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.Responses;
using System.Threading.Tasks;

namespace AlexaBackend
{
	public class IntentHandler : IRequestHandler<IntentRequest>
	{
		public async Task<IResponse> Handle(IntentRequest intentRequest)
		{
			switch (intentRequest.Intent.Name)
			{
				case "":
				default:
					break;
			}
			var rb = new ResponseBuilder(intentRequest.Context);
			rb.Ssml(builder =>
			{
				builder.AddSentence("Hallo");
			});
			//var response = new Response()
			//{
			//	OutputSpeech = new PlainTextOutputSpeech(intentRequest.Intent.Name)
			//};
			var x = await rb.BuildAsync();
			return x;
		}
	}
}
