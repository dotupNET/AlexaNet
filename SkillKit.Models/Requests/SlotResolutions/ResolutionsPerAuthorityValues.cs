using System.Collections.Generic;

namespace AlexaWorld.SkillKit.Requests.SlotResolutions
{
	public class ResolutionsPerAuthorityValues
	{
		public ResolutionsPerAuthorityValues()
		{ }

		public ResolutionsPerAuthorityValues(List<ResolutionsPerAuthorityValuesValue> items)
		{
			Values = items;
		}

		public List<ResolutionsPerAuthorityValuesValue> Values { get; set; }
	}
}