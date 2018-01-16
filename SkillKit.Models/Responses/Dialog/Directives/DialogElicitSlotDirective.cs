﻿namespace AlexaWorld.SkillKit.Interfaces.Dialog.Directives
{
    /// <summary>
    /// https://developer.amazon.com/docs/custom-skills/dialog-interface-reference.html#elicitslot
    /// </summary>
    public class DialogElicitSlotDirective : DialogDirective
    {
        public DialogElicitSlotDirective() : base("ElicitSlot") {

        }

        public virtual string SlotToElicit {
            get;
            set;
        }
    }
}