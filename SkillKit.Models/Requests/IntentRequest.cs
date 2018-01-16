using AlexaWorld.SkillKit.Objects;

namespace AlexaWorld.SkillKit.Requests
{
	public class IntentRequest : SessionRequest
	{
		public IntentRequest()
		{ }

		public Intent Intent { get; set; }

		public DialogStateEnum DialogState { get; set; }

		// TODO
		public enum DialogStateEnum
		{
			NONE = 0, // default in case parsing fails
			STARTED,
			IN_PROGRESS,
			COMPLETED
		}
	}
}