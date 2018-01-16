// Copyright 2017 Peter Ullrich, dotup IT solutions. All rights reserved.
namespace AlexaWorld.SkillKit.Directives
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/request-and-response-json-reference.html#response-object
	/// </summary>
	public class Directive : IDirective
	{
		public Directive()
		{ }

		public Directive(string type)
		{
			Type = type;
		}

		public string Type { get; set; }
	}
}