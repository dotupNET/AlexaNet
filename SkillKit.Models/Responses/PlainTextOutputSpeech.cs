// Copyright 2017 Peter Ullrich, dotup IT solutions. All rights reserved.

namespace AlexaWorld.SkillKit.Models
{
	public class PlainTextOutputSpeech : OutputSpeech
	{
		public PlainTextOutputSpeech()
		{ }

		public PlainTextOutputSpeech(string text)
		{
			Text = text;
		}

		public override string Type
		{
			// TODO: AMAZON
			get { return "PlainText"; }
		}

		public static implicit operator PlainTextOutputSpeech(string text)
		{
			return new PlainTextOutputSpeech()
			{
				Text = text
			};
		}
	}
}