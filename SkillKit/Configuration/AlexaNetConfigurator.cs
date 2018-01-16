using AlexaWorld.SkillKit.Translations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AlexaWorld.SkillKit.Configuration
{
	public class SkillKitConfigurator
	{
		private IServiceProvider serviceProvider;

		public SkillKitConfigurator(IServiceProvider applicationServices)
		{
			this.serviceProvider = applicationServices;
		}

		public void Test()
		{
			var trans = serviceProvider.GetService<ITranslationService>();

			var item = trans.GetRandomText("de", AMAZON.Requests.SessionEndedRequest);

			item = trans.GetText("de-DE", "test");
			item = trans.GetText("de-DE", "testd");

		}

	}
}
