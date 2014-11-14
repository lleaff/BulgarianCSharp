using System;

namespace FundamentalsOfCExercisesVariablesChapter
{
	class VariableExercises
	{
	
		public static void DoVariableExercises()
		{
			string[,] names = new string[,]{{null},{null}}; //initialize an empty 2 dimensional array
			NameRobot (out names [0, 0], out names [1, 0]);
			Console.WriteLine ("First Name: " + names [0, 0] + Environment.NewLine + "Last Name: " + names [1, 0]);
		}

		// Capitalize each word
		static string CapitalizeFirstLetters (string input) {
			if (input == null) {
				return null;
			}
			char[] inputChars = input.ToCharArray();
			bool caseTicker = true;
			for (int i = 0; i < inputChars.Length; i++) {
				if (inputChars[i] == ' ' || inputChars[i] == '-')
					caseTicker = true;
				else {
					if (caseTicker)
						inputChars[i] = Char.ToUpper (inputChars[i]);
					else
						inputChars[i] = Char.ToLower (inputChars[i]);

					caseTicker = false;
				}
			}
			return new string(inputChars);
		}

		// Asks and returns full name in 2 strings
		static void NameRobot (out string firstName, out string lastName) {
			firstName = lastName = null;
			string[] userInputSplit;

			while (true) {
				Console.WriteLine ("What is your name? (first name before last name)");
				string userInput = Console.ReadLine ();
				userInputSplit = userInput.Split (new char[] {' '});
				if (userInputSplit[0] != "")
					break;
			}

			for (int i = 0; i < userInputSplit.Length; i++) {
				if (firstName == null) {
					firstName = userInputSplit [i];
				}
				else if (lastName == null) {
					lastName = userInputSplit [i];
				}
				else
				{
					lastName = String.Concat (lastName, " ", userInputSplit[i]);
				}
			}

			firstName = VariableExercises.CapitalizeFirstLetters (firstName);
			lastName = VariableExercises.CapitalizeFirstLetters (lastName);

			//Console.WriteLine ("Your first name is: " + firstName + Environment.NewLine + "Your last name is: " + lastName);

		}

	}
}
