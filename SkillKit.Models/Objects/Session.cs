using System;
using System.Collections.Generic;

namespace AlexaWorld.SkillKit.Objects
{
	public class Session
	{
		public virtual bool IsNew { get; set; }

		public virtual string SessionId { get; set; }

		public virtual Dictionary<string, string> Attributes { get; set; }

		public virtual Application Application { get; set; }

		public virtual User User { get; set; }

	}
}