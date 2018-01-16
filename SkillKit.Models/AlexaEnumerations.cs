using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaWorld.SkillKit
{
	// Used by Intent and Slot
	public enum ConfirmationStatusEnum
	{
		NONE,
		CONFIRMED,
		DENIED
	}

	// Used by AudioPlayer and PlaybackState
	public enum PlayerActivityEnum
	{
		PLAYING,
		PAUSED,
		FINISHED,
		BUFFER_UNDERRUN,
		IDLE
	}




}
