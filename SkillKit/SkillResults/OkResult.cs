using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AlexaWorld.SkillKit.SkillResults
{
	public class OkResult : ContentResult, ISkillResult
	{
		public OkResult(string jsonContent)
		{
			Content = jsonContent;
			ContentType = "application/json";
			StatusCode = (int)HttpStatusCode.OK;
		}
	}
}