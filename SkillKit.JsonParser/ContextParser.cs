using AlexaWorld.SkillKit.Directives;
using AlexaWorld.SkillKit.Objects;
using AlexaWorld.SkillKit.Requests;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlexaWorld.SkillKit.JsonParser
{
	public class ContextParser
	{
		public Context Parse(SkillRequest SkillRequest, JObject context)
		{
			if (context == null)
				return null;

			return new Context()
			{
				System = GetSystemObject(context.Value<JObject>("System")),
				AudioPlayer = GetAudioPlayerObject(context.Value<JObject>("AudioPlayer"))
			};
		}

		private SystemObject GetSystemObject(JObject system)
		{
			if (system == null)
				return null;

			var userParser = new UserParser();
			var user = userParser.Parse(system);

			return new SystemObject
			{
				Application = system.GetApplication(),
				User = user,
				Device = GetDevice(system.Value<JObject>("device")),
				ApiEndpoint = system.GetString("apiEndpoint"),
				ApiAccessToken = system.GetString("apiAccessToken")
			};
		}

		private Device GetDevice(JObject device)
		{
			if (device == null)
				return null;

			return new Device
			{
				DeviceId = device.GetString("deviceId"),
				SupportedInterfaces = GetSupportedInterfaces(device)
			};
		}

		private List<ISupportedInterface> GetSupportedInterfaces(JObject jObject)
		{
			var interfaceProps = jObject.Value<JObject>("supportedInterfaces").Children<JProperty>();

			return interfaceProps.Select<JProperty, ISupportedInterface>(item =>
			 {
				 switch (item.Name)
				 {
					 case AMAZON.SupportedInterfaces.AudioPlayer:
						 return new AudioPlayerInterface();

					 case AMAZON.SupportedInterfaces.Display:
						 var jDisplay = item.Value as JObject;
						 return new DisplayInterface()
						 {
							 MarkupVersion = jDisplay.GetString("markupVersion"),
							 TemplateVersion = jDisplay.GetString("templateVersion"),
							 Token = jDisplay.GetString("token")
						 };

					 default:
						 return null;
				 }
			 }).Where(item => item != null).ToList();
		}

		private AudioPlayer GetAudioPlayerObject(JObject audioPlayer)
		{
			if (audioPlayer == null)
				return null;

			Enum.TryParse<PlayerActivityEnum>(audioPlayer.GetString("playerActivity"), out var playerActivity);

			return new AudioPlayer
			{
				OffsetInMilliseconds = audioPlayer.Value<long?>("offsetInMilliseconds"),
				Token = audioPlayer.GetString("token"),
				PlayerActivity = playerActivity
			};
		}

	}
}
