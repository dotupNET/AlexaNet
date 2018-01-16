using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaWorld.SkillKit.Responses.Cards
{
	public class PermissionsCard : Card
	{
		public PermissionsCard()
		{
			this.Type = AMAZON.Cards.AskForPermissionsConsent;
		}
		public List<string> Permissions { get; set; }
	}
}
