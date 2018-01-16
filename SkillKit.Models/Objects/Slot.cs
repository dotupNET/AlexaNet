using AlexaWorld.SkillKit.Requests.SlotResolutions;

namespace AlexaWorld.SkillKit.Objects
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/request-types-reference.html#slot-object
	/// </summary>
	public class Slot
	{
		public string Name { get; set; }

		public string Id { get; set; }

		public string Value { get; set; }

		public ConfirmationStatusEnum ConfirmationStatus { get; set; }

		public Resolutions Resolutions { get; set; }
	}
}