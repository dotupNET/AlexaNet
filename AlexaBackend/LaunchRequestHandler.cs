using AlexaWorld.NetSkills.ResponseBuilders;
using AlexaWorld.SkillKit.AlexaRequests;
using AlexaWorld.SkillKit.Helpers;
using AlexaWorld.SkillKit.Requests;
using AlexaWorld.SkillKit.Responses;
using System.Threading.Tasks;
using static AlexaWorld.SkillKit.AMAZON.Display;
using static AlexaWorld.SkillKit.Ssml;

namespace AlexaBackend
{
	public class LaunchRequestHandler : IRequestHandler<LaunchRequest>
	{
		public async Task<IResponse> Handle(LaunchRequest launchRequest)
		{
			var rb = new ResponseBuilder(launchRequest.Context);

			var endpoint = launchRequest.Context.System.ApiEndpoint;
			var deviceId = launchRequest.Context.System.Device.DeviceId;
			var token = launchRequest.Context.System.ApiAccessToken;

			var x = new AmazonHttpRequest(token);
			var y = await x.GetAddressAsync(endpoint, deviceId);
			rb
				.Tell("Ok")
				.Ssml(ssml =>
				{
					ssml
						//.Volume(ProsodyVolume.x_loud)
						.Whisper().Volume(ProsodyVolume.soft)
						.AddText("Ja ich kann flüstern.")
						.AddSsml("")
						.AddSentence("So wird ein Satz ausgesprochen.")
						.CloseAllEffects()
						.Pitch(ProsodyPitch.x_low)
						.AddSentence("Und hier der Rest mit Pitch x low.")
						.WithVolume("Na gut", ProsodyVolume.loud)
						.CloseEffect()
						.Rate(ProsodyRate.x_fast)
						.AddText("Und jetzt spreche ich mal ganz schnell")
					;
				})
				.WithCard(card =>
				{
					card.WithSimpleCard("Title", "Content");
				})
				.WithDisplay(display =>
				{
					display
						.FromTemplate(BodyTemplateType.BodyTemplate1)
						.WithTitle("Heut mal nach der Alexa schaun?")
						.WithToken("XY")
						.WithPrimaryRichText("1. Ja", FontSizeEnum.FontSize3)
						.WithSecondaryRichText("2. Nein", FontSizeEnum.FontSize5)
						.HideBackButton()
						.WithTertiaryRichText("3. Vielleicht", FontSizeEnum.FontSize7)
					;
				});

			return await rb.BuildAsync();
			//var displayBuilder = new DisplayBuilder();
			//var template = displayBuilder
			//	.FromTemplate(BodyTemplate.TemplateType.BodyTemplate1)
			//	.WithTitle("Heut mal nach der Alexa schaun?")
			//	.WithToken("XY")
			//	.WithPrimaryRichText("1. Ja", AlexaWorld.SkillKit.AMAZON.FontSizeEnum.FontSize7)
			//	.WithSecondaryRichText("2. Nein", AlexaWorld.SkillKit.AMAZON.FontSizeEnum.FontSize5)
			//	.HideBackButton()
			//	.WithTertiaryRichText("3. Vielleicht", AlexaWorld.SkillKit.AMAZON.FontSizeEnum.FontSize3)
			//	//.WithCard(cardBuilder=> cardBuilder.WithTitle("f")
			//	.Build();

			//var response = new Response();
			//response.Directives = new List<IDirective>();
			//response.Directives.Add(template);
			//response.SetPlainText("Ok mit display");
			//return await Task.FromResult(response);
		}
	}
}
