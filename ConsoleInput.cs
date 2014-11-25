using ExtensionMethods;
using System.Collections.Generic;

namespace System
{
	/// <summary>
	/// Methods to facilitate taking user input from the Console.
	/// </summary>
	internal class ConsoleInput
	{
		/// <summary>
		/// Safe way of asking the user for input, keep asking until a valid integer is entered.
		/// </summary>
		/// <param name="minLimit">Leave blank to accept any integer.</param>
		/// <param name="maxLimit">Leave blank to accept any integer.</param>
		/// <returns></returns>
		static public int ReadInt(int minLimit = Int32.MinValue, int maxLimit = Int32.MaxValue)
		{
			int num = 0;
			while (true)
			{
				string input = Console.ReadLine();
				if (Int32.TryParse(input, out num) && num >= minLimit && num <= maxLimit)
				{
					return num;
				}
				else
				{
					Console.WriteLine("Input an integer number{0}.", minLimit == Int32.MinValue && maxLimit == Int32.MaxValue ? "" : (maxLimit == Int32.MaxValue ? " greater than " + minLimit : " smaller than " + maxLimit));
				}
			}
		}

		/// <summary>
		/// Safe way of asking the user for input, keep asking until a valid double is entered.
		/// </summary>
		/// <param name="minLimit">Leave blank to accept any double number</param>
		/// <param name="maxLimit">Leave blank to accept any double number</param>
		/// <returns></returns>
		static public double ReadDouble(double minLimit = Double.MinValue, double maxLimit = Double.MaxValue)
		{
			double num;
			while (true)
			{
				string input = Console.ReadLine();
				if (Double.TryParse(input, out num) && num >= minLimit && num <= maxLimit)
					return num;
				else
					Console.WriteLine("Input a number{0}.", minLimit == Double.MinValue && maxLimit == Double.MaxValue ? "" : (maxLimit == Double.MaxValue ? " greater than " + minLimit : " smaller than " + maxLimit)); ;
			}
		}

		/// <summary>
		/// Safe way of asking the user for input, keep asking until a valid decimal is entered.
		/// </summary>
		/// <param name="minLimit">Leave blank to accept any decimal number</param>
		/// <param name="maxLimit">Leave blank to accept any decimal number</param>
		/// <returns></returns>
		static public decimal ReadDecimal(decimal minLimit = Decimal.MinValue, decimal maxLimit = Decimal.MaxValue)
		{
			decimal num;
			while (true)
			{
				string input = Console.ReadLine();
				if (Decimal.TryParse(input, out num) && num >= minLimit && num <= maxLimit)
					return num;
				else
					Console.WriteLine("Input a number{0}.", minLimit == Decimal.MinValue && maxLimit == Decimal.MaxValue ? "" : (maxLimit == Decimal.MaxValue ? " greater than " + minLimit : " smaller than " + maxLimit)); ;
			}
		}

		/// <summary>
		/// Reads a word from the console, stop recording as soon as a forbidden character or Enter is pressed
		/// </summary>
		///<param name="onlyLatinLetters">Accept only letters from the latin alphabet</param>
		/// <param name="forbiddenCharacters">Default: { ',', ' ', '-', '_', '+', '(', ')', '[', ']', '*' }</param>
		/// <returns></returns>
		public static string ReadWord(bool onlyLatinLetters = true, int maxWordLength = Int32.MaxValue, char[] forbiddenCharacters = null)
		{
			List<char> letters = new List<char>();
			forbiddenCharacters = forbiddenCharacters ?? new char[] { ',', ' ', '-', '_', '+', '(', ')', '[', ']', '*' };
			for (char letter = 'a'; maxWordLength != Int32.MaxValue || letters.Count <= maxWordLength; )
			{
				ConsoleKeyInfo input = Console.ReadKey();
				if (input.Key == ConsoleKey.Enter)
				{
					Console.WriteLine();
					break;
				}
				if (input.Key == ConsoleKey.Backspace)
				{
					letters.RemoveAt(letters.Count - 1);
					Console.Write(" ");
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					continue;
				}
				letter = input.KeyChar;
				if ((onlyLatinLetters && (letter >= 'A' && letter <= 'Z' || letter >= 'a' && letter <= 'z')) || !(forbiddenCharacters.Contains(letter) && onlyLatinLetters))
				{
					letters.Add(letter);
				}
				else
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Console.Write(" ");
					Console.WriteLine();
					break;
				}
			}
			string word = String.Concat(letters);
			return word;
		}

