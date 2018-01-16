using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.SkillResults;
using System;

namespace AlexaWorld.SkillKit.Exceptions
{
	public class BadRequestResultExceptionHandler : ISkillExceptionHandler
	{
		public ISkillResult Handle(Exception exception, IRequest request)
		{
			return new BadRequestResult(exception.Message);
		}
	}
}
