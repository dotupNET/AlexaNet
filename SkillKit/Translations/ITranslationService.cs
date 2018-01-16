using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaWorld.SkillKit.Translations
{
	public interface ITranslationService
	{
		string GetRandomText(string locale, string textListKey);
		string GetText(string locale, string textListKey);
	}
}
