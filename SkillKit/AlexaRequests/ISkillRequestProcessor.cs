using AlexaWorld.SkillKit.SkillResults;
using AlexaWorld.SkillKit.Requests;
using System.Threading.Tasks;

namespace AlexaWorld.SkillKit.AlexaRequests
{
	public interface ISkillRequestProcessor
	{
		Task<ISkillResult> ProcessAsync(SkillRequest skillRequest);
	}
}