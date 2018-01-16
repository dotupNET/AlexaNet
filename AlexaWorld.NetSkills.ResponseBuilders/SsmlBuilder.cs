using System;
using System.Collections.Generic;
using System.Text;
using static AlexaWorld.SkillKit.Ssml;

namespace AlexaWorld.NetSkills.ResponseBuilders
{
	public class SsmlBuilder : IResponseBuilder<string>
	{
		private Stack<string> stack;

		private readonly StringBuilder textToSpeak;

		public SsmlBuilder()
		{
			this.textToSpeak = new StringBuilder();
			this.stack = new Stack<string>();
		}

		public SsmlBuilder AddText(string text)
		{
			textToSpeak.AppendLine(text);
			return this;
		}

		public SsmlBuilder Whisper()
		{
			textToSpeak.AppendLine("<amazon:effect name=\"whispered\">");
			stack.Push("</amazon:effect>");

			return this;
		}

		public SsmlBuilder Whisper(string text)
		{
			var formated = $"<amazon:effect name=\"whispered\">{text}</amazon:effect>";
			textToSpeak.AppendLine(formated);
			return this;
		}

		public string GetWhisperedText(string text)
		{
			var formated = $"<amazon:effect name=\"whispered\">{text}</amazon:effect>";
			return formated;
		}

		public SsmlBuilder AddSsml(string ssml)
		{
			textToSpeak.AppendLine(ssml);
			return this;
		}

		public SsmlBuilder Break(TimeSpan duration)
		{
			var milliseconds = duration.TotalMilliseconds;

			if (milliseconds > 10000)
				throw new ArgumentOutOfRangeException("milliseconds > 10000");

			var text = $"<break time=\"{milliseconds}ms\"/>";
			textToSpeak.AppendLine(text);
			return this;
		}

		public SsmlBuilder Break(BreakStrength strength)
		{
			var value = strength.ToString().Replace("_", "-");
			var text = $"<break strength=\"{value}\"/>";
			textToSpeak.AppendLine(text);
			return this;
		}

		public SsmlBuilder Emphasize(string text, EmphasisLevel level)
		{
			var formated = $"<emphasis level=\"{level.ToString()}\">{text}</emphasis>";
			textToSpeak.AppendLine(formated);
			return this;
		}

		public SsmlBuilder Emphasize(EmphasisLevel level)
		{
			textToSpeak.AppendLine($"<emphasis level=\"{level.ToString()}\">");
			stack.Push("</emphasis>");
			return this;
		}

		public SsmlBuilder Paragraph(string text)
		{
			var formated = $"<p>{text}</p>";
			textToSpeak.AppendLine(formated);
			return this;
		}

		public SsmlBuilder Rate(string text, ProsodyRate rate)
		{
			textToSpeak.AppendLine(Prosody("rate", rate.ToString(), text));
			return this;
		}

		public SsmlBuilder Rate(ProsodyRate rate)
		{
			textToSpeak.AppendLine(GetProsodyStart("rate", rate.ToString()));
			stack.Push("</prosody>");
			return this;
		}

		public SsmlBuilder Pitch(string text, ProsodyPitch pitch)
		{
			textToSpeak.AppendLine(Prosody("pitch", pitch.ToString(), text));
			return this;
		}

		public SsmlBuilder Pitch(ProsodyPitch pitch)
		{
			textToSpeak.AppendLine(GetProsodyStart("pitch", pitch.ToString()));
			stack.Push("</prosody>");
			return this;
		}

		public SsmlBuilder WithVolume(string text, ProsodyVolume volume)
		{
			textToSpeak.AppendLine(Prosody("volume", volume.ToString(), text));
			return this;
		}

		public SsmlBuilder Volume(ProsodyVolume volume)
		{
			textToSpeak.AppendLine(GetProsodyStart("volume", volume.ToString()));
			stack.Push("</prosody>");
			return this;
		}

		public SsmlBuilder AddSentence(string text)
		{
			var formated = $"<s>{text}</s>";
			textToSpeak.AppendLine(formated);
			return this;
		}

		public SsmlBuilder SayAs(string text, SayAsInterpreter interpreter)
		{
			var interpretAs = interpreter.ToString().Replace("_", "-");
			var formated = $"<say-as interpret-as=\"{interpretAs}\">{text}</say-as>";
			textToSpeak.AppendLine(formated);
			return this;
		}

		private string Prosody(string key, string value, string text)
		{
			value = value.ToString().Replace("_", "-");
			var formated = $"<prosody {key}=\"{value}\">{text}</prosody>";
			return formated;
		}

		public SsmlBuilder CloseAllEffects()
		{
			while (stack.Count > 0)
				CloseEffect();
			return this;
		}

		public SsmlBuilder CloseEffect()
		{
			if (stack.Count < 1)
				return this;

			var closingProsody = stack.Pop();
			if (!string.IsNullOrEmpty(closingProsody))
				textToSpeak.AppendLine(closingProsody);
			return this;
		}

		private string GetProsodyStart(string key, string value)
		{
			value = value.ToString().Replace("_", "-");
			var formated = $"<prosody {key}=\"{value}\">";
			return formated;
		}

		public string Build()
		{
			CloseAllEffects();
			return $"<speak>{textToSpeak.ToString()}</speak>";
		}
	}
}