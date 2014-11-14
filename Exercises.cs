using System;

namespace FundamentalsOfCExercisesVariablesChapter
{
	class Exercises
	{
		static void Main (string[] args)
		{

			while (true) { 
				Console.WriteLine ("Select chapter\n" +
				"1. Variables\n" +
				"2. MIT Introduction to algorithms\n" +
				"3. Console\n" +
				"4. Loop\n");

				string selector = Console.ReadLine ();

				switch (selector) {

				case "0":
					TestScratchpad.DoScratchpad ();
					break;

				case "1":
					VariableExercises.DoVariableExercises ();
					break;

				case "2":
					MITAlgorithmsIntroduction.Exercises ();
					break;

				case "3":
					ConsoleExercises.DoExercises ();
					break;

				case "4":
					LoopsExercises.DoExercises ();
					break;

				default:
					break;
				}

				Console.WriteLine ("============chapter==finished==========" + Environment.NewLine);
			}
		}

		static public void Title (string title) {
			Console.WriteLine ("==================={0}{1}{0}===================", Environment.NewLine, title);
		}


		static public double ReadDouble() {
			double num;
			while (true) {
				string input = Console.ReadLine ();
				if (Double.TryParse (input, out num) == true)
					return num;
				else
					Console.WriteLine ("Input a number please");

			}
		}

		static public int ReadInt32(int minLimit = Int32.MinValue, int maxLimit = Int32.MaxValue) {
			int num = 0;
			while (true) {
				string input = Console.ReadLine ();
				if (Int32.TryParse (input, out num) && num >= minLimit && num <= maxLimit) {
					return num;
				} else {
					Console.WriteLine ("Input an integer number between {0} and {1}.", minLimit, maxLimit);
				}

			}
		}

		static public double[] AskDoubleArray (int limit = 0) {
			Console.WriteLine ("Input numbers, press {Enter} between each of them.\n Press {Enter} on an empty line when you're finished.");
			System.Collections.Generic.List<double> nums = new System.Collections.Generic.List<double> ();
			int listCounter = 0;
			while (limit == 0 || listCounter < limit) {
				double num;
				string input = Console.ReadLine ();
				if (double.TryParse(input, out num)) {
					nums.Add (num);
					listCounter++;
				} else if (input == ""){
					break;
				} else {
					Console.WriteLine("Input a number please");
				}
			}
			double[] result = new double[nums.Count];
			for (int i = 0; i < nums.Count; i++) {
				result [i] = nums [i];
			}
			return result;
		}
			


	}
}

