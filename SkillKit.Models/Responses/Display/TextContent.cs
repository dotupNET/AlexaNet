namespace AlexaWorld.SkillKit.Responses.Display
{
	/// <summary>
	/// The textContent object, found in all templates, allows for primaryText, secondaryText, and tertiaryText fields, which may be styled differently. With the ListTemplate1 template, the text is automatically styled to match these hierarchy levels. For the other templates, the text listed for each of primaryText, secondaryText, and tertiaryText is concatenated, with line breaks added between each, and no difference in font between the lines. Each of primaryText, secondaryText, and tertiaryText has the same format.
	/// </summary>
	/// <remarks>
	/// https://developer.amazon.com/docs/custom-skills/display-interface-reference.html#textcontent-object-specifications
	/// </remarks>
	public class TextContent
	{
		public TextContent()
		{ }

		public virtual TextField PrimaryText { get; set; }

		public TextField SecondaryText { get; set; }

		public TextField TertiaryText { get; set; }
	}
}