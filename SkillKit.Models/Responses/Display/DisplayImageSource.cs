namespace AlexaWorld.SkillKit.Responses.Display
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/display-interface-reference.html#image-object-specifications
	/// </summary>
	public class DisplayImageSource
	{
		public string Url { get; set; }

		public ImageSizeEnum Size { get; set; }

		public int? WidthPixels { get; set; }

		public int? HeightPixels { get; set; }

		public enum ImageSizeEnum
		{
			X_SMALL,  //  Displayed within extra small containers 	480 x 320
			SMALL,    //  Displayed within small containers 	720 x 480
			MEDIUM,   //	Displayed within medium containers 	960 x 640
			LARGE,    //  Displayed within large containers 	1200 x 800
			X_LARGE   //  Displayed within extra large containers 	1920 x 1280
		}
	}
}