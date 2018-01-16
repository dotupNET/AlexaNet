// Copyright 2017 Peter Ullrich, dotup IT solutions. All rights reserved.

namespace AlexaWorld.SkillKit.Models
{
	/// <summary>
	/// https://developer.amazon.com/de/docs/custom-skills/request-and-response-json-reference.html#outputspeech-object
	/// </summary>
	public partial class OutputSpeech
	{
		/// <summary>
		/// "PlainText": Indicates that the output speech is defined as plain text.
		/// "SSML": Indicates that the output speech is text marked up with SSML.
		/// </summary>
		/// <remarks>Keep it as property for serialization</remarks>
		public virtual string Type { get; set; }

		/// <summary>
		/// A string containing the speech to render to the user. Use this when type is "PlainText"
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// A string containing text marked up with SSML to render to the user.Use this when type is "SSML"
		/// </summary>
		public string Ssml { get; set; }

		public static implicit operator OutputSpeech(string text)
		{
			return new PlainTextOutputSpeech()
			{
				Text = text
			};
		}

		//public static implicit operator OutputSpeech(SsmlBuilder ssmlBuilder)
		//{
		//	return new SsmlOutputSpeech(ssmlBuilder.ToString());
		//}
	}
}