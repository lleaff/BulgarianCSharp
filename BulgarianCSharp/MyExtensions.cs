using MiscUtil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
	//for the Sort<T>() method
	public enum SortOption { Selection, Ascending, Descending };
	public enum SearchOption { Binary };
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

		#region Arrays & Lists

		public static T[] ToArray<T>(this IList<T> list)
		{
			T[] array = new T[list.Count];
			for (int i = list.Count - 1; i >= 0; i--)
			{
				array[i] = list[i];
			}
			return array;
		}

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

		public static void Fill<T>(this IList<T> array, T value)
		{
			for (int i = array.Count - 1; i >= 0; i--)
			{
				array[i] = value;
			}
		}

		public static IList<T> Sort<T>(this IList<T> array, SortOption algorithm = SortOption.Selection, SortOption order = SortOption.Ascending) where T : IComparable
		{
			if (array == null)
			{
				return null;
			}
			if (algorithm == SortOption.Selection)
			{
				for (int i = 0, j = 0, smallestValueIndex = 0; i < array.Count - 1; i++, j = i, smallestValueIndex = i)
				{
					T smallestValue = order == SortOption.Ascending ? array.Max() : array.Min();
					for (; j < array.Count; j++)
					{
						if ((order == SortOption.Ascending && array[j].CompareTo(smallestValue) <= 0) || (order == SortOption.Descending && array[j].CompareTo(smallestValue) >= 0))
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
			return (T[])((IList<T>)array).Sort(algorithm, order);
		}

		/// <summary>
		/// Search for a value in an array of IComparable values, returns -1 if the value isn't foud.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
		/// <param name="value">The value to search for.</param>
		/// <param name="algorithm">The algorithm used for searching.</param>
		/// <returns></returns>
		//public static int Search<T>(this T[] array, T value, SearchOption algorithm = SearchOption.Binary) where T : IComparable //TODO
		//{
		//	int index = -1;
		//	if (algorithm == SearchOption.Binary)
		//	{
		//		bool lC = false; //last check flag
		//		for (int i = 0, subMin = 0, subMax = array.Length - 1; subMax != 1 && (!lC || subMin != array.Length - 2); )
		//		{
		//			i = ((subMax - subMin) / 2) + Math.Max(0, subMin);
		//			if ( array[i].CompareTo(value) == 0)
		//			{
		//				index = i;
		//				break;
		//			}
		//			else if (array[i].CompareTo(value) > 0)
		//			{
		//				subMax = i - 1;
		//			}
		//			else if (array[i].CompareTo(value) < 0)
		//			{
		//				subMin = i;
		//			}
		//			if ()
		//		}
		//		return index;
		//	}
		//	else
		//	{
		//		Console.WriteLine("ERROR: wrong algorithm");
		//		return -1;
		//	}
		//}

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

		public static bool Contains<T>(this IList<T> array, T value) where T : IComparable
		{
			foreach (T arrayVal in array)
			{
				if (value.CompareTo(arrayVal) == 0)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns the index of the biggest value in the array.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
		/// <param name="start">From what index to start scanning</param>
		/// <param name="end">At what index to stop scanning</param>
		/// <returns></returns>
		public static int Biggest<T>(this IList<T> array, int start = 0, int end = Int32.MaxValue) where T : IComparable
		{
			T biggestValue = array[0];
			int biggestValueIndex = 0;
			for (int i = start; i < array.Count && i < end; i++)
			{
				if ((array[i].CompareTo(biggestValue)) > 0)
				{
					biggestValue = array[i];
					biggestValueIndex = i;
				}
			}
			return biggestValueIndex;
		}

		/// <summary>
		/// Finds the most frequently occuring value in an array.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
		/// <param name="position">1 for most frequent value, 2 for second most frequent, ...</param>
		/// <returns>Default value: array[0]</returns>
		public static T MostFrequentValue<T>(this IList<T> array, out int frequencyValue, int position = 1) where T : IComparable
		{
			frequencyValue = 0;
			int[] frequency = new int[array.Count];
			T[] frequencyValues = new T[array.Count];
			for (int i = 0, j = 0; i < array.Count; i++, j = 0)
			{
				if (frequency[i] != 0)
				{
					continue;
				}
				for (; j < array.Count; j++)
				{
					if (array[i].CompareTo(array[j]) == 0 && frequency[j] == 0)
					{
						frequencyValues[i] = frequencyValues[j] = array[i];
						frequency[i]++;
					}
				}
			}
			T result = array[0]; //just for initialization
			for (int i = 0; i < position; i++)
			{
				result = array[frequency.Biggest()];
				frequencyValue = frequency[frequency.Biggest()];

				if (position > 1)
				{
					frequency[frequency.Biggest()] = 0;
				}
			}
			return result;
		}

		public static T MostFrequentValue<T>(this IList<T> array, int position = 1) where T : IComparable
		{
			int buffer;
			return array.MostFrequentValue(out buffer, position);
		}

		public static T[] ConsecutiveWithSum<T>(this T[] array, T sum) where T : IComparable
		{
			int indexStart = 0, indexEnd = 0;
			bool success = false; ;
			for (int i = 0, j = 0; i < array.Length; i++, j = i)
			{
				if (success)
				{
					break;
				}
				T currentSum = default(T);
				for (; j < array.Length; j++)
				{
					currentSum = Operator.Add(currentSum, array[j]);
					if (currentSum.CompareTo(sum) == 0)
					{
						indexStart = i;
						indexEnd = j;
						success = true;
						break;
					}
				}
			}
			if (!success)
			{
				return new T[0];
			}
			T[] series = new T[indexEnd - indexStart + 1];
			for (int i = 0, j = indexStart; j <= indexEnd; i++, j++)
			{
				series[i] = array[j];
			}
			return series; ;
		}

		public static IList<decimal> MaxSumSubsequence(this IList<decimal> array)
		{
			if (array == null)
			{
				return null;
			}
			decimal maxSum = array.Min();
			int maxSumStart = 0;
			int maxSumEnd = 0;
			decimal sum = 0;
			for (int i = 0, j = 0; i < array.Count; i++, j = i, sum = 0)
			{
				for (; j < array.Count; j++)
				{
					sum += array[j];
					if (sum > maxSum)
					{
						maxSum = sum;
						maxSumStart = i;
						maxSumEnd = j;
					}
					else if (sum < 0)
					{
						i = Math.Min(j, array.Count - 1);
						break;
					}
				}
			}
			IList<decimal> subsequence = new List<decimal>();
			//fill return list with values from input list
			for (int j = maxSumStart; j <= maxSumEnd; j++)
			{
				subsequence.Add(array[j]);
			}
			return (IList<decimal>)subsequence;
		}

		public static decimal[] MaxSumSubsequence(this decimal[] array)
		{
			return array.ToList<decimal>().MaxSumSubsequence().ToArray<decimal>();
		}

		public static int[] MaxSumSubsequence(this int[] array)
		{
			decimal[] convertedArray = Array.ConvertAll(array, val => (decimal)val);
			convertedArray = convertedArray.ToList<decimal>().MaxSumSubsequence().ToArray<decimal>();
			return Array.ConvertAll(convertedArray, val => (int)val);
		}

		public static double[] MaxSumSubsequence(this double[] array)
		{
			decimal[] convertedArray = Array.ConvertAll(array, val => (decimal)val);
			convertedArray = convertedArray.ToList<decimal>().MaxSumSubsequence().ToArray<decimal>();
			return Array.ConvertAll(convertedArray, val => (double)val);
		}

		#endregion Arrays & Lists

		#region Arrays 2D

		/// <summary>
		/// Returns a single dimensional array from a two dimensional one
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="matrix"></param>
		/// <param name="extractY">Index [y,-] of the row to extract</param>
		/// <param name="extractX">Index [-, x] of the column to extract, leave to default value to extract a row</param>
		/// <param name="start">Index of the value from which to start extracting in the chosen slice</param>
		/// <param name="end">Index of the value after which to stop extracting in the chosen slice</param>
		/// <returns></returns>
		public static T[] Extract<T>(this T[,] matrix, int extractY, int extractX = Int32.MinValue, int start = 0, int end = 0)
		{
			end = end == 0 ? matrix.GetLength(1) - 1 : end;
			T[] array = new T[end - start + 1];
			if (extractX == Int32.MinValue)
			{
				for (int x = end; x >= start; x--)
				{
					array[x - start] = matrix[extractY, x];
				}
			}
			else
			{
				for (int y = end; y >= start; y--)
				{
					array[y - start] = matrix[y, extractX];
				}
			}
			return array;
		}

		public static int[] Biggest<T>(this T[,] matrix) where T : IComparable
		{
			int[] biggestInX = new int[matrix.GetLength(0)];
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				biggestInX[i] = matrix.Extract(i).Biggest();
			}
			int x = 0, y = 0;
			y = biggestInX.Biggest();
			x = biggestInX[y];
			return new int[] { y, x };
		}

		/// <summary>
		/// Swap the x and y axes in a 2d array
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="matrixXY"></param>
		/// <returns>The array with swapped axes</returns>
		public static T[,] SwapAxes<T>(this T[,] matrixXY)
		{
			int xLength = matrixXY.GetLength(0);
			int yLength = matrixXY.GetLength(1);
			T[,] matrixYX = new T[yLength, xLength];
			for (int y = yLength - 1, x = xLength - 1; y >= 0; y--, x = xLength - 1)
			{
				for (; x >= 0; x--)
				{
					matrixYX[y, x] = matrixXY[x, y];
				}
			}
			return matrixYX;
		}

		/// <summary>
		/// Swap the values of two specified slices in the specified dimension
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="matrix"></param>
		/// <param name="dimension">0: swap columns (y), 1: swap rows (x)</param>
		/// <param name="slice1">Which row or column to swap</param>
		/// <param name="slice2">Which row or column to swap with the other</param>
		/// <returns></returns>
		public static T[,] SwapSlices<T>(this T[,] matrix, int dimension, int slice1, int slice2)  
		{
			T[,] matrixSwapped = matrix;
			for (int i = matrix.GetLength(dimension) - 1; i >= 0; i--)
			{
				if (dimension == 0)
				{
					matrixSwapped[i, slice1] = matrix[i, slice2];
					matrixSwapped[i, slice2] = matrix[i, slice1];
				}
				else
				{
					matrixSwapped[slice1, i] = matrix[slice2, i];
					matrixSwapped[slice2, i] = matrix[slice1, i];
				}
			}
			return matrixSwapped;
		}

		/// <summary>
		/// Prints a 2D matrix
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="matrix"></param>
		/// <param name="separator">Character to insert between the values</param>
		/// <param name="swapXY">Swap the X and Y axes</param>
		/// <param name="highlight">Format: {{topLeftCornerX, topLeftCornerY}{botRightCornerX, botRightCornerY}}, highlights a platform</param>
		public static void Print<T>(this T[,] matrix, string separator = ",", bool swapXY = false, int[,] highlight = null)
		{
			highlight = highlight ?? new int[,] { { -1, -1 }, { -1, -1 } }; //no highlight
			//highlight = swapXY ? highlight.SwapAxes() : highlight;
			//find alignment value
			int stringLength = 1;
			foreach (T value in matrix)
			{
				stringLength = value.ToString().Length > stringLength ? value.ToString().Length : stringLength;
			}
			T[,] matrixB;
			int maxX = 0;
			int maxY = 0;
			if (swapXY)
			{
				matrixB = matrix.SwapAxes();
			}
			else
			{
				matrixB = matrix;
			}
			maxX = matrixB.GetLength(1);
			maxY = matrixB.GetLength(0);
			for (int y = 0; y < maxY; y++)
			{
				for (int x = 0; x < maxX; x++)
				{
					string format = String.Format("{{1}}{{0,{0}}}{{2}}", stringLength);
					Console.Write(format, matrixB[y, x], (x == highlight[0, 0] && y >= highlight[0, 1] && y <= highlight[1, 1]) ? "[" : " ", (x == highlight[1, 0] && y >= highlight[0, 1] && y <= highlight[1, 1]) ? "]" : ((x < maxX - 1) ? separator : " "));
				}
				Console.WriteLine();
			}
		}

		/// <summary>
		/// Finds the platform of specified size with the maximum sum
		/// </summary>
		/// <param name="matrix"></param>
		/// <returns>{{topLeftCornerX, topLeftCornerY}, {botRightCornerX, botRightCornerY}}</returns>
		public static int[,] MaxSumPlatform(this int[,] matrix, int platformX, int platformY = 0)
		{
			platformY = (platformY == 0) ? platformX : platformY;
			int xMax = matrix.GetLength(0);
			int yMax = matrix.GetLength(1);
			int[,] platform = new int[2, 2];
			int sum = 0;
			int biggestSum = Int32.MinValue;
			for (int y = 0; y < yMax - platformY; y++)
			{
				for (int x = 0; x < xMax - platformX; x++, sum = 0)
				{
					for (int currY = y; currY < y + platformY - 1; currY++)
					{
						for (int currX = x; currX < x + platformX - 1; currX++)
						{
							sum += matrix[currY, currX];
						}
					}
					Console.WriteLine(".sum " + sum);
					if (sum >= biggestSum)
					{
						biggestSum = sum;
						platform[0, 0] = x;
						platform[0, 1] = y;
					}
				}
			}
			platform[1, 0] = platform[0, 0] + platformX - 1;
			platform[1, 1] = platform[0, 1] + platformY - 1;
			return platform;
		}

		/// <summary>
		/// Finds the longest sequence of equal elements in a 2d array
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="matrix"></param>
		/// <param name="diagonal">Whether to check for diagonal sequences or not</param>
		/// <param name="vertical">Whether to check for vertical sequences or not</param>
		/// <param name="horizontal">Whether to check for horizontal sequences or not</param>
		/// <returns>The {y, z} indices of each member of the sequence</returns>
		public static int[,] LongestSequence<T>(this T[,] matrix, bool diagonal = true, bool vertical = true, bool horizontal = true) where T : IComparable
		{
			int yMax = matrix.GetLength(0);
			int xMax = matrix.GetLength(1);
			int[, ,] sequences = new int[yMax, xMax, 4]; //3rd dimension is sequence length in: [0] horizontal [1] vertical [2] diagonal1 [3] diagonal2
			for (int y = 0, x = 0; y < yMax; y++, x = 0)
			{
				for (; x < xMax; x++)
				{
					if (horizontal && x > 0)
					{
						if (matrix[y, x].CompareTo(matrix[y, x - 1]) == 0 && sequences[y, x, 0] == 0)
							sequences[y, x, 0] = sequences[y, x - 1, 0] + 1;
					}
					if (vertical && y > 0)
					{
						if (matrix[y, x].CompareTo(matrix[y - 1, x]) == 0 && sequences[y, x, 1] == 0)
							sequences[y, x, 1] = sequences[y - 1, x, 1] + 1;
					}
					if (diagonal && x - 1 > 0 && y - 1 > 0)
					{
						if (matrix[y, x].CompareTo(matrix[y - 1, x - 1]) == 0 && sequences[y, x, 2] == 0)
							sequences[y, x, 2] = sequences[y - 1, x - 1, 2] + 1;
					}
					if (diagonal && x - 1 > 0 && y + 1 < xMax)
					{
						if (matrix[y, x].CompareTo(matrix[y + 1, x - 1]) == 0 && sequences[y, x, 3] == 0)
							sequences[y, x, 3] = sequences[y + 1, x - 1, 3] + 1;
					}
				}
			}
			int[] seqEndIndex = sequences.Biggest();

			#region DEBUG

			//for (int d = 0; d < 4; d++) //DEBUG
			//{ //DEBUG
			//	string dimensionName; //DEBUG
			//	switch (d) //DEBUG
			//	{ //DEBUG
			//		case 0: dimensionName = "horizontal [-]"; //DEBUG
			//			break; //DEBUG
			//		case 1: dimensionName = "vertical [|]"; //DEBUG
			//			break; //DEBUG
			//		case 2: dimensionName = "diagonal [\\]"; //DEBUG
			//			break; //DEBUG
			//		case 3: dimensionName = "diagonal [/]"; //DEBUG
			//			break; //DEBUG
			//		default: dimensionName = ""; //DEBUG
			//			break; //DEBUG
			//	} //DEBUG
			//	Console.WriteLine(dimensionName + " sequences[y,x,"+ d + "]:"); //DEBUG
			//	sequences.Extract(d, 2).Print(); //DEBUG
			//} //DEBUG

			#endregion DEBUG

			int[,] seqIndices = new int[2, sequences[seqEndIndex[0], seqEndIndex[1], seqEndIndex[2]] + 1];
			int seqLength = sequences[seqEndIndex[0], seqEndIndex[1], seqEndIndex[2]] + 1;
			//Console.WriteLine("seqLength=" + seqLength);//DEBUG
			//Console.WriteLine("seqEndIndex=" + seqEndIndex[0] + "," + seqEndIndex[1] + "," + seqEndIndex[2]);//DEBUG
			for (int y = seqEndIndex[0], x = seqEndIndex[1], c = 0; c < seqLength; c++)
			{
				seqIndices[0, seqLength - 1 - c] = y;
				seqIndices[1, seqLength - 1 - c] = x;

				if (seqEndIndex[2] == 0) //horizontal
				{
					x--;
				}
				else if (seqEndIndex[2] == 1) //vertical
				{
					y--;
				}
				else if (seqEndIndex[2] == 2) //diagonal1
				{
					y--;
					x--;
				}
				else if (seqEndIndex[2] == 3) //diagonal2
				{
					y--;
					x++;
				}
			}
			return seqIndices;
		}

		#endregion Arrays 2D

		#region Arrays 3D

		/// <summary>
		/// Finds the biggest value in a 3 dimensional array.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="matrix"></param>
		/// <param name="subTopLeftXY">Enclosing box top left corner {z, y, x}</param>
		/// <param name="subBotRightXY">Enclosing box bottom right corner {z, y , x} (botRight z = topLeft z)</param>
		/// <param name="subDepth">Enclosing box depth {z}</param>
		/// <returns>{z, y, x} index of the biggest value found in the matrix</returns>
		public static int[] Biggest<T>(this T[, ,] matrix, int[] subTopLeftXY = null, int[] subBotRightXY = null, int subDepth = 0) where T : IComparable
		{
			int maxZ, maxY, maxX;
			if (subTopLeftXY == null || subTopLeftXY[0] != subBotRightXY[0])
			{
				maxX = matrix.GetLength(2);
				maxY = matrix.GetLength(1);
				maxZ = matrix.GetLength(0);
				subTopLeftXY = subTopLeftXY ?? new int[] { 0, 0, 0 };
				subBotRightXY = subBotRightXY ?? new int[] { maxZ, maxY, maxX };
			}
			else
			{
				maxX = subBotRightXY[2] - subTopLeftXY[2] + 1;
				maxY = subBotRightXY[1] - subTopLeftXY[1] + 1;
				maxZ = subDepth + subTopLeftXY[0] + 1;
			}
			T biggest = default(T);
			int[] biggestIndex = new int[3];
			bool biggestIsDefault = true;
			for (int z = subTopLeftXY[0], y = subTopLeftXY[1], x = subTopLeftXY[2]; z < maxZ; z++, y = 0)
			{
				for (; y < maxY; y++, x = 0)
				{
					for (; x < maxX; x++)
					{
						if (matrix[z, y, x].CompareTo(biggest) > 0 || biggestIsDefault)
						{
							biggest = matrix[z, y, x];
							biggestIndex[0] = z;
							biggestIndex[1] = y;
							biggestIndex[2] = x;
							biggestIsDefault = false;
						}
					}
				}
			}
			return biggestIndex;
		}

		public static T[,] Extract<T>(this T[, ,] matrix3d, int z, int dimension = 2)
		{
			T[,] matrix2d = new T[matrix3d.GetLength(dimension == 0 ? 1 : 0), matrix3d.GetLength(dimension == 1 ? 2 : 1)];
			//copy values to new array

			for (int matrix2dYLength = matrix2d.GetLength(0), matrix2dXLength = matrix2d.GetLength(1), y = matrix2dYLength - 1, x = matrix2dXLength - 1; y >= 0; y--, x = matrix2dXLength - 1)
			{
				for (; x >= 0; x--)
				{
					if (dimension == 0)
						matrix2d[y, x] = matrix3d[z, y, x];
					if (dimension == 1)
						matrix2d[y, x] = matrix3d[y, z, x];
					if (dimension == 2)
						matrix2d[y, x] = matrix3d[y, x, z];
				}
			}
			return matrix2d;
		}

		#endregion Arrays 3D
	}
}