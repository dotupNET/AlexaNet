namespace AlexaWorld.SkillKit.Responses.Display
{
	/// <summary>
	/// Each list item contains optional token, textContent, and image fields
	/// </summary>
	/// <remarks>
	/// https://developer.amazon.com/docs/custom-skills/display-interface-reference.html#display-template-elements
	/// </remarks>
	public class ListItem
	{
		public string Token { get; set; }
		public virtual TextContent TextContent { get; set; }
		public virtual DisplayImage Image { get; set; }
	}
}