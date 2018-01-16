using AlexaWorld.SkillKit.AlexaRequests;
using AlexaWorld.SkillKit.AlexaSessions;
using AlexaWorld.SkillKit.Configuration;
using AlexaWorld.SkillKit.Exceptions;
using AlexaWorld.SkillKit.Translations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AlexaWorld.SkillKit.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static void AddSkillKit(this IServiceCollection services, Action<SkillKitServiceConfigurator> config)
		{
			services.AddScoped<ISessionManager, SessionManager>();

			services.AddSingleton<ITranslationService, ConfigTranslationService>();

			// Request
			services.AddScoped<ISkillRequestProcessor, SkillRequestProcessor>();

			services.AddSingleton<IRequestBuilder, RequestBuilder>();

			services.AddSingleton<ISkillExceptionHandler, DebugExceptionHandler>();

			var cfg = new SkillKitServiceConfigurator(services);
			config(cfg);
		}

	}
}

//private static ITextManager InitializeTextManager()
//{
//	var items = new List<string>()
//	{
//		"Auf Wiedersehen!",
//		"Danke!",
//		"Bis demnächst!",
//		"Bis zum nächsten Mal!",
//		"Gerne wieder!",
//		"Tschau!",
//		"Ok!",
//		"Bitte sehr!",
//		"Tschüß!",
//		"<say-as interpret-as='interjection'>ade</say-as>",
//		"<say-as interpret-as='interjection'>alles klar</say-as>",
//		"<say-as interpret-as='interjection'>bis bald</say-as>",
//		"<say-as interpret-as='interjection'>bis dann</say-as>",
//		"<say-as interpret-as='interjection'>macht\"s gut</say-as>",
//		"<say-as interpret-as='interjection'>tschö</say-as>"
//	};

//	var tm = new TextManager();
//	tm.Add("de-DE", new TextList("LaunchRequest", items));

//	return tm;
//}
