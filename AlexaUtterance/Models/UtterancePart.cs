using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace dotup.Alexa
{
	[DebuggerDisplay("{Type}, {Value}")]
	public class UtterancePart
	{
		public UtterancePart()
		{ }

		public UtterancePart(PartType itemType)
		{
			this.Type = itemType;
		}

		public UtterancePart(PartType itemType, string value) : this(itemType)
		{
			this.Value = value;
		}

		public PartType Type { get; set; }
		public string Value { get; set; }
		public int Index { get; set; }

		internal List<string> SplitValue(string v)
		{
			switch (Type)
			{
				case PartType.PlainWord:
					return new List<string>() { this.Value.Trim() };
				case PartType.Slot:
					return new List<string>() { $"{{{this.Value}}}" };
				case PartType.WordList:
					return this.Value.Split(v).Select(item => item.Trim()).ToList();
			}
			throw new Exception();
		}
	}

}
