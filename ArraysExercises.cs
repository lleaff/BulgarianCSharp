using ExtensionMethods;
using System;
using System.Collections.Generic;

namespace FundamentalsOfProgrammingWithCSharp
{
	internal class ArraysExercises
	{
		//Test variables
		private static int[][] testIntArrays = {
		new int[] { -777, 3, 100, 56, -4, 100, 56, -50, 9999, 100, 0, 20 },
		new int[] { 40, 20, -100, 10, 90, -5 },
		new int[]{ -3234, 456, -14, 3205, -324, 12, -432, 8 },
		new int[] { 44 },
		};

		private static int[,] testIntMatrice1 = new int[,] {
		{35, 560, 3459, 0, 53},
		{64, 35, 54, 456, 99999},
		{-1, 435, -20, 4533, 43}};

		public static void DoExercises()
		{
			string exercise = "";
			while (exercise != "q")
			{
				Console.WriteLine("Exercise n°?");
				exercise = Console.ReadLine();
				ConsoleOutput.Title(exercise);

				#region Exercise 1

				if (exercise == "1")
				{
					int[] myArray = new int[20];

					for (int i = 0; i < myArray.Length; i++)
					{
						myArray[i] = i * 5;

						Console.Write("{0}{1}", myArray[i], (i < myArray.Length - 1) ? ", " : ("." + Environment.NewLine));
					}
				}

				#endregion Exercise 1

				#region Exercise 2

				if (exercise == "2")
				{
					double[][] arrays = new double[2][];

					List<double>[] bufferLists = new List<double>[2];

					bufferLists[0] = new List<double>();

					bufferLists[1] = new List<double>();

					Console.WriteLine("Input numbers to be put into an array. When you're finished press {Enter} to fill a second array");
					for (int c = 0; c <= 1; )
					{
						Console.WriteLine(c == 0 ? "First array:" : "Second array");
						double input;
						while (true)
						{
							string inputStr = Console.ReadLine();
							if (Double.TryParse(inputStr, out input))
							{
								bufferLists[c].Add(input);
							}
							else if (inputStr == "")
							{
								arrays[c] = new double[bufferLists[c].Count];
								//copy list to array
								for (int i = 0; i < arrays[c].Length; i++)
								{
									arrays[c][i] = bufferLists[c][i];
								}
								c++;
								break;
							}
							else
							{
								Console.WriteLine("input a real number please");
							}
						}
					}
					Console.Write("The two arrays");

					if (arrays[0].IsEqualTo(arrays[1]))
					{
						Console.Write(" are equal\n");
					}
					else
					{
						Console.Write(" aren't equal\n");
					}

					//Equality test
					//if (arrays[0].Length != arrays[1].Length)
					//	Console.Write(" aren't equal\n");
					//else
					//{
					//	bool equal = true;
					//	for (int i = 0; i < arrays[0].Length; i++)
					//	{
					//		if (arrays[0][i] != arrays[1][i])
					//		{
					//			Console.Write(" aren't equal\n");
					//			equal = false;
					//			break;
					//		}
					//	}
					//	if (equal)
					//	{
					//		Console.Write(" are equal\n");
					//	}
					//}
				}

				#endregion Exercise 2

				#region Exercise 3

				if (exercise == "3")
				{
					Console.WriteLine("Input 2 words to sort alphabetically");
					string[] inputs = new string[] { Console.ReadLine(), Console.ReadLine() };
					if (inputs[0] == inputs[1])
					{
						Console.WriteLine("The words are the same.");
					}
					else
					{
						Console.Write(inputs[0]);
						if (inputs[0].ComesFirst(inputs[1]))
						{
							Console.Write(" comes before ");
						}
						else
						{
							Console.Write(" comes after ");
						}
						Console.Write(inputs[1] + Environment.NewLine);
					}
				}

				#endregion Exercise 3

				#region Exercise 4

				if (exercise == "4")
				{
					Console.WriteLine("Input integers to put in an array, separated by commas");
					int[] nums = ConsoleInput.ReadIntArrayCommaSeparated();
					int[] seriesLength = new int[nums.Length];
					seriesLength.Fill(1);
					//Series check
					for (int i = 1; i < nums.Length; i++)
					{
						if (nums[i] == nums[i - 1])
						{
							seriesLength[i] = seriesLength[i - 1] + 1;
						}
					}

					int iB = seriesLength.Biggest();
					int[] series = new int[seriesLength[iB]];
					series.Fill(nums[iB]);
					Console.WriteLine("The biggest series of consecutive integers in this array is :");
					series.Print(false, ", ");
					Console.Write(Environment.NewLine);
				}

				#endregion Exercise 4

				#region Exercise 5

				if (exercise == "5")
				{
					Console.WriteLine("Input integers to put in an array, separated by commas");
					int[] nums = ConsoleInput.ReadIntArrayCommaSeparated();
					int[] seriesLength = new int[nums.Length];
					seriesLength.Fill(1);
					for (int i = 1; i < nums.Length; i++)
					{
						if (nums[i] == nums[i - 1] + 1)
						{
							seriesLength[i] = seriesLength[i - 1] + 1;
						}
					}
					int biggestSeriesEndIndex = seriesLength.Biggest();
					int[] series = new int[seriesLength[biggestSeriesEndIndex]];
					//Let's fill the series array with values copied from the original one
					for (int i = 0; i < seriesLength[biggestSeriesEndIndex]; i++)
					{
						series[i] = nums[biggestSeriesEndIndex - seriesLength[biggestSeriesEndIndex] + i + 1];
					}

					Console.WriteLine("The biggest series of consecutively increasing integers is :");
					series.Print(false, ", ");
					Console.Write(Environment.NewLine);
				}

				#endregion Exercise 5

				#region Exercise 6

				if (exercise == "6")
				{
					Console.WriteLine("Input integers separated by commas to put into an array");
					int[] nums = ConsoleInput.ReadIntArrayCommaSeparated();
					int[] numsMarked = new int[nums.Length];
					for (int i = 0; i < nums.Length - 1; i++)
					{
						if (numsMarked[i] == 0)
						{
							for (int c = i + 1, lastGood = c - 1; c < nums.Length - i; c++)
							{
								if (numsMarked[c] == 0 && nums[c] == nums[lastGood] + 1)
								{
									numsMarked[c] = numsMarked[lastGood] + 1;
									lastGood = c;
								}
							}
						}
					}
					int biggestSeriesIndex = numsMarked.Biggest();
					int[] series = new int[numsMarked[biggestSeriesIndex] + 1];
					Console.WriteLine("numsMarked[biggestSeriesIndex] = " + numsMarked[biggestSeriesIndex] + "   biggestSeriesIndex = " + biggestSeriesIndex);//DEBUG
					for (int i = series.Length - 1, n = nums[biggestSeriesIndex]; i >= 0; i--, n--)
					{
						series[i] = n;
					}
					Console.WriteLine("The biggest series of (not necessary consecutive) increasing integers is :");
					series.Print(false, ", ");
					Console.Write(Environment.NewLine);
				}

				#endregion Exercise 6

				#region Exercise 7

				if (exercise == "7")
				{
					Console.WriteLine("Input integers separated by commas to put into an array");
					int[] nums = ConsoleInput.ReadIntArrayCommaSeparated();
					Console.WriteLine("Input a number K (K < {0}), the program will find the series of integers of length K with the maximum sum.", nums.Length);
					int k = ConsoleInput.ReadInt(0, nums.Length);
					int[] sums = new int[nums.Length];
					for (int i = 0; i < nums.Length - k; i++)
					{
						int sum = nums[i];
						for (int s = 1; s <= k; s++)
						{
							sum += nums[s];
						}
						sums[i] = sum;
					}
					int biggestSumStartIndex = sums.Biggest();
					int[] series = new int[k];
					for (int i = biggestSumStartIndex, c = 0; i < biggestSumStartIndex + k; i++, c++)
					{
						series[c] = nums[i];
					}
					Console.WriteLine("The series of {0} consecutive integers with the biggest sum is:", k);
					series.Print(false, ", ");
					Console.Write(Environment.NewLine);
				}

				#endregion Exercise 7

				#region Exercise 8

				if (exercise == "8")
				{
					for (string input = ""; input != "q"; )
					{
						Console.WriteLine("Select an array to sort using a \"selection\" sort algorithm: (\"q\" to quit)");
						Console.Write("1. {");
						testIntArrays[0].Print(false, ", ");
						Console.Write("}" + Environment.NewLine);
						Console.Write("2. {");
						testIntArrays[1].Print(false, ", ");
						Console.Write("}" + Environment.NewLine);
						Console.WriteLine("3. Input array");
						int[] array;
						input = Console.ReadLine();
						switch (input)
						{
							case "1":
								array = testIntArrays[0].Sort(SortOption.Selection);
								break;

							case "2":
								array = testIntArrays[1].Sort(SortOption.Selection);
								break;

							case "3":
								Console.WriteLine("Input integers separated by commas:");
								array = ConsoleInput.ReadIntArrayCommaSeparated();
								array.Sort(SortOption.Selection);
								break;

							default:
								array = new int[] { 0 };
								break;
						}
						if (input != "q")
						{
							Console.Write("Sorted array: {");
							array.Print(false, ", ");
							Console.Write("}" + Environment.NewLine);
						}
					}
				}

				#endregion Exercise 8

				#region Exercise 9

				if (exercise == "9")
				{
					for (string input = ""; input != "q" && input != "quit"; )
					{
						Console.WriteLine("Select an array in which to find the subsequence of maximal sum:");
						ArraysExercises.PrintArraySelection();
						int[] array;
						input = Console.ReadLine();
						switch (input)
						{
							case "1":
								array = testIntArrays[0].MaxSumSubsequence();
								break;

							case "2":
								array = testIntArrays[1].MaxSumSubsequence();
								break;

							case "3":
								array = testIntArrays[2].MaxSumSubsequence();
								break;

							case "4":
								array = testIntArrays[3].MaxSumSubsequence();
								break;

							case "5":
								Console.WriteLine("Input integers separated by commas:");
								array = ConsoleInput.ReadIntArrayCommaSeparated();
								array = array.MaxSumSubsequence();
								break;

							default:
								array = null;
								break;
						}
						if (input != "q" && array != null)
						{
							Console.Write("Maximal sum subsequence: {");
							array.Print(false, ", ");
							Console.WriteLine("}" + Environment.NewLine);
						}
					}
				}

				#endregion Exercise 9

				#region Exercise 10

				if (exercise == "10")
				{
					for (string input = ""; input != "quit" && input != "q"; )
					{
						Console.WriteLine("Select an array in which to find the most frequently occuring value:");
						ArraysExercises.PrintArraySelection();
						int mostFrequentValue = Int32.MinValue;
						int frequency = 0;
						Console.Write("> ");
						input = Console.ReadLine();
						switch (input)
						{
							case "1":
								mostFrequentValue = testIntArrays[0].MostFrequentValue(out frequency);
								break;

							case "2":
								mostFrequentValue = testIntArrays[1].MostFrequentValue(out frequency);
								break;

							case "3":
								mostFrequentValue = testIntArrays[2].MostFrequentValue(out frequency);
								break;

							case "4":
								mostFrequentValue = testIntArrays[3].MostFrequentValue(out frequency);
								break;

							case "5":
								mostFrequentValue = ConsoleInput.ReadIntArrayCommaSeparated().MostFrequentValue(out frequency);
								break;

							default:
								mostFrequentValue = 0;
								break;
						}
						Console.WriteLine("The most frequent value in the array appears {1} and is: {0}", mostFrequentValue, frequency > 1 ? frequency + " times" : "once");
					}
				}

				#endregion Exercise 10

				#region Exercise 11

				if (exercise == "11")
				{
					for (string input = ""; input != "quit" && input != "q"; )
					{
						Console.WriteLine("Input an integer number:");
						int sum = ConsoleInput.ReadInt();
						Console.WriteLine("Select an array in which to find a series of consecutive integers with a sum of {0}:", sum);
						ArraysExercises.PrintArraySelection();
						int[] neighbors;
						Console.Write("> ");
						input = Console.ReadLine();
						switch (input)
						{
							case "1":
								neighbors = testIntArrays[0].ConsecutiveWithSum(sum);
								break;

							case "2":
								neighbors = testIntArrays[1].ConsecutiveWithSum(sum);
								break;

							case "3":
								neighbors = testIntArrays[2].ConsecutiveWithSum(sum);
								break;

							case "4":
								neighbors = testIntArrays[3].ConsecutiveWithSum(sum);
								break;

							case "5":
								neighbors = ConsoleInput.ReadIntArrayCommaSeparated().ConsecutiveWithSum(sum);
								break;

							default:
								neighbors = new int[0];
								break;
						}
						if (neighbors.Length == 0)
						{
							Console.WriteLine("The array you chose doesn't contain any consecutive numbers with a sum of {0}", sum);
						}
						else
						{
							Console.Write("The series of numbers{0}{{", Environment.NewLine);
							neighbors.Print(false, ", ");
							Console.WriteLine("}}{1}has a sum of {0}.", sum, Environment.NewLine);
						}
					}
				}

				#endregion Exercise 11

				#region Exercise 12

				if (exercise == "12")
				{
					Console.WriteLine("Input 1 or 2 numbers corresponding to the X and Y values of a square matrix");
					int[] input = ConsoleInput.ReadIntArrayCommaSeparated(2);
					int[] xy = new int[2];
					if (input.Length == 1)
					{
						xy[0] = xy[1] = input[0];
					}
					else
					{
						xy[0] = input[0];
						xy[1] = input[1];
					}
					for (int i = 1; i <= 4; i++)
					{
						Console.WriteLine((PrintOrder)i + "/");
						PrintSeriesMatrix2D(xy[0], xy[1], (PrintOrder)i);
					}
				}

				#endregion Exercise 12

				#region Exercise 13

				if (exercise == "13")
				{
					int[,] matrix = Random2dMatrix(8, maxValue: 26);
					int[,] maxSumPlatform = matrix.MaxSumPlatform(3);
					matrix.Print(highlight: maxSumPlatform);
				}

				#endregion Exercise 13

				#region Exercise 14

				if (exercise == "14")
				{
					int[,] matrix2d = Random2dMatrix(9, maxValue: 4);
					matrix2d.Print();
					Console.WriteLine("...........................");
					int[,] matrix2dLongestSequence = matrix2d.LongestSequence();
					Console.WriteLine("The longest sequence of equal values in this matrix is {0} consecutive {1}", matrix2dLongestSequence.GetLength(1), matrix2d[matrix2dLongestSequence[0, 0], matrix2dLongestSequence[1, 0]]);
					Console.WriteLine("...........................");
					Console.WriteLine("[x, y] indices:");
					matrix2dLongestSequence.SwapSlices(1, 0, 1).Print(swapXY: true, highlight: new int[,] { { 0, 0 }, { matrix2dLongestSequence.GetLength(0) - 1, matrix2dLongestSequence.GetLength(1) - 1 } });
				}

				#endregion Exercise 14

				#region Exercise 15

				if (exercise == "15")
				{
					Console.WriteLine("Input a word:");
					char[] letters = ConsoleInput.ReadWordToCharArray(true);
					Console.WriteLine("Letters position in alphabet:");
					string numbers = "";
					string lettersString = "";
					for (int i = 0, l = letters.Length; i < l; i++)
					{
						numbers += String.Format("[ {0, -2}]", (int)Char.ToLower(letters[i]) - 96);
						lettersString += String.Format("{0}", letters[i]);
					}
					ConsoleOutput.PrintSuperposed(lettersString, numbers, 1, 5);
					
				}

				#endregion Exercise 15

				#region Test

				if (exercise == "test")
				{
					int[, ,] matrix3d = new int[3, 2, 2] { { { 24, 954 }, { 353, 432 } }, { { 562, 455 }, { 104, 6 } }, { { 810, 675 }, { 0, 534 } } };
					int[] biggest = matrix3d.Biggest();
					Console.WriteLine("matrix3d's biggest value is [{0}] = {1}", biggest[0] + ", " + biggest[1] + ", " + biggest[2], matrix3d[biggest[0], biggest[1], biggest[2]]);

					for (char ch = 'A'; ch <= 'z' ; ch++)
					{
						Console.WriteLine("{0} - {1}", ch, (int)ch);
					}

				}

				#endregion Test
			}
		}

