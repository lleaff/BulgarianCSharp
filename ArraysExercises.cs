﻿using ExtensionMethods;
using System;
using System.Collections.Generic;

namespace FundamentalsOfProgrammingWithCSharp
{
	internal class ArraysExercises
	{
		public static void DoExercises()
		{
			string exercise = "";
			while (exercise != "q")
			{
				Console.WriteLine("Exercise n°?");
				exercise = Console.ReadLine();

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
					Console.WriteLine("Input integers to put in a array, separated by commas");
					int[] nums = Exercises.ReadIntArrayCommaSeparated();
					

				}

				#endregion Exercise 4
			}
		}
	}
}