using AlexaWorld.SkillKit.Extensions;
using AlexaWorld.SkillKit.Requests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AlexaBackend
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// MVC
			services.AddMvc();


			// Logging
			services.AddLogging(o =>
			{
				o.AddDebug();
			});

			// Add AlexaWorld.SkillKit. default request handler services
			services.AddSkillKit(config =>
			{
				config.AddDefaultTranslationService();
				config.AddDefaultRequestHandler();

				// Override built in handler
				config.OverrideRequestHandler<LaunchRequest, LaunchRequestHandler>();
				config.OverrideRequestHandler<IntentRequest, IntentHandler>();

				// Register for all requests, remove concrete handlers first
				//config.RemoveRequestHandlerFor<LaunchRequest>();
				//config.OverrideRequestHandler<IRequest, InterfaceRequestHandler>();
			}
			);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{		
			app.UseSkillKit(config =>
			{
				config.Test();
			});
			app.UseMvc();
		}

	}
}
