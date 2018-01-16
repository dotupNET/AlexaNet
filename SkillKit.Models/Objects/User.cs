using System;

namespace AlexaWorld.SkillKit.Objects
{
	public class User
	{
		public string UserId { get; set; }

		public string AccessToken { get; set; }
		public UserPermissions Permissions { get; set; }
	}
}