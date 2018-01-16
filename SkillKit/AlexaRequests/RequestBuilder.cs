using AlexaWorld.SkillKit.JsonParser.Extensions;
using AlexaWorld.SkillKit.Requests;
using System;
using System.Collections.Generic;

namespace AlexaWorld.SkillKit.AlexaRequests
{
	public class RequestBuilder : IRequestBuilder
	{
		public delegate IRequest BuildDelegate(RequestBody requestBody);

		private Dictionary<string, BuildDelegate> builder;

		public RequestBuilder()
		{
			AddDefaultBuilder();
		}

		public IRequest Build(RequestBody requestBody)
		{
			var requestType = requestBody.Request.Type;
			if (builder.TryGetValue(requestType, out var buildDelegate))
				return buildDelegate.Invoke(requestBody);

			throw new Exception();
		}

		private void AddDefaultBuilder()
		{
			builder = new Dictionary<string, BuildDelegate>();
			Add(AMAZON.Requests.LaunchRequest, body => body.ToLaunchRequest());
			Add(AMAZON.Requests.IntentRequest, body => body.ToIntentRequest());
			Add(AMAZON.Requests.SessionStartedRequest, body => body.ToSessionStartedRequest());
			Add(AMAZON.Requests.SessionEndedRequest, body => body.ToSessionEndedRequest());
			//Add(AMAZON.Requests.AudioPlayer, GetAudioPlayerRequest);
			//Add(AMAZON.Requests.AudioPlayerPlaybackFailed, GetAudioPlayerPlaybackFailedRequest);
			//Add(AMAZON.Requests.PlaybackController, GetPlaybackControllerRequest);
			//Add(AMAZON.Requests.Display, GetDisplayRequest);
			//Add(AMAZON.Requests.SystemExceptionEncountered, GetException);
		}

		public void Add(string requestType, BuildDelegate buildDelegate)
		{
			if (builder.ContainsKey(requestType))
				builder.Remove(requestType);

			builder.Add(requestType, buildDelegate);
		}

	}
}
