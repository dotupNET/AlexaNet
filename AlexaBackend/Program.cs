using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AlexaBackend
{
	public class Program
	{
		public static void Main(string[] args)
		{
			TelemetryConfiguration.Active.DisableTelemetry = true;
			var webhost = BuildWebHost(args);
			webhost.Run();
			webhost.Dispose();
		}

		public static IWebHost BuildWebHost(string[] args) =>
				WebHost.CreateDefaultBuilder(args)
					.ConfigureAppConfiguration(SetAppConfiguration)
					.UseStartup<Startup>()
					.Build();


		private static void SetAppConfiguration(WebHostBuilderContext context, IConfigurationBuilder configurationBuilder)
		{
			var env = context.HostingEnvironment;

			configurationBuilder
				.AddJsonFile(
					"appsettings.json",
					optional: true,
					reloadOnChange: true)
				.AddJsonFile(
					$"appsettings.{env.EnvironmentName}.json",
					optional: true,
					reloadOnChange: true)
				.AddJsonFile(
					$"TextLibrary.json",
					optional: true,
					reloadOnChange: true);

			configurationBuilder.AddEnvironmentVariables();
		}
	}
}
