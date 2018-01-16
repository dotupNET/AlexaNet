using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Primitives;

namespace AlexaWorld.SkillKit.Requests
{
	public class SkillRequest
	{
		public Stream Body { get; set; }
		public string QueryString { get; set; }
		public List<KeyValuePair<string, StringValues>> Headers { get; set; }
		public List<KeyValuePair<string, string>> Cookies { get; set; }
		public string Host { get; set; }
	}
}