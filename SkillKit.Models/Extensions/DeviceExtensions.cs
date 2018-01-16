using AlexaWorld.SkillKit.Directives;
using AlexaWorld.SkillKit.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlexaWorld.SkillKit.Extensions
{
	public static class DeviceExtensions
	{
		public static bool IsInterfaceSupported(this Device device, InterfaceType interfaceType)
		{
			return device.SupportedInterfaces.Any(item => item.Type == interfaceType);
		}
	}
}
