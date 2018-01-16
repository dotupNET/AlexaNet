using System;
using System.Globalization;

namespace AlexaWorld.SkillKit
{
	public class AlexaDate
	{
		public static DateTime FromString(string value)
		{
			try
			{
				var usCulture = "en-US";
				var result = DateTime.Parse(value, new CultureInfo(usCulture, false));
				return result;
			}
			catch (Exception)
			{
				return FromUnixTimeMilliseconds(value).DateTime;
			}
		}


		/// <summary>
		/// Mirror DateTimeOffset.FromUnixTimeMilliseconds method signature introduced in .NET Framework 4.6
		/// https://msdn.microsoft.com/en-us/library/system.datetimeoffset.fromunixtimemilliseconds(v=vs.110).aspx
		/// </summary>
		/// <param name="timestamp">
		/// A Unix time, expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z (January 1, 1970, at 12:00 AM UTC). For Unix times before this date, its value is negative.
		/// </param>
		/// <returns>
		/// A date and time value that represents the same moment in time as the Unix time.
		/// </returns>
		public static DateTimeOffset FromUnixTimeMilliseconds(string timestamp)
		{
			long milliseconds;
			if (!long.TryParse(timestamp, out milliseconds) ||
					milliseconds < -62135596800000 ||
					milliseconds > 253402300799999)
			{
				throw new ArgumentOutOfRangeException("timestamp");
			}

			var epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeZoneInfo.Utc.BaseUtcOffset);
			return epoch.AddMilliseconds(milliseconds);
		}
	}
}
