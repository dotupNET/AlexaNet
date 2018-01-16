using System;

namespace AlexaWorld.SkillKit.Objects
{
	/// <summary>
	/// https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#playbackfailed
	/// https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#system-exceptionencountered
	/// </summary>
	public class Error
	{
		public ErrorTypeEnum Type { get; set; }
		public string Message { get; set; }

		public enum ErrorTypeEnum
		{
			INVALID_RESPONSE,
			DEVICE_COMMUNICATION_ERROR,
			INTERNAL_ERROR,
			//An unknown error occurred.
			MEDIA_ERROR_UNKNOWN,
			//Alexa recognized the request as being malformed. E.g. bad request, unauthorized, forbidden, not found, etc.
			MEDIA_ERROR_INVALID_REQUEST,
			//Alexa was unable to reach the URL for the stream.
			MEDIA_ERROR_SERVICE_UNAVAILABLE,
			//Alexa accepted the request, but was unable to process the request as expected.
			MEDIA_ERROR_INTERNAL_SERVER_ERROR,
			//There was an internal error on the device.
			MEDIA_ERROR_INTERNAL_DEVICE_ERROR
		}
	}
}
