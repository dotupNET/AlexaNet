namespace AlexaWorld.SkillKit.Objects
{
	public class AudioPlayer
	{
		public string Token { get; set; }

		public long? OffsetInMilliseconds { get; set; }

		public PlayerActivityEnum PlayerActivity { get; set; }

	}
}