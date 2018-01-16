using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaWorld.SkillKit.Helpers
{
	public static class IListExtensions
	{
		public static T GetRandomItem<T>(this IList<T> list)
		{
			var r = new Random((int)DateTime.Now.TimeOfDay.TotalMilliseconds);
			return list[r.Next(0, list.Count - 1)];
		}
	}
}
