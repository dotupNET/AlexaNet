using System;
using System.Collections.Generic;
using System.Linq;

namespace dotup.Alexa
{

	public class UtteranceGenerator
	{

		private class Wrapper
		{
			public Wrapper(List<string> items)
			{
				this.Items = items;
				this.CurrentIndex = 0;
			}

			public int CurrentIndex { get; set; }

			public List<string> Items { get; set; }

			public string GetItem()
			{
				return this.Items[CurrentIndex++];
			}
		}

		public void Generate(List<Utterance> utterances)
		{
			foreach (var item in utterances)
			{
				item.Utterances = Generate(item.Parts);
			}
		}

		//public List<string> Generate(List<Utterance> utterances)
		//{
		//	var result = new List<string>();
		//	foreach (var item in utterances)
		//	{
		//		result.AddRange(Generate(item.Parts));
		//	}
		//	return result;
		//}

		public List<string> Generate(List<UtterancePart> parts)
		{
			var result = new List<string>();
			var holyMoly = parts.Select(xd => xd.SplitValue("|").ToList()).ToList();

			var utteranceList = CartesianProduct<string>(holyMoly);
			foreach (var item in utteranceList)
			{
				var set = item.ToList();
				var sentence = string.Join(" ", set).Replace("  ", " ");
				result.Add(sentence.Trim());
			}

			return result;
		}

		private IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences)
		{
			IEnumerable<IEnumerable<T>> emptyList = new[] { Enumerable.Empty<T>() };
			return sequences.Aggregate(
				emptyList,
				(accumulator, sequence) =>
					from accu in accumulator
					from seq in sequence
					select accu.Concat(new[] { seq }));
		}
	}
}