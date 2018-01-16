using AlexaWorld.SkillKit.AlexaRequests;
using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.SkillResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AlexaWorld.SkillKit
{
	[Route("api/alexa")]
	public class AlexaController : Controller
	{
		private ISkillRequestProcessor alexaRequestHandler;

		public AlexaController(ISkillRequestProcessor alexaRequestHandler)
		{
			this.alexaRequestHandler = alexaRequestHandler;
		}

		[HttpPost]
		public async Task<ISkillResult> AlexaIsRequesting()
		{
			var alexaRequest = new SkillRequest()
			{
				Body = Request.Body,
				QueryString = Request.QueryString.ToString(),
				Headers = Request.Headers.ToList(),
				Cookies = Request.Cookies.ToList(),
				Host = Request.Host.ToString()
			};

			return await alexaRequestHandler.ProcessAsync(alexaRequest);
		}
	}
}
