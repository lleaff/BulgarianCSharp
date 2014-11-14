using System;
using System.Collections.Generic;

namespace FundamentalsOfCExercisesVariablesChapter
{

	public class ConsoleExercises {

		public ConsoleExercises ()
		{
		}

		private static bool YesNo() {
			Console.WriteLine ("Y/N?");
			char yesno = (char)Console.Read();
			Console.WriteLine ();
			return (yesno == 'y' || yesno == 'Y');
			}


		public static void DoExercises() {

			#region Exercise 2
			Exercises.Title ("2");
			if(YesNo()) {

				Console.WriteLine ("First name?");
				string inputFirstName = Console.ReadLine ();
				Console.WriteLine ("Last name?");
				string inputLastName = Console.ReadLine ();
				Console.WriteLine ("Phone number?");
				int inputPhone = int.Parse (Console.ReadLine ());
				Console.WriteLine ("Address?");
				string inputAddress = Console.ReadLine ();
				Console.WriteLine ("Profession?");
				string inputProfession = Console.ReadLine ();



				Console.Write ("{0, -10}", inputFirstName);
				Console.Write (" {0, -10}", inputLastName);
				Console.Write (" {0, 10}{1}", inputPhone, Environment.NewLine);
				Console.Write (inputAddress);
				Console.Write ("{0, -15}", inputProfession);

			}
			#endregion

			#region Exercise 5
			Exercises.Title ("5");
			if (YesNo ()) {
				Console.WriteLine ("please input min integer and max integer separated by a space");
				string input = Console.ReadLine ();
				string[] inputSplit = input.Split (new char[] { ' ' }, 2);
				int minLimit = Convert.ToInt32 (inputSplit [0]);
				int maxLimit = Convert.ToInt32 (inputSplit [1]);

				int[] results = new int[(maxLimit - minLimit) - 1];
				int resultsCounter = 0;

				for (int i = 1; i < (maxLimit - minLimit); i++) {
					if ((minLimit + i) % 5 == 0) {
						resultsCounter++;
						results [i - 1] = minLimit + i;
					}
				}
				bool firstTicker = false;
				if (resultsCounter > 0)
					Console.WriteLine ("There are {0} numbers divisible by 5 between {1} and {2}, here they are:", resultsCounter, minLimit, maxLimit);
				else
					Console.WriteLine ("There are no numbers divisble by 5 between {0} and {1}", minLimit, maxLimit);
				for (int i = 0; i < results.Length;i++) {
					if (results [i] != 0) {
						if (firstTicker)
							Console.Write (", ");
						firstTicker = true;
						Console.Write (results [i]);
					}
					if (i == results.Length - 1)
						Console.Write ("." + Environment.NewLine);
			}
				}
			#endregion

			#region Exercise 6
			Exercises.Title("6");
			if (YesNo()){
				Console.Write("Enter 2 numbers to compare" + Environment.NewLine + "Number 1: ");
				double[] nums = new double[2];
				nums[0] = Exercises.ReadDouble();
				Console.Write("Number 2: ");
				nums[1] = Exercises.ReadDouble();
				if (nums[0] == nums[1])
					Console.WriteLine("These numbers are the same");
				else
					Console.WriteLine("{1} is greater than {2}, {0}and their difference is:{0}{3}", Environment.NewLine, Math.Max(nums[0], nums[1]), Math.Min(nums[0], nums[1]), Math.Max(nums[0], nums[1]) - Math.Min(nums[0], nums[1]));
			}
				#endregion


			#region Exercise 7
			Exercises.Title("7");
			if (YesNo()){
				Console.WriteLine("Input 5 numbers please, their sum  will be computed.");
				double[] nums = new double[5];
				double sum = 0;
				for (int i = 1; i <= 5; i++) {
					Console.Write("Number {0}",i);
					nums[i - 1] = Exercises.ReadDouble();
					sum += nums[i - 1];
				}
				Console.WriteLine("The sum of these numbers is:" + Environment.NewLine + sum);
			}
			#endregion

			#region Exercise 8
			Exercises.Title("8");
			if (YesNo()){
				Console.WriteLine("Input numbers to compare and press Enter when you're finished");
				List<double> nums = new List<double>();
				// take input
				short count = 0;
				while (true) {
					count++;
					Console.Write("> ");
					double num;
					string input = Console.ReadLine();
						if (Double.TryParse(input, out num))
							nums.Add(num);
						else
							break;
				}
				// calculate sum
				double sum = 0;
				if (nums.Count > 0){
					for (int i = 0; i < nums.Count;i++) {
						sum += nums[i];
					}
				}
				Console.WriteLine("The sum of the numbers you input is: " + Environment.NewLine + sum);
			}
			#endregion

		}





		}
	}


