using System;

namespace FundamentalsOfProgrammingWithCSharp
{
	internal class Exercises
	{
		private static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("Select chapter\n" +
				"1. Variables\n" +
				"2. MIT Introduction to algorithms\n" +
				"3. Console\n" +
				"4. Loop\n" +
				"5. Arrays\n" +
				"6. Numeral Systems");

				string selector = Console.ReadLine();

				switch (selector)
				{
					case "0":
						ConsoleOutput.Title("Scratchpad");
						TestScratchpad.DoScratchpad();
						break;

					case "1":
						ConsoleOutput.Title("Variables exercises");
						VariableExercises.DoVariableExercises();
						break;

					case "2":
						MITAlgorithmsIntroduction.Exercises();
						break;

					case "3":
						ConsoleOutput.Title("Console Exercises");
						ConsoleExercises.DoExercises();
						break;

					case "4":
						ConsoleOutput.Title("Loops exercises");
						LoopsExercises.DoExercises();
						break;

					case "5":
						ConsoleOutput.Title("Arrays exercises");
						ArraysExercises.DoExercises();
						break;

					default:
						break;
				}

				Console.WriteLine("============chapter==finished==========" + Environment.NewLine);
			}
		}

		

	}
}