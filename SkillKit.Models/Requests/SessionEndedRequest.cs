using AlexaWorld.SkillKit.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaWorld.SkillKit.Requests
{
	/// <summary>
	/// https://developer.amazon.com/de/docs/custom-skills/handle-requests-sent-by-alexa.html#sessionendedrequest
	/// </summary>
	/// <remarks>Your service receives a SessionEndedRequest when a currently open session is closed for one of the following reasons:
	///	-The user says “exit”.
	/// -The user does not respond or says something that does not match an intent defined in your voice interface while the device is listening for the user’s response.
	/// -An error occurs.
	///
	///Note that setting the shouldEndSession flag to true in your response also ends the session. In this case, your service does not receive a SessionEndedRequest.
	///Your service cannot send back a response to a SessionEndedRequest
	///</remarks>
	public class SessionEndedRequest : SessionRequest
	{
		public SessionEndedReasonEnum Reason { get; set; }

		public Error Error { get; set; }

		public enum SessionEndedReasonEnum
		{
			NONE,
			ERROR,
			USER_INITIATED,
			EXCEEDED_MAX_REPROMPTS,
		}
	}
}
