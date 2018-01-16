using System.Collections.Generic;

namespace AlexaWorld.SkillKit.Objects
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/request-types-reference.html#intent-object
	/// </summary>
	public class Intent
	{
		public string Name { get; set; }

		public ConfirmationStatusEnum ConfirmationStatus { get; set; }

		public Dictionary<string, Slot> Slots { get; set; }

	}
}