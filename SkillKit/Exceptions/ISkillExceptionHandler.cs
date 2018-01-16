using System;
using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.SkillResults;

namespace AlexaWorld.SkillKit.Exceptions
{
	public interface ISkillExceptionHandler
	{
		ISkillResult Handle(Exception exception, IRequest request);
	}
}