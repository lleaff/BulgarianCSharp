using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
	//for the Sort<T>() method
	public enum SortOption { Selection, Ascending, Descending };

	public static class MyExtensions
	{


		public static void Swap<T>(this T val1, T val2)
		{
			T bufferVal = val2;
			val2 = val1;
			val1 = bufferVal;
		}

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

		public static void Fill<T>(this IList<T> array, T value) {
			for (int i = array.Count - 1; i >= 0; i--) {
				array [i] = value;
			}
		}
  

		public static IList<T> Sort<T>(this IList<T> array, SortOption algorithm = SortOption.Selection, SortOption order = SortOption.Ascending) where T : IComparable {
		if (array == null)
			{
				return null;
			}
			if (algorithm == SortOption.Selection)
			{
				for (int i = 0, j = 0, smallestValueIndex = 0; i < array.Count- 2; i++, j = i, smallestValueIndex = i)
				{
					T smallestValue = order == SortOption.Ascending ? array.Max() : array.Min();
					for (; j < array.Count; j++)
					{
						if ((order == SortOption.Ascending && array[j].CompareTo(smallestValue) < 0) || (order == SortOption.Descending && array[j].CompareTo(smallestValue) > 0))
						{
							smallestValue = array[j];
							smallestValueIndex = j;
						}
					}
					T swapBuffer = array[i];
					array[i] = array[smallestValueIndex];
					array[smallestValueIndex] = swapBuffer;
				}
				return array;
			}
			return null;
		}

		public static T[] Sort<T>(this T[] array, SortOption algorithm = SortOption.Selection, SortOption order = SortOption.Ascending) where T : IComparable
		{
			IList<T> result = ((IList<T>)array).Sort(algorithm, order);
			return (T[])result;
			
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

		public static int Biggest<T>(this IList<T> array) where T : IComparable { //TODO
			T biggestValue = array [0];
			int biggestValueIndex = 0;
			for (int i = 0; i < array.Count; i++) {
				if ((array [i].CompareTo (biggestValue)) > 0) {
					biggestValue = array [i];
					biggestValueIndex = i;
				}
			}
			return biggestValueIndex;
		}

		#endregion Arrays
	}
}