		/// <summary>
		/// Reads a word from the console, stop recording as soon as a forbidden character or enter is pressed
		/// </summary>
		/// <param name="forbiddenCharacters">Default: { ',', ' ', '-', '_', '+', '(', ')', '[', ']', '*' }</param>
		///<param name="onlyLatinLetters">Accept only letters from the latin alphabet</param>
		/// <returns>Char array of every key pressed and accepted</returns>
		public static char[] ReadWordToCharArray(bool onlyLatinLetters = true, int maxWordLength = Int32.MaxValue, char[] forbiddenCharacters = null)
		{
			List<char> letters = new List<char>();
			forbiddenCharacters = forbiddenCharacters ?? new char[] { ',', ' ', '-', '_', '+', '(', ')', '[', ']', '*' };
			for (char letter = 'a'; maxWordLength != Int32.MaxValue || letters.Count <= maxWordLength; )
			{
				ConsoleKeyInfo input = Console.ReadKey();
				if (input.Key == ConsoleKey.Enter)
				{
					Console.WriteLine();
					break;
				}
				if (input.Key == ConsoleKey.Backspace)
				{
					letters.RemoveAt(letters.Count - 1);
					Console.Write(" ");
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					continue;
				}
				letter = input.KeyChar;
				if ((onlyLatinLetters && (letter >= 'A' && letter <= 'Z' || letter >= 'a' && letter <= 'z')) || !(forbiddenCharacters.Contains(letter) && onlyLatinLetters))
				{
					letters.Add(letter);
				}
				else
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Console.Write(" ");
					Console.WriteLine();
					break;
				}
			}
			return letters.ToArray();
		}

		/// <summary>
		/// Ask the user to input a series of double numbers to enter in an array.
		/// </summary>
		/// <param name="limit">Limit on the array length</param>
		/// <returns></returns>
		static public double[] AskDoubleArray(int limit = 0)
		{
			Console.WriteLine("Input numbers, press {Enter} between each of them.\n Press {Enter} on an empty line when you're finished.");
			System.Collections.Generic.List<double> nums = new System.Collections.Generic.List<double>();
			int listCounter = 0;
			while (limit == 0 || listCounter < limit)
			{
				double num;
				string input = Console.ReadLine();
				if (double.TryParse(input, out num))
				{
					nums.Add(num);
					listCounter++;
				}
				else if (input == "")
				{
					break;
				}
				else
				{
					Console.WriteLine("Input a number please");
				}
			}
			double[] result = new double[nums.Count];
			for (int i = 0; i < nums.Count; i++)
			{
				result[i] = nums[i];
			}
			return result;
		}

		/// <summary>
		/// Reads a string of comma-separated integers and returns them in an array. Ask until a valid string is entered.
		/// </summary>
		/// <param name="limit">Array max size</param>
		/// <returns></returns>
		static public int[] ReadIntArrayCommaSeparated(int limit = Int32.MaxValue)
		{
			int[] nums;
			for (bool done = false; !done; )
			{
				string input = Console.ReadLine();
				string[] inputs = input.Split(new string[] { ",", ", ", " ,", " " }, StringSplitOptions.RemoveEmptyEntries);
				nums = new int[inputs.Length];
				for (int i = 0; i < inputs.Length && i < limit; i++)
				{
					if (!Int32.TryParse(inputs[i], out nums[i]))
					{
						done = false;
						Console.WriteLine("Please input integers separated by commas like this:\n63, 43, 0, -54, 205, 4234, -324, 459");
						break;
					}
					done = true;
				}
				if (done)
				{
					return nums;
				}
			}
			return new int[0];
		}
	}
}