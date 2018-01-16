using System;
using System.Collections.Generic;
using System.Text;
using static AlexaWorld.SkillKit.AMAZON.Display;

namespace AlexaWorld.SkillKit.Responses.Display
{
	public class ListTemplate : BodyTemplate
	{
		public ListTemplate()
		{ }

		public ListTemplate(ListTemplateType templateType)
		{
			Type = templateType.ToString();
		}

		public List<IListItem> ListItems { get; set; }


	}
}
