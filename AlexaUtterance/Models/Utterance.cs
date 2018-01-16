using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace dotup.Alexa
{
	[DebuggerDisplay("{Sentence}")]
	public class Utterance
	{
		public Utterance()
		{		}
		public Utterance(string sentence)
		{
			Sentence = sentence;
		}
		public string Sentence { get; set; }
		public List<UtterancePart> Parts { get; set; }
		public List<string> Utterances { get; internal set; }
	}
}
