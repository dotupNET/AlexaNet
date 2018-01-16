using AlexaWorld.SkillKit.Directives;
using AlexaWorld.SkillKit.Interfaces;
using System.Collections.Generic;

namespace AlexaWorld.SkillKit.Objects
{
	public class Device
	{
		public string DeviceId { get; set; }

		public List<ISupportedInterface> SupportedInterfaces { get; set; }
	}
}