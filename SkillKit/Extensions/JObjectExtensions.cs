using AlexaWorld.SkillKit.JsonParser;
using AlexaWorld.SkillKit.Models;
using AlexaWorld.SkillKit.Objects;
using AlexaWorld.SkillKit.Requests;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using static AlexaWorld.SkillKit.Objects.Error;
using static AlexaWorld.SkillKit.Requests.SessionEndedRequest;

namespace AlexaWorld.SkillKit.Extensions
{
	public static class JObjectExtensions
	{

		public static Cause GetCause(this JObject jObject)
		{
			var json = jObject.Value<JObject>("cause");

			if (json == null)
				return null;

			return new Cause
			{
				RequestId = json.GetString("requestId")
			};
		}

		public static Error GetError(this JObject jObject)
		{
			var json = jObject.Value<JObject>("error");
			if (json == null)
				return null;

			Enum.TryParse<ErrorTypeEnum>(json.GetString("type"), out var type);
			return new Error
			{
				Type = type,
				Message = json.GetString("message")
			};
		}

		public static PlaybackState GetPlaybackState(this JObject jObject)
		{
			var json = jObject.Value<JObject>("currentPlaybackState");
			if (json == null)
				return null;

			Enum.TryParse<PlayerActivityEnum>(json.GetString("playerActivity"), out var playerActivity);

			return new PlaybackState
			{
				Token = json.GetString("token"),
				OffsetInMilliseconds = json.Value<long?>("offsetInMilliseconds"),
				PlayerActivity = playerActivity
			};
		}

		public static SessionEndedReasonEnum GetReason(this JObject jObject)
		{
			Enum.TryParse<SessionEndedReasonEnum>(jObject.GetString("reason"), out var reason);
			return reason;
		}

		public static IntentRequest.DialogStateEnum GetDialogState(this JObject jObject)
		{
			Enum.TryParse<IntentRequest.DialogStateEnum>(jObject.GetString("dialogState"), out var state);
			return state;
		}

		public static string GetString(this JObject jObject, string name)
		{
			return jObject.Value<string>(name);
		}

		public static Intent GetIntent(this JObject jObject)
		{
			var jIntent = jObject.Value<JObject>("intent");
			if (jIntent == null)
				return null;

			var sp = new SlotParser();

			var slots = sp.Parse(jIntent);

			Enum.TryParse<ConfirmationStatusEnum>(jIntent.GetString("confirmationStatus"), out var confirmationStatus);

			return new Intent
			{
				Name = jIntent.GetString("name"),
				ConfirmationStatus = confirmationStatus,
				Slots = slots ?? new Dictionary<string, Slot>()
			};
		}


	}
}
