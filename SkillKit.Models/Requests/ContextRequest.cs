using AlexaWorld.SkillKit.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaWorld.SkillKit.Requests
{
	/// <summary>
	/// The context object provides your skill with information about the current state of the Alexa service and device at the time the request is sent to your service. This is included on all requests. For requests sent in the context of a session (LaunchRequest and IntentRequest), the context object duplicates the user and application information that is also available in the session object.
	/// </summary>
	public class ContextRequest : Request, IContextRequest
	{
		public Context Context { get; set; }
	}
}
