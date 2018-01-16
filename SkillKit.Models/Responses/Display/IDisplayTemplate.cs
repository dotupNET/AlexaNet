using AlexaWorld.SkillKit.Directives;

namespace AlexaWorld.SkillKit.Responses.Display
{
	public interface IDisplayTemplate : IDirective
	{
		BodyTemplate.ButtonVisibilityEnum BackButton { get; set; }
		DisplayImage BackgroundImage { get; set; }
		DisplayImage Image { get; set; }
		TextContent TextContent { get; set; }
		string Title { get; set; }
		string Token { get; set; }
		//string Type { get; set; }
	}
}