using AlexaWorld.SkillKit.Models;
using System.Collections.Generic;

namespace AlexaWorld.SkillKit.Responses
{
	public class ResponseBody
	{
		public string Version { get; set; }
		public IResponse Response { get; set; }
		public Dictionary<string, string> SessionAttributes { get; set; }
	}
}
