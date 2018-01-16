using AlexaWorld.SkillKit.Directives;
using static AlexaWorld.SkillKit.AMAZON.Display;

namespace AlexaWorld.SkillKit.Responses.Display.Directives
{
	/// <summary>
	/// The template attribute identifies the template to be used, as well as all of the corresponding data to be used when rendering it.
	/// </summary>
	/// <remarks>
	/// https://developer.amazon.com/docs/custom-skills/display-interface-reference.html#form-of-the-displayrendertemplate-directive
	/// </remarks>
	public class DisplayRenderTemplateDirective : Directive
	{
		public DisplayRenderTemplateDirective() :
			this(default(IDisplayTemplate))
		{ }

		public DisplayRenderTemplateDirective(IDisplayTemplate template) :
			base(DisplayDirectives.DisplayRenderTemplate)
		{
			Template = template;
		}

		public IDisplayTemplate Template { get; set; }
	}
}