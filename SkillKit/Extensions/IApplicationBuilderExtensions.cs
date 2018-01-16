using AlexaWorld.SkillKit.Configuration;
using Microsoft.AspNetCore.Builder;
using System;

namespace AlexaWorld.SkillKit.Extensions
{
	public static class IApplicationBuilderExtensions
	{
		public static void UseSkillKit()
		{ }

		public static void UseSkillKit(this IApplicationBuilder app, Action<SkillKitConfigurator> config)
		{
			var cfg = new SkillKitConfigurator(app.ApplicationServices);
			config(cfg);
		}
	}
}
