using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using dotup.Alexa;

namespace dotup.Alexa
{
	class Program
	{

		static void Main(string[] args)
		{
			string[] str ={ 
				"was (|die) Klasse {klasse} (ist|bedeutet|sein soll)",
			 	"(|wer|wann) (die|in|das) klasse {klasse} gewonnen (|hat)"
			};
			var parser = new UtteranceParser();
			var result = parser.Parse(str.ToList());

			var generator = new UtteranceGenerator();
			generator.Generate(result);

			var slotti = new SlotGenerator();
			var slots = slotti.Generate(result.First().Parts);
			var x = result;
		}

	}
}