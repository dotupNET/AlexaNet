namespace AlexaWorld.SkillKit.Responses.Display
{
	/// <summary>
	/// In each case, TextField is represented as follows. If type is set to PlainText, no markup is included. If type is set to RichText, the markup described in Supported Markup can be included.
	/// </summary>
	/// <remarks>
	/// https://developer.amazon.com/docs/custom-skills/display-interface-reference.html#textcontent-object-specifications
	/// </remarks>
	public class TextField
	{
		public virtual TextTypeEnum Type { get; set; }

		public string Text { get; set; }

		public enum TextTypeEnum
		{
			PlainText,
			RichText
		}

		public static implicit operator TextField(string text)
		{
			return new TextField()
			{
				Type = TextTypeEnum.PlainText,
				Text = text
			};
		}
	}
}