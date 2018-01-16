using System;
using System.Collections.Generic;
using System.Text;
using static AlexaWorld.SkillKit.AMAZON.Display;

namespace AlexaWorld.SkillKit.Responses.Display
{
	/// <summary>
	/// https://developer.amazon.com/de/docs/custom-skills/display-interface-reference.html#display-template-elements
	/// </summary>
	public class BodyTemplate : IDisplayTemplate
	{
		public BodyTemplate() :
			this(BodyTemplateType.BodyTemplate1)
		{ }

		public BodyTemplate(BodyTemplateType templateType)
		{
			Type = templateType.ToString();
			TextContent = new TextContent();
		}

		// Do not use Enum to get it working with not listed
		public string Type { get; set; }

		public string Token { get; set; }

		public ButtonVisibilityEnum BackButton { get; set; }

		public DisplayImage BackgroundImage { get; set; }

		/// <summary>
		/// For each template, the maximum for the title is 200 characters. 
		/// </summary>
		public string Title { get; set; }

		public TextContent TextContent { get; set; }

		public DisplayImage Image { get; set; }


		public enum ButtonVisibilityEnum
		{
			HIDDEN,
			VISIBLE
		}
	}
}