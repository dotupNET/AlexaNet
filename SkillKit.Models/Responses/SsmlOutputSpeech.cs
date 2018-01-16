// Copyright 2017 Peter Ullrich, dotup IT solutions. All rights reserved.


namespace AlexaWorld.SkillKit.Models
{
	public class SsmlOutputSpeech : OutputSpeech
	{
		public SsmlOutputSpeech()
		{ }

		public SsmlOutputSpeech(string text)
		{
			this.Ssml = text;
		}

		public override string Type
		{
			get { return "SSML"; }
		}
	}
}