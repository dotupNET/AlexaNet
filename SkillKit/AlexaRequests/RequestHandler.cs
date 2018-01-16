using AlexaWorld.SkillKit.Models;
using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.Responses;
using AlexaWorld.SkillKit.Translations;
using System.Threading.Tasks;

namespace AlexaWorld.SkillKit.AlexaRequests
{
	public class RequestHandler<T> : IRequestHandler<T>
		where T : IRequest
	{
		private ITranslationService translationService;

		public RequestHandler(ITranslationService translationService)
		{
			this.translationService = translationService;
		}

		public async Task<IResponse> Handle(T request)
		{
			var message = translationService.GetRandomText(request.Locale, request.Type);

			// TODO No message handling
			var response = new Response()
			{
				OutputSpeech = new SsmlOutputSpeech(message)
			};
			var x = await Task.FromResult(response);
			return x;
		}

	}
}
