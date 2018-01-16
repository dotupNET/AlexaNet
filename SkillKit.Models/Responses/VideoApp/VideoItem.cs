﻿namespace AlexaWorld.SkillKit.Interfaces.VideoApp
{
    /// <summary>
    /// https://developer.amazon.com/docs/custom-skills/videoapp-interface-reference.html#parameters-of-response
    /// </summary>
    public class VideoItem
    {
        public virtual string Source {
            get;
            set;
        }

        public virtual VideoItemMetadata Metadata {
            get;
            set;
        }
    }
}