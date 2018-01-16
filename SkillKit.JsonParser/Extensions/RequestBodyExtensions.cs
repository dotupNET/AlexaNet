using AlexaWorld.SkillKit.Models;
using AlexaWorld.SkillKit.Requests;
using Newtonsoft.Json.Linq;

namespace AlexaWorld.SkillKit.JsonParser.Extensions
{
	public static class RequestBodyExtensions
	{
		public static T ToSessionRequest<T>(this RequestBody requestBody) where T : ISessionRequest, new()
		{
			return new T()
			{
				RequestId = requestBody.Request.RequestId,
				Timestamp = requestBody.Request.Timestamp,
				Type = requestBody.Request.Type,
				Locale = requestBody.Request.Locale,
				Context = requestBody.Context,
				Session = requestBody.Session
			};
		}

		public static T ToContextRequest<T>(this RequestBody requestBody) where T : IContextRequest, new()
		{
			return new T()
			{
				RequestId = requestBody.Request.RequestId,
				Timestamp = requestBody.Request.Timestamp,
				Type = requestBody.Request.Type,
				Locale = requestBody.Request.Locale,
				Context = requestBody.Context
			};
		}

		public static LaunchRequest ToLaunchRequest(this RequestBody requestBody)
		{
			return ToSessionRequest<LaunchRequest>(requestBody);
		}

		public static IntentRequest ToIntentRequest(this RequestBody requestBody)
		{
			return new IntentRequest()
			{
				RequestId = requestBody.Request.RequestId,
				Timestamp = requestBody.Request.Timestamp,
				Type = requestBody.Request.Type,
				Locale = requestBody.Request.Locale,
				Context = requestBody.Context,
				Session = requestBody.Session,
				Intent = (requestBody.Json as JObject)?.Value<JObject>("request")?.GetIntent()
				//Intent = json.GetIntent(),
				//DialogState = json.GetDialogState()
			};
		}

		public static SessionStartedRequest ToSessionStartedRequest(this RequestBody requestBody)
		{
			return ToSessionRequest<SessionStartedRequest>(requestBody);
		}

		public static SessionEndedRequest ToSessionEndedRequest(this RequestBody requestBody)
		{
			return ToSessionRequest<SessionEndedRequest>(requestBody);
		}

		//		public static IRequest GetAudioPlayerRequest(RequestBody requestBody)
		//		{
		//			var json = requestBody.Json as JObject;

		//			var token = json.Value<string>("token");
		//			var offset = json.Value<long?>("offsetInMilliseconds");

		//			var result = ToContextRequest<AudioPlayerRequest>(requestBody);

		//			result.OffsetInMilliseconds = offset;
		//			result.Token = token;
		//			return result;

		////				Session = jObject.GetSession(),
		//		}

		// "AudioPlayer.PlaybackFailed":
		//public static IRequest GetAudioPlayerPlaybackFailedRequest(RequestBody requestBody)
		//{
		//	var json = requestBody.Json as JObject;

		//	var token = json.Value<string>("token");
		//	var offset = json.Value<long?>("offsetInMilliseconds");

		//	return new AudioPlayerPlaybackFailedRequest()
		//	{
		//		Type = json.GetRequestType(),
		//		RequestId = json.GetRequestId(),
		//		Timestamp = json.GetTimestamp(),
		//		Locale = json.GetLocale(),
		//		Context = jObject.GetContext(),
		//		Session = jObject.GetSession(),
		//		CurrentPlaybackState = json.GetPlaybackState(),
		//		Error = json.GetError(),
		//		OffsetInMilliseconds = offset,
		//		//				Subtype = requestType.GetSubRequestType(),
		//		Token = token
		//	};
		//}

		//public static IRequest GetPlaybackControllerRequest(RequestBody requestBody)
		//{
		//	var json = requestBody.Json as JObject;
		//	return new PlaybackControllerRequest()
		//	{
		//		Type = json.GetRequestType(),
		//		RequestId = json.GetRequestId(),
		//		Timestamp = json.GetTimestamp(),
		//		Locale = json.GetLocale(),
		//		Context = jObject.GetContext(),
		//		Session = jObject.GetSession()
		//		//			Subtype = requestType.GetSubRequestType()
		//	};
		//}

		//public static IRequest GetDisplayRequest(RequestBody requestBody)
		//{
		//	var json = requestBody.Json as JObject;
		//	var listItemToken = json.Value<string>("token");
		//	return new DisplayRequest()
		//	{
		//		Type = json.GetRequestType(),
		//		RequestId = json.GetRequestId(),
		//		Timestamp = json.GetTimestamp(),
		//		Locale = json.GetLocale(),
		//		Context = jObject.GetContext(),
		//		Session = jObject.GetSession(),
		//		Token = listItemToken
		//	};
		//}

		//public static IRequest GetException(RequestBody requestBody)
		//{
		//	var json = requestBody.Json as JObject;
		//	return new SystemExceptionEncounteredRequest()
		//	{
		//		Type = json.GetRequestType(),
		//		RequestId = json.GetRequestId(),
		//		Timestamp = json.GetTimestamp(),
		//		Locale = json.GetLocale(),
		//		Context = jObject.GetContext(),
		//		Session = jObject.GetSession(),
		//		Cause = json.GetCause(),
		//		Error = json.GetError()
		//	};
		//}
	}
}
