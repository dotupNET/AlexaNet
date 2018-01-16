using System;

namespace AlexaWorld.SkillKit.Requests
{
	public interface IRequest
	{
		string Locale { get; set; }
		string RequestId { get; set; }
		DateTime Timestamp { get; set; }
		string Type { get; set; }
	}
}