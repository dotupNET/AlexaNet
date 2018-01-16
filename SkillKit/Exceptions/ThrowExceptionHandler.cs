using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.SkillResults;
using System;

namespace AlexaWorld.SkillKit.Exceptions
{
	public class ThrowExceptionHandler : ISkillExceptionHandler
	{
		public ISkillResult Handle(Exception exception, IRequest request)
		{
			throw exception;
		}
	}
}
