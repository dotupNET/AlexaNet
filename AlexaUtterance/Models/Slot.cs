using System;
using System.Collections.Generic;
using System.Text;

namespace dotup.Alexa
{
	public class Slot
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public List<string> Synonyms { get; set; }
	}
}
