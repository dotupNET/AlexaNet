//using AlexaWorld.SkillKit.AlexaSessions;
//using AlexaWorld.SkillKit.Speechlet;
//using AlexaWorld.SkillKit.UI;
//using System;
//using System.Threading.Tasks;

//namespace AlexaBackend.Controllers
//{
//	internal class IgeSpeechlet : ISpeechletAsync
//	{
//		public IgeSpeechlet(ISessionManager sessionManager) :
//			base(sessionManager)
//		{ }

//		public override Task<SpeechletResponse> OnDisplayAsync(DisplayRequest displayRequest, Context context)
//		{
//			return base.OnDisplayAsync(displayRequest, context);
//		}

//		public override Task OnSessionStartedAsync(SessionStartedRequest sessionStartedRequest, ISessionManager sessionManager)
//		{
//			return base.OnSessionStartedAsync(sessionStartedRequest, sessionManager);
//		}

//		public override Task<SpeechletResponse> OnLaunchAsync(LaunchRequest launchRequest, ISessionManager sessionManager)
//		{
//			return base.OnLaunchAsync(launchRequest, sessionManager);
//		}

//		public override Task<SpeechletResponse> OnIntentAsync(IntentRequest intentRequest, ISessionManager sessionManager, Context context)
//		{
//			return base.OnIntentAsync(intentRequest, sessionManager, context);
//		}

//		public override Task OnSessionEndedAsync(SessionEndedRequest sessionEndedRequest, ISessionManager sessionManager)
//		{
//			return base.OnSessionEndedAsync(sessionEndedRequest, sessionManager);
//		}
//	}
//}