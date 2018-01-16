using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.Responses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AlexaWorld.SkillKit.AlexaRequests
{
	internal class RequestHandlerFactoryWrapper
	{

		public async Task<IResponse> Execute(IServiceProvider serviceProvider, IRequest request)
		{

			var genericType = typeof(RequestHandlerFactory<>).MakeGenericType(request.GetType());

			dynamic fac = null;

			fac = Activator.CreateInstance(genericType);
			if (fac == null)
				fac = new RequestHandlerFactory<IRequest>();
			var x = await fac?.Create(serviceProvider, request);
			return x;
		}
	}

	internal class RequestHandlerFactory<T>
		where T : IRequest
	{
		public async Task<IResponse> Create(IServiceProvider serviceProvider, object arg)
		{
			IRequestHandler<T> handler = serviceProvider.GetService<IRequestHandler<T>>();

			if (handler == null)
			{
				// Try to get handler for interface registration
				var interfaceHandler = serviceProvider.GetService<IRequestHandler<IRequest>>();
				return await interfaceHandler.Handle((T)arg);
			}
			return await handler.Handle((T)arg);
		}

	}
}
