using AlexaWorld.SkillKit.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlexaWorld.SkillKit.Translations
{
	public class ConfigTranslationService : ITranslationService
	{
		private IConfiguration configuration;

		public ConfigTranslationService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public string GetText(string locale, string textListKey)
		{
			var section = GetSection(locale, textListKey);
			return section.Value;
		}

		public string GetRandomText(string locale, string textListKey)
		{
			var list = GetList(locale, textListKey);

			if (list == null)
				return string.Empty;

			var index = new Random().Next(list.Count - 1);
			return list[index];
		}

		private List<string> GetList(string locale, string textListKey)
		{
			var section = GetSection(locale, textListKey);

			if (section == null)
				return new List<string>();

			return section.AsEnumerable().Where(item => !string.IsNullOrEmpty(item.Value)).Select(item => item.Value).ToList();
		}

		private IConfigurationSection GetSection(string locale, string textListKey)
		{
			var section = configuration.GetSection($"{locale}:{textListKey}");

			if (section == null || section.GetChildren().Count() <= 0)
			{
				var partialLocale = locale.Substring(0, locale.IndexOf("-"));
				section = configuration.GetSection($"{partialLocale}:{textListKey}");
			}
			return section;
		}

	}
}
