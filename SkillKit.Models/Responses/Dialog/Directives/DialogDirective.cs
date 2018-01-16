using AlexaWorld.SkillKit.Directives;
using AlexaWorld.SkillKit.Objects;

namespace AlexaWorld.SkillKit.Interfaces.Dialog.Directives
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/dialog-interface-reference.html#directives
	/// </summary>
	public class DialogDirective : Directive
	{
		public DialogDirective(string subtype) :
			base($"Dialog.{subtype}")
		{ }

		public Intent UpdatedIntent { get; set; }
	}
}