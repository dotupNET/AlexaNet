// Copyright 2017 Peter Ullrich, dotup IT solutions. All rights reserved.

using AlexaWorld.SkillKit.Directives;
using AlexaWorld.SkillKit.Responses;
using AlexaWorld.SkillKit.Responses.Cards;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlexaWorld.SkillKit.Models
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/request-and-response-json-reference.html#response-object
	/// </summary>
	public class Response : IResponse
	{
		/// <summary>
		/// The object containing the speech to render to the user. See OutputSpeech Object.
		/// </summary>
		/// <remarks>
		/// https://developer.amazon.com/de/docs/custom-skills/request-and-response-json-reference.html#outputspeech-object
		/// </remarks>
		public OutputSpeech OutputSpeech { get; set; }

		public void AddDirective(IDirective directive)
		{
			if (Directives == null)
				Directives = new List<IDirective>();
			Directives.Add(directive);
		}

		public void SetPlainText(string text)
		{
			OutputSpeech = text;
		}

		public void SetSsmlText(string text)
		{
			OutputSpeech = new SsmlOutputSpeech(text);
		}

		/// <summary>
		/// The object containing a card to render to the Amazon Alexa App. See Card Object.
		/// </summary>
		/// <remarks>
		/// https://developer.amazon.com/de/docs/custom-skills/request-and-response-json-reference.html#card-object
		/// </remarks>
		public Card Card { get; set; }

		/// <summary>
		/// The object containing the outputSpeech to use if a re-prompt is necessary.
		/// </summary>
		public Reprompt Reprompt { get; set; }

		/// <summary>
		/// A boolean value with true meaning that the session should end after Alexa speaks the response, or false if the session should remain active. If not provided, defaults to true.
		/// </summary>
		public bool ShouldEndSession { get; set; } = true;

		/// <summary>
		/// An array of directives specifying device-level actions to take using a particular interface, such as the AudioPlayer interface for streaming audio.
		/// </summary>
		/// <remarks>
		/// https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html
		/// https://developer.amazon.com/docs/custom-skills/videoapp-interface-reference.html
		/// https://developer.amazon.com/docs/custom-skills/display-interface-reference.html
		/// https://developer.amazon.com/docs/custom-skills/dialog-interface-reference.html
		/// </remarks>
		public List<IDirective> Directives { get; set; }


		public static Task<Response> FromTextAsync(string text)
		{
			return Task.FromResult<Response>(text);
		}

		public static implicit operator Response(string outputSpeech)
		{
			var result = new Response() { OutputSpeech = outputSpeech };
			return result;
		}

		//public static implicit operator Response(ResponseBuilder responseBuilder)
		//{
		//	return responseBuilder.Build() as Response;
		//}

	}
}