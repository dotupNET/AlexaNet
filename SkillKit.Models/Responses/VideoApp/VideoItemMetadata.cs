﻿namespace AlexaWorld.SkillKit.Interfaces.VideoApp
{
    /// <summary>
    /// https://developer.amazon.com/docs/custom-skills/videoapp-interface-reference.html#parameters-of-response
    /// </summary>
    public class VideoItemMetadata
    {
        public virtual string Title {
            get;
            set;
        }

        public virtual string Subtitle {
            get;
            set;
        }
    }
}