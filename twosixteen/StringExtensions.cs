using System;

namespace TwoSixteen
{
	public static class StringExtensions
	{
		public static string Capitalize(this String str)
		{
			return Char.ToUpper(str[0]) + str.Substring(1);
		}
	}
}