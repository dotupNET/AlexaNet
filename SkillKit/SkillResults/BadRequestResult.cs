using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AlexaWorld.SkillKit.SkillResults
{
	public class BadRequestResult : ContentResult,ISkillResult
	{
		public BadRequestResult(string alexaResponse)
		{
			Content = alexaResponse;
			ContentType = "text/plain";
			StatusCode = (int)HttpStatusCode.BadRequest;
		}
	}
}