using System;
using System.Collections.Generic;

namespace AlexaWorld.SkillKit
{
	public static class Guard
	{
		public static void ArgumentNotNull(object value, string argumentName)
		{
			if (value == null)
				throw new ArgumentNullException(argumentName);
		}

		public static void ArgumentNotNullOrEmpty(string value, string argumentName)
		{
			if (value == null)
				throw new ArgumentNullException(argumentName);

			if (string.IsNullOrEmpty(value))
				throw new ArgumentException($"<{argumentName}> IsNullOrEmpty", argumentName);
		}

		//public static void ValidateRequestVersion(JObject jObject, string version)
		//{
		//	var version = jObject.Value<string>("version");
		//	if (version != null && version != Sdk.VERSION)
		//	{
		//		throw new Exception("Request must conform to 1.0 schema.");
		//	}
		//}

		public static void ArgumentNotNullOrEmpty<T>(IReadOnlyCollection<T> collection, string argumentName)
		{
			if (collection == null)
				throw new ArgumentNullException(argumentName);

			if (collection.Count <= 0)
				throw new ArgumentException($"<{argumentName}> has no items.");
		}

		public static void ArgumentValid(bool valid, string argumentName)
		{
			if (!valid)
				throw new ArgumentException($"Invalid argument <{argumentName}>");
		}

		public static void ArgumentValid(Func<bool> validator, string argumentName)
		{
			if (!validator())
				throw new ArgumentException($"Invalid argument <{argumentName}>");
		}

		public static void ArgumentValid(int value, int min, int max, string argumentName)
		{
			if ((value > max) || (value < min))
				throw new ArgumentOutOfRangeException(
					$"<{argumentName}> value: {value} | min: {min} | max: {max}");
		}

		public static void NullRequired(object item, string message)
		{
			if (item != null)
				throw new InvalidOperationException(message);
		}

		public static void ArgumentNotSameReference(object a, object b)
		{
			if (ReferenceEquals(a, b))
				throw new ArgumentException("ReferenceEquals");
		}

		public static void NotNullOrEmpty(string value, string error)
		{
			if (value == null)
				throw new ArgumentNullException(error);

			if (string.IsNullOrEmpty(value))
				throw new ArgumentException(error);
		}

		public static void NotDisposed(bool disposed, string objectName)
		{
			if (disposed)
				throw new ObjectDisposedException(objectName);
		}

		public static void OperationValid(bool valid, string exceptionMessage)
		{
			if (!valid)
				throw new InvalidOperationException(exceptionMessage);
		}

		public static T ExceptionWhenNull<T>(T value)
		{
			if (value == null)
				throw new Exception(typeof(T).ToString());
			else
				return value;
		}
	}
}
