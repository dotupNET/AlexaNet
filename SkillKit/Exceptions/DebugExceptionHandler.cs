using AlexaWorld.NetSkills.ResponseBuilders;
using AlexaWorld.SkillKit.Json;
using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.Responses;
using AlexaWorld.SkillKit.SkillResults;
using System;
using static AlexaWorld.SkillKit.AMAZON.Display;

namespace AlexaWorld.SkillKit.Exceptions
{
	public class DebugExceptionHandler : ISkillExceptionHandler
	{
		public ISkillResult Handle(Exception exception, IRequest request)
		{
			var context = (request as ContextRequest)?.Context;

			var rb = new ResponseBuilder(context);
			rb
				.Tell("Leider ist ein Fehler aufgetreten.")
				.WithCard(card =>
				{
					card.WithSimpleCard(exception.GetType().ToString(), exception.StackTrace);
				})
				.WithDisplay(display =>
				{
					display
						.FromTemplate(BodyTemplateType.BodyTemplate1)
						.WithTitle(exception.GetType().ToString())
						.WithPrimaryPlainText(exception.Message)
						.WithSecondaryPlainText(exception.StackTrace)
					;
				})
			;

			// TODO				Version = requestEnvelope.Version,
			// Build response
			var session = (request as SessionRequest)?.Session;

			var resultBuilder = new SkillResultBuilder();
			var result = resultBuilder.Build(rb.Build(), session?.Attributes);

			return new OkResult(result);
		}
	}
}
