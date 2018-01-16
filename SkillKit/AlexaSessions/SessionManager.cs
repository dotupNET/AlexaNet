using AlexaWorld.SkillKit.Objects;
using AlexaWorld.SkillKit.Requests;
using System;
using System.Collections.Generic;

namespace AlexaWorld.SkillKit.AlexaSessions
{
	public class SessionManager : ISessionManager
	{
		public bool Initialize(SessionRequest sessionRequest)
		{
			if (sessionRequest == null)
				return false;

			Session = sessionRequest.Session;

			var request = sessionRequest as IntentRequest;

			if (request == null || Session == null)
				return false;

			if (Session.Attributes == null)
				Session.Attributes = new Dictionary<string, string>();

			//if (Session.IsNew)
			//{
			//	Session.Attributes[Session.INTENT_SEQUENCE] = request.Intent.Name;
			//}
			//else
			//{
			//	// if the session was started as a result of a launch request 
			//	// a first intent isn't yet set, so set it to the current intent
			//	if (!Session.Attributes.ContainsKey(Session.INTENT_SEQUENCE))
			//	{
			//		Session.Attributes[Session.INTENT_SEQUENCE] = request.Intent.Name;
			//	}
			//	else
			//	{
			//		Session.Attributes[Session.INTENT_SEQUENCE] += Session.SEPARATOR + request.Intent.Name;
			//	}
			//}

			// Auto-session management: copy all slot values from current intent into session
			foreach (var slot in request.Intent.Slots.Values)
			{
				if (!String.IsNullOrEmpty(slot.Value))
					Session.Attributes[slot.Name] = slot.Value;
			}

			return Session.IsNew;
		}

		public Session Session { get; private set; }
	}
}
