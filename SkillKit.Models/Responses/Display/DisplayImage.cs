using System.Collections.Generic;

namespace AlexaWorld.SkillKit.Responses.Display
{
    /// <summary>
    /// https://developer.amazon.com/docs/custom-skills/display-interface-reference.html#image-object-specifications
    /// </summary>
    public class DisplayImage
    {
        public string ContentDescription { get; set; }

        public List<DisplayImageSource> Sources { get; set; }

    }
}