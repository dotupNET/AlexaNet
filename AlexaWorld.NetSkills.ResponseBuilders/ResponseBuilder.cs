using AlexaWorld.SkillKit.Directives;
using AlexaWorld.SkillKit.Extensions;
using AlexaWorld.SkillKit.Models;
using AlexaWorld.SkillKit.Objects;
using AlexaWorld.SkillKit.Responses;
using System;
using System.Threading.Tasks;

namespace AlexaWorld.NetSkills.ResponseBuilders
{
	public class ResponseBuilder : IResponseBuilder<IResponse>
	{
		private Context context;
		private Response response;

		public ResponseBuilder(Context context)
		{
			this.context = context;
			response = new Response();
		}

		public ResponseBuilder Ssml(Action<SsmlBuilder> ssmlBuilder)
		{
			var ssml = new SsmlBuilder();
			ssmlBuilder(ssml);
			response.OutputSpeech = ssml.Build();
			return this;
		}

		public ResponseBuilder Tell(string text)
		{
			response.OutputSpeech = text;
			return this;
		}

		public ResponseBuilder TellText(string text)
		{
			response.OutputSpeech = new SsmlOutputSpeech(text);
			return this;
		}

		public ResponseBuilder WithCard(Action<CardBuilder> build)
		{
			var builder = new CardBuilder();
			build(builder);
			var card = builder.Build();
			response.Card = card;
			return this;
		}

		public ResponseBuilder WithDisplay(Action<DisplayBuilder> build)
		{

			if (IsInterfaceSupported(InterfaceType.Display))
			{
				var builder = new DisplayBuilder();
				build(builder);
				var display = builder.Build();
				response.AddDirective(display);
			}
			return this;
		}

		private bool IsInterfaceSupported(InterfaceType interfaceType)
		{
			if (context == null)
				return false;
			if (context.System == null)
				return false;
			if (context.System.Device == null)
				return false;

			return context.System.Device.IsInterfaceSupported(interfaceType);

		}

		public IResponse Build()
		{
			return response;
		}

		public Task<IResponse> BuildAsync()
		{
			return Task.FromResult(Build());
		}
	}
}
