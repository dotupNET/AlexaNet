using System;
using System.Collections.Generic;
using System.Linq;

namespace dotup.Alexa
{
	internal class SlotGenerator
	{
		public SlotGenerator()
		{
		}

		internal List<Slot> Generate(List<UtterancePart> parts)
		{
			var slots = parts.Where(item => item.Type == PartType.Slot);
			var result = slots.Select(item => new Slot() { Id = item.Value, Name = item.Value }).ToList();
			return result;
		}
	}
}