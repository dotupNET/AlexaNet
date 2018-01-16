// Copyright 2017 Peter Ullrich, dotup IT solutions. All rights reserved.

using AlexaWorld.SkillKit.Models;
using AlexaWorld.SkillKit.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace AlexaWorld.SkillKit.Json
{
	public class SkillResultBuilder
	{
		private class CamelCasePropertyResolver : CamelCasePropertyNamesContractResolver
		{
			protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
			{
				var contract = base.CreateDictionaryContract(objectType);
				contract.DictionaryKeyResolver = propertyName => propertyName;
				return contract;
			}
		}

		private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
		{
			NullValueHandling = NullValueHandling.Ignore,
			ContractResolver = new CamelCasePropertyResolver(),
			Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() }
		};

		public string Build(ResponseBody responseBody)
		{
			return JsonConvert.SerializeObject(responseBody, serializerSettings);
		}

		public string Build(IResponse response, Dictionary<string, string> sessionAttributes)
		{
			var body = new ResponseBody()
			{
				Response = response,
				SessionAttributes = sessionAttributes
			};
			return JsonConvert.SerializeObject(body, serializerSettings);
		}

	}
}