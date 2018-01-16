using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace dotup.Alexa
{
	public class UtteranceParser
	{
		public List<Utterance> Parse(List<string> str)
		{
			var result = new List<Utterance>();
			foreach (var item in str)
			{
				var utterance = new Utterance(item);
				utterance.Parts = Parse(item);
				result.Add(utterance);
			}
			return result;
		}

		public List<UtterancePart> Parse(string str)
		{
			var current = new UtterancePart(PartType.PlainWord);
			var next = new UtterancePart();
			var result = new List<UtterancePart>();
			int pos = 0;
			int index = 0;

			foreach (Match m in Regex.Matches(str, "[{()}]"))
			{
				var content = str.Substring(pos, m.Index - pos);

				switch (m.Value)
				{
					case "(":
						next = new UtterancePart(PartType.WordList);
						break;
					case "{":
						next = new UtterancePart(PartType.Slot);
						break;
					case "}":
						current.Value = content;
						break;
					case ")":
						current.Value = content;
						break;

					default:
						throw new Exception("What?");

				}

				// The first part
				if (pos == 0 && current.Type == PartType.PlainWord)
					current.Value = content;

				// If current is null we've plain text, the switch statement has no next generated
				if (current == null)
				{
					current = new UtterancePart(PartType.PlainWord);
					current.Value = content;
				}

				// Skip empty parts like " "
				if (!(current.Type == PartType.PlainWord && string.IsNullOrEmpty(current.Value.Trim())))
				{
					current.Index = index++;
					result.Add(current);
				}

				// in the next loop we get the content. Next is unknown
				current = next;
				next = null;

				pos = m.Index + m.Length;
			}

			// There are some unprocessed words. Musst be plain text
			if (pos < str.Length)
				result.Add(new UtterancePart(PartType.PlainWord, str.Substring(pos, str.Length - pos)));
			return result;
		}
	}
}