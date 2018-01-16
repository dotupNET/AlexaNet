using AlexaWorld.SkillKit.AlexaSessions;
using AlexaWorld.SkillKit.Exceptions;
using AlexaWorld.SkillKit.Json;
using AlexaWorld.SkillKit.JsonParser;
using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.SkillResults;
using System;
using System.Threading.Tasks;

namespace AlexaWorld.SkillKit.AlexaRequests
{
	public class SkillRequestProcessor : ISkillRequestProcessor
	{
		private IServiceProvider serviceProvider;
		private ISkillExceptionHandler exceptionHandler;
		private ISessionManager sessionManager;
		private IRequestBuilder requestBuilder;

		public SkillRequestProcessor(
			ISessionManager sessionManager,
			IRequestBuilder requestBuilder,
			IServiceProvider serviceProvider,
			ISkillExceptionHandler exceptionHandler)
		{
			this.sessionManager = sessionManager;
			this.requestBuilder = requestBuilder;
			this.serviceProvider = serviceProvider;
			this.exceptionHandler = exceptionHandler;
		}

		public async Task<ISkillResult> ProcessAsync(SkillRequest alexaRequest)
		{
			IRequest request = default(IRequest);

			try
			{
				request = GetRequest(alexaRequest);
				string response = await ProcessRequestAsync(request);

				return new OkResult(response);
			}
			catch (Exception ex)
			{
				return exceptionHandler.Handle(ex, request);
			}
		}

		private IRequest GetRequest(SkillRequest alexaRequest)
		{
			var parser = new HttpRequestParser();
			var request = parser.Parse(alexaRequest);
			var concreteRequest = requestBuilder.Build(request);
			return Guard.ExceptionWhenNull(concreteRequest);
		}

		private async Task<string> ProcessRequestAsync(IRequest request)
		{
			Guard.ArgumentNotNull(request, nameof(request));
			sessionManager.Initialize(request as SessionRequest);

			var handler = new RequestHandlerFactoryWrapper();
			var response = await handler.Execute(serviceProvider, request);

				// TODO				Version,
			// Build response
			var resultBuilder = new SkillResultBuilder();
			var jsonResult = resultBuilder.Build(response, sessionManager.Session?.Attributes);

			return Guard.ExceptionWhenNull(jsonResult);
		}

	}
}
