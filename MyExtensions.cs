using System;
using System.Collections.Generic;

namespace ExtensionMethods
{
	public static class MyExtensions
	{
		/// <summary>
		/// Returns whether a string goes before another alphabetically or is equal to.
		/// Doesn't take case into account.
		/// </summary>
		/// <param name="string1"></param>
		/// <param name="string2"></param>
		/// <returns></returns>
		public static bool ComesFirst(this string string1, string string2)
		{
			char[][] arrays = new char[2][];
			arrays[0] = string1.ToLower().ToCharArray();
			arrays[1] = string2.ToLower().ToCharArray();
			for (int i = 0; i < arrays[0].Length && i < arrays[1].Length; i++)
			{
				if (arrays[0][i] > arrays[1][i])
					return false;
				else if (arrays[0][i] < arrays[1][i])
					return true; 
			}
			return true;
		}

		public static int Factorial(this int input, int startFrom = 1)
		{
			int result = 1;
			if (input < 0)
			{
				result = 0;
			}
			else if (input <= 1)
			{
				result = 1;
			}
			else if (input <= 12)
			{
				for (; input > startFrom; input--)
				{
					result = result * (input);
				}
			}
			else
			{
				Console.WriteLine("Result too big for int type, 12! is biggest possible");
				result = Int32.MaxValue;
			}
			return result;
		}

		public static int FactorialDivision(this int input1, int input2)
		{
			int result = input1.Factorial(input2);
			return result;
		}

		#region Arrays

		public static bool IsSymmetric<T>(this T[] input) where T : IComparable
		{ //idk if the "where" is needed with Equals()
			if (input.Length <= 1)
			{
				return true;
			}
			else
			{
				for (int i = 0; i < input.Length / 2; i++)
				{
					if (!input[i].Equals(input[input.Length - 1 - i]))
					{
						return false;
					}
				}
				return true;
			}
		}

		public static void Print<T>(this IList<T> array, bool newline = true, string separator = "", int start = 0, int end = Int32.MinValue)
		{
			if (end == Int32.MinValue)
			{
				end = array.Count - 1;
			}
			for (int i = start; i <= end; i++)
			{
				Console.Write(array[i] + (i != end ? separator : "") + (newline ? Environment.NewLine : ""));
			}
		}

		public static bool IsEqualTo<T>(this IList<T> array1, IList<T> array2)
		{
			if (array1.Count != array2.Count)
			{
				return false;
			}
			for (int i = 0; i < array1.Count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(array1[i], array2[i]))
				{
					return true;
				}
			}
			return false;
		}


		#endregion Arrays
	}
}