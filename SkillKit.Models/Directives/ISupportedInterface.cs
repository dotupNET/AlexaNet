using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaWorld.SkillKit.Directives
{
	public enum InterfaceType
	{
		AudioPlayer,
		Display
	}
	public interface ISupportedInterface
	{
		InterfaceType Type { get; }
	}
}
