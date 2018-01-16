namespace AlexaWorld.SkillKit
{
	/// <summary>
	/// Amazon built in intents
	/// https://developer.amazon.com/de/docs/custom-skills/built-in-intent-library.html
	/// </summary>
	public static class AMAZON
	{
		public class Display
		{
			public enum FontSizeEnum
			{
				FontSize2 = 2,
				FontSize3 = 3,
				FontSize5 = 5,
				FontSize7 = 7
			}

			public class FontSize
			{
				public static string GetText(FontSizeEnum fontSize, string text)
				{
					return string.Format(FormatString, (int)fontSize, text);
				}

				public static string FormatString = "<font size=\"{0}\">{1}</font>";
				// Font size = "2" 	28px
				public static string FontSize2 = "<font size=\"2\">{0}</font>";
				// Font size="3" 	32px(default)
				public static string FontSize3 = "<font size=\"3\">{0}</font>";
				// Font size = "5" 	48px
				public static string FontSize5 = "<font size=\"5\">{0}</font>";
				// Font size="7" 	68px
				public static string FontSize7 = "<font size=\"7\">{0}</font>";
			}

			public class DisplayDirectives
			{
				///The template attribute identifies the template to be used, as well as all of the corresponding data to be used when rendering it
				public static string DisplayRenderTemplate = "Display.RenderTemplate";
			}

			public enum BodyTemplateType
			{
				BodyTemplate1 = 1,
				BodyTemplate2 = 2,
				BodyTemplate3 = 3,
				BodyTemplate6 = 6,
				BodyTemplate7 = 7
			}
			public enum ListTemplateType
			{
				ListTemplate1 = 1,
				ListTemplate2 = 2
			}
		}
		public class SupportedInterfaces
		{
			public const string AudioPlayer = "AudioPlayer";
			public const string Display = "Display";
		}

		public class AudioPlayerDirectives
		{
			///Sends Alexa a command to stream the audio file identified by the specified audioItem.
			public static string AudioPlayerPlay = "AudioPlayer.Play";
			///Stops any currently playing audio stream.
			public static string AudioPlayerStop = "AudioPlayer.Stop";
			///Clears the queue of all audio streams.
			public static string AudioPlayerClearQueue = "AudioPlayer.ClearQueue";
		}

		public class Cards
		{
			public static string SimpleCard = "Simple";
			public static string StandardCard = "Standard";
			public static string LinkAccountCard = "LinkAccount";
			public static string AskForPermissionsConsent = "AskForPermissionsConsent";
		}
		public class Requests
		{
			public static string LaunchRequest = "LaunchRequest";
			public static string SessionEndedRequest = "SessionEndedRequest";
			public static string IntentRequest = "IntentRequest";
			public static string SessionStartedRequest = "SessionStartedRequest";
		//	public static string Display = "Display";
			public static string SystemExceptionEncountered = "System.ExceptionEncountered";

			/* Playback controller */
			// Sent when the user uses a “next” button with the intent to skip to the next audio item.
			public static string PlaybackController_NextCommandIssued = "PlaybackController.NextCommandIssued";
			// Sent when the user uses a “pause” button with the intent to stop playback.
			public static string PlaybackController_PauseCommandIssued = "PlaybackController.PauseCommandIssued";
			// Sent when the user uses a “play” or “resume” button with the intent to start or resume playback.
			public static string PlaybackController_PlayCommandIssued = "PlaybackController.PlayCommandIssued";
			// Sent when the user uses a “previous” button with the intent to go back to the previous audio item.
			public static string PlaybackController_PreviousCommandIssued = "PlaybackController.PreviousCommandIssued";

			// Sent when Alexa begins playing the audio stream previously sent in a Play directive. This lets your skill verify that playback began successfully.
			public static string AudioPlayer_PlaybackStarted = "AudioPlayer.PlaybackStarted";
			// Sent when the stream Alexa is playing comes to an end on its own.
			public static string AudioPlayer_PlaybackFinished = "AudioPlayer.PlaybackFinished";
			// Sent when Alexa stops playing an audio stream in response to a voice request or an AudioPlayer directive.
			public static string AudioPlayer_PlaybackStopped = "AudioPlayer.PlaybackStopped";
			// Sent when the currently playing stream is nearly complete and the device is ready to receive a new stream.
			public static string AudioPlayer_PlaybackNearlyFinished = "AudioPlayer.PlaybackNearlyFinished";
			// Sent when Alexa encounters an error when attempting to play a stream.
			public static string AudioPlayer_PlaybackFailed = "AudioPlayer.PlaybackFailed";

		}

		#region standard-built-in-intents

		// https://developer.amazon.com/de/docs/custom-skills/standard-built-in-intents.html

		public static string CancelIntent = "AMAZON.CancelIntent";
		public static string HelpIntent = "AMAZON.HelpIntent";
		public static string LoopOffIntent = "AMAZON.LoopOffIntent";
		public static string LoopOnIntent = "AMAZON.LoopOnIntent";
		public static string NextIntent = "AMAZON.NextIntent";
		public static string NoIntent = "AMAZON.NoIntent";
		public static string PauseIntent = "AMAZON.PauseIntent";
		public static string PreviousIntent = "AMAZON.PreviousIntent";
		public static string RepeatIntent = "AMAZON.RepeatIntent";
		public static string ResumeIntent = "AMAZON.ResumeIntent";
		public static string ShuffleOffIntent = "AMAZON.ShuffleOffIntent";
		public static string ShuffleOnIntent = "AMAZON.ShuffleOnIntent";
		public static string StartOverIntent = "AMAZON.StartOverIntent";
		public static string StopIntent = "AMAZON.StopIntent";
		public static string YesIntent = "AMAZON.YesIntent";

		#endregion
		// 
	}

	public class Ssml
	{
		public enum SayAsInterpreter
		{
			// Spell out each letter.
			characters,
			spell_out,
			cardinal, number, //: Interpret the value as a cardinal number.
			ordinal,//: Interpret the value as an ordinal number.
			digits,//: Spell each digit separately .
			fraction,//: Interpret the value as a fraction. This works for both common fractions (such as 3/20) and mixed fractions(such as 1+1/2).
			unit,//: Interpret a value as a measurement.The value should be either a number or fraction followed by a unit (with no space in between) or just a unit.
			date,//: Interpret the value as a date. Specify the format with the format attribute.
			time,//: Interpret a value such as 1'21" as duration in minutes and seconds.
			telephone,//: Interpret a value as a 7-digit or 10-digit telephone number.This can also handle extensions (for example, 2025551212x345).
			address,//: Interpret a value as part of street address.
			interjection,//: Interpret the value as an interjection. Alexa speaks the text in a more expressive voice. For optimal results, only use the supported interjections and surround each one with a pause. For example: <say-as interpret-as="interjection">Wow.</say-as>. Speechcons are supported for the languages listed below.
			expletive//: “Bleep” out the content inside the tag
		}

		public enum ProsodyRate
		{
			x_slow, slow, medium, fast, x_fast
		}

		public enum ProsodyPitch
		{
			x_low, low, medium, high, x_high
		}

		public enum ProsodyVolume
		{
			silent, x_soft, soft, medium, loud, x_loud
		}

		public enum BreakStrength
		{
			none, //: No pause should be outputted. This can be used to remove a pause that would normally occur (such as after a period).
			x_weak,//: No pause should be outputted(same as none).
			weak,//: Treat adjacent words as if separated by a single comma(equivalent to medium).
			medium,//: Treat adjacent words as if separated by a single comma.
			strong,//: Make a sentence break (equivalent to using the <s> tag).
			x_strong,//: Make
		}

		public enum EmphasisLevel
		{
			// Increase the volume and slow down the speaking rate so the speech is louder and slower.
			strong,
			// Increase the volume and slow down the speaking rate, but not as much as when set to strong. This is used as a default if level is not provided.
			moderate,
			// Decrease the volume and speed up the speaking rate. The speech is softer and faster.
			reduced
		}
	}

}