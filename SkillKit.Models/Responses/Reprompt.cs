// Copyright 2017 Peter Ullrich, dotup IT solutions. All rights reserved.

namespace AlexaWorld.SkillKit.Models
{
	/// <summary>
	/// An OutputSpeech object containing the text or SSML to render as a re-prompt.
	/// 
	/// This object can only be included when sending a response to a LaunchRequest or IntentRequest.
	/// </summary>
	/// <remarks>
	/// https://developer.amazon.com/de/docs/custom-skills/request-and-response-json-reference.html#reprompt-object
	/// </remarks>
	public class Reprompt
	{
		public OutputSpeech OutputSpeech { get; set; }
	}
}