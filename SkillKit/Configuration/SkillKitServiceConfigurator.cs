using AlexaWorld.SkillKit.AlexaRequests;
using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.Translations;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace AlexaWorld.SkillKit.Configuration
{
	public class SkillKitServiceConfigurator
	{
		private IServiceCollection serviceCollection;

		public SkillKitServiceConfigurator(IServiceCollection serviceCollection)
		{
			this.serviceCollection = serviceCollection;
		}

		public void AddDefaultRequestHandler()
		{
			// AMAZON.Requests.LaunchRequest
			Add<LaunchRequest>();

			// AMAZON.Requests.SessionStartedRequest
			Add<SessionStartedRequest>();

			// AMAZON.Requests.SessionEndedRequest
			Add<SessionEndedRequest>();

			// AMAZON.Requests.AudioPlayer
			//Add<AudioPlayerRequest>();

			// AMAZON.Requests.AudioPlayerPlaybackFailed
			//Add<AudioPlayerPlaybackFailedRequest>();

			// AMAZON.Requests.AudioPlayerPlaybackFailed
			//Add<PlaybackControllerRequest>();

			// AMAZON.Requests.Display
			//Add<DisplayRequest>();

			// AMAZON.Requests.SystemExceptionEncountered
			//Add<SystemExceptionEncounteredRequest>();
		}

		public void RemoveRequestHandlerFor<T>()
			where T : IRequest
		{
			var services = serviceCollection.ToList();
			var handler = services.Where(item => item.ImplementationType == typeof(RequestHandler<T>)).ToList();

			foreach (var item in handler)
				serviceCollection.Remove(item);
		}

		public void RemoveRequestHandler<T>() where T : IRequestHandler<IRequest>
		{
			var services = serviceCollection.ToList();
			var handler = services.Where(item => item.ServiceType == typeof(T)).ToList();

			foreach (var item in handler)
				serviceCollection.Remove(item);
		}

		public void OverrideRequestHandler<TRequest, TRequestHandler>()
			where TRequest : IRequest
			where TRequestHandler : class, IRequestHandler<TRequest>
		{
			// Remove default if
			RemoveRequestHandlerFor<TRequest>();

			// Add custom handler
			serviceCollection.AddScoped<IRequestHandler<TRequest>, TRequestHandler>();
		}

		public void AddDefaultTranslationService()
		{
			serviceCollection.AddSingleton<ITranslationService, ConfigTranslationService>();
		}

		private void Add<T>() where T : IRequest
		{
			serviceCollection.AddSingleton<IRequestHandler<T>, RequestHandler<T>>();
		}
	}
}
