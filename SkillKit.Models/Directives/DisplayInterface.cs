namespace AlexaWorld.SkillKit.Directives
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/display-interface-reference.html#determining-the-version-of-the-supported-display
	/// </summary>
	public class DisplayInterface : ISupportedInterface
	{
		/// <summary>
		/// Version of markup.
		/// </summary>
		public string TemplateVersion { get; set; }

		/// <summary>
		/// The version of templates supported by the requesting device.
		/// </summary>
		public string MarkupVersion { get; set; }

		/// <summary>
		/// The token for the content currently shown on the display.
		/// </summary>
		public string Token { get; set; }

		public InterfaceType Type => InterfaceType.Display;
	}
}