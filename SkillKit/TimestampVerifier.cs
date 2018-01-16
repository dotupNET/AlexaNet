using AlexaWorld.SkillKit.Requests;
using System;
using System.Diagnostics;

namespace AlexaWorld.SkillKit
{
	public class TimestampVerifier
	{
		/// <summary>
		/// Verifies request timestamp
		/// </summary>
		public static bool Verify(IRequest request, DateTime referenceTimeUtc)
		{
			// verify timestamp is within tolerance
			var diff = referenceTimeUtc - request.Timestamp;
			Debug.WriteLine("Request was timestamped {0:0.00} seconds ago.", diff.TotalSeconds);
			return (Math.Abs((decimal)diff.TotalSeconds) <= Sdk.TIMESTAMP_TOLERANCE_SEC);
		}
	}
}