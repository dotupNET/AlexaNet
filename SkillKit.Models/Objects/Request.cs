using AlexaWorld.SkillKit.Requests;
using System;

namespace AlexaWorld.SkillKit.Objects
{
	// TODO: rename?
	/// <summary>
	/// https://developer.amazon.com/de/docs/custom-skills/request-types-reference.html
	/// </summary>
	public class Request : IRequest
	{
		public string Type { get; set; }

		public DateTime Timestamp { get; set; }

		public string RequestId { get; set; }

		public string Locale { get; set; }
	}
}
