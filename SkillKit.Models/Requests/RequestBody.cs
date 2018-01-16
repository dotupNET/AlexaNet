using AlexaWorld.SkillKit.Objects;

namespace AlexaWorld.SkillKit.Requests
{
	public class RequestBody
	{
		public string Version { get; set; }
		public Session Session { get; set; }
		public Context Context { get; set; }
		public IRequest Request { get; set; }
		public SkillRequest SkillRequest { get; set; }
		public object Json { get; set; }
	}
}
