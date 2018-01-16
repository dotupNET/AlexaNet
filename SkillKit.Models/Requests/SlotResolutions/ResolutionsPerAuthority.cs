namespace AlexaWorld.SkillKit.Requests.SlotResolutions
{
	public class ResolutionsPerAuthority
	{
		public string Authority { get; set; }
		public ResolutionsPerAuthorityStatusCode Status { get; set; }
		public ResolutionsPerAuthorityValues Values { get; set; }
	}
}