		public static int[,] Random2dMatrix(int x, int y = 0, int maxValue = 1000)
		{
			y = (y == 0) ? x : y;
			int[,] array = new int[y, x];
			Random randomO = new Random();
			for (; y > 0; y--)
			{
				for (int currX = 0; currX < x; currX++)
				{
					array[y - 1, currX] = randomO.Next(maxValue);
				}
			}
			return array;
		}

		private enum PrintOrder { normal = 0, descendingColumns = 1, alternate = 2, diagonalAscending = 3, spiral = 4 };

		private static void PrintSeriesMatrix2D(int x, int y, PrintOrder order = PrintOrder.normal)
		{
			if (order == PrintOrder.normal)
			{
				for (int currX = 0, currY = 0, c = 1; currY < y; currX = 0, currY++)
				{
					for (; currX < x; currX++, c++)
					{
						Console.Write("{0, 3}", c);
					}
					Console.WriteLine();
				}
			}

			if (order == PrintOrder.descendingColumns)
			{
				for (int currY = 0, currX = 0, c = 1; currY < y; currY++, currX = 0, c = (c - (x * y)) + 1)
				{
					for (; currX < x; currX++, c = c + y)
					{
						Console.Write("{0, 3}", c);
					}
					Console.WriteLine();
				}
			}

			if (order == PrintOrder.alternate)
			{
				for (int currX = 0, currY = 0, c = 1; currY < y; currY++, currX = 0, c = currY + 1)
				{
					for (; currX < x; currX++)
					{
						Console.Write("{0,3}", c);
						if (currX % 2 == 0)
						{
							c += (y - currY) * 2 - 1;
						}
						else
						{
							c += currY * 2 + 1;
						}
					}
					Console.WriteLine();
				}
			}

			if (order == PrintOrder.diagonalAscending)
			{
				int[,] matrix = new int[x, y];

				for (int c = 1, currX = 0, currY = y - 1; c <= x * y; c++)
				{
					matrix[currX, currY] = c;
					if (currX + 1 < x && currY + 1 < y)
					{
						currX++;
						currY++;
					}
					else
					{
						int diffY = currY;
						currY = Math.Max(0, currY - currX - 1);
						currX = Math.Max(0, currX - diffY + 1);
					}
				}

				for (int currX = 0, currY = 0; currY < y; currY++, currX = 0)
				{
					for (; currX < x; currX++)
					{
						Console.Write("{0, 3}", matrix[currX, currY]);
					}
					Console.WriteLine();
				}
			}

			if (order == PrintOrder.spiral)
			{
				int[,] matrix = new int[x, y];
				int[] vector = new int[] { -1, 0 };

				for (int currX = 0, currY = 0, c = 1, offset = 0; c <= x * y; c++, currX += vector[0], currY += vector[1])
				{
					matrix[currX, currY] = c;
					if (currX == 0 + offset)
					{
						if (currY == 0 + offset || currY == offset - 1)
						{
							vector[0] = 0;
							vector[1] = 1;
						}
						else if (currY == y - 1 - offset)
						{
							vector[0] = 1;
							vector[1] = 0;
						}
					}
					else if (currX == x - 1 - offset)
					{
						if (currY == y - 1 - offset)
						{
							vector[0] = 0;
							vector[1] = -1;
						}
						else if (currY == 0 + offset)
						{
							vector[0] = -1;
							vector[1] = 0;
							offset++;
						}
					}
				}

				for (int currX = 0, currY = 0; currY < y; currX = 0, currY++)
				{
					for (; currX < x; currX++)
					{
						Console.Write("{0, 3}", matrix[currX, currY]);
					}
					Console.WriteLine();
				}
			}
		}

		public static void PrintArraySelection(int number = Int32.MaxValue)
		{
			int n = 1;
			for (; n <= number && n <= testIntArrays.Length; n++)
			{
				Console.Write(n + ". {");
				testIntArrays[n - 1].Print(false, ", ");
				Console.WriteLine("}");
			}
			Console.WriteLine((n) + ". Input array");
		}
	}
}