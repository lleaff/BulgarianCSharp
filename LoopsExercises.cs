using System;
using ExtensionMethods;

namespace FundamentalsOfProgrammingWithCSharp
{
	public class LoopsExercises
	{
		public LoopsExercises ()
		{
		}

		public static void DoExercises() 
		{
			while (true) {
				Console.WriteLine ("Exercise n°?");
				int exercise;
				while (true) {
					string rawInput = Console.ReadLine ();
					if (int.TryParse (rawInput, out exercise))
						break;
					else if (rawInput[0] == 'q')
						return;
				}

				//Exercise 1
				if (exercise == 1) {
					int n;
					while (true) {
						Console.WriteLine ("Input number to count to");
						string input = Console.ReadLine ();
						if (int.TryParse (input, out n)) {
							break;
						}
					}

					for (int i = 0; i <= n; i++) {
						Console.WriteLine (i);
					}
					Console.WriteLine ("------done-------");
				}

				if (exercise == 2) {
					int n;
					while (true) {
						Console.WriteLine ("Input number to count to while omiting number divisible by 3 and 7");
						string input = Console.ReadLine ();
						if (int.TryParse (input, out n)) {
							break;
						}
					}

					for (int i = 0; i <= n; i++) {
						if (!(i % 3 == 0 && i % 7 == 0))
							Console.WriteLine (i);
					}
					Console.WriteLine ("------done-------");
				}

				if (exercise == 3) {

					double[] nums = Exercises.AskDoubleArray ();
					double smallest = nums [0], biggest = nums [0];

					foreach (double num in nums) {
						if (num < smallest)
							smallest = num;
						if (num > biggest)
							biggest = num;
					}
					Console.WriteLine ("Smallest number: {0}, biggest number: {1}", smallest, biggest);
				}

				if (exercise == 4) {
					Console.WriteLine ("I skip");
				}

				if (exercise == 5) {
					Console.WriteLine ("Enter int");
					int n;
					while (true) { 
						string input = Console.ReadLine ();
						if (int.TryParse(input, out n) && n < 45) {
							break;
						}
						Console.WriteLine("Please input a number between 0 and 44");
					}
					int[] fibo = FibonacciArray (n);
					int result = 0;
					
					foreach (int i in fibo) {
		
						result += i;
					}
					Console.WriteLine (result);
				}
					
				if (exercise == 666) {
					double[] testArray1 = { 23, 56, 413, 143.54, 10, 143.54, 413, 56, 23 };
					double[] testArray2 = { 23, 23 };
					double[] testArray3 = { 42, 3 };
					Console.WriteLine ("testArray 1 is" + (testArray1.IsSymmetric () ? " symmetric." : "n't symmetric."));
					Console.WriteLine ("testArray 2 is" + (testArray2.IsSymmetric () ? " symmetric." : "n't symmetric."));
					Console.WriteLine ("testArray 3 is" + (testArray3.IsSymmetric () ? " symmetric." : "n't symmetric."));
				}

				if (exercise == 6) {
					Console.WriteLine ("Let's calculate N!/K! (with K < N)");
					Console.Write ("N?   ");
					int n = Exercises.ReadInt32 (1);
					Console.Write ("K?   ");
					int k = Exercises.ReadInt32 (1,n-1);
					Console.WriteLine ("{0}!/{1}! = {2}", n, k, n.FactorialDivision (k));
				}

				if (exercise == 7) {
					Console.WriteLine ("Let's calculate  N!*K! / (N-K)!  (with K < N)");
					Console.Write ("N? ");
					int n = Exercises.ReadInt32(1);
					Console.Write ("K? ");
					int k = Exercises.ReadInt32 (1, n-1);

					int _temp1 = n.Factorial (n - k);
					int _temp2 = k.Factorial (n - k);
					int result = _temp1 * _temp2;

					Console.WriteLine ("{0}!*{1}! / ({0}-{1})!  = {2}", n, k, result);
				}

				if (exercise == 8) {

				}

			}
		}

			/// <summary>
			/// Fills an array with numbers from the Fibonacci sequence.
			/// </summary>
			/// <returns>The array.</returns>
			/// <param name="length">Length of the array (max = 44)</param>
			/// <param name="start">After how many number of values to start storing in the array.</param>
		static public int[] FibonacciArray (int length = 44, int start = 0) {
			//Exceptions
			if (length > 44) {
				Console.WriteLine ("Due to size restrictions on the \"int\" type the array's length can only be 44 or smaller, it has been set to 44");
				length = 44;
			}
			if (start < 0) {
				Console.WriteLine ("Array start cannot be under 0, it has been set to 0");
				start = 0;
			}
			int[] fibonacci = new int[length];
			int limit = start + length;
			for (int i = 0; i < limit; i++) {
				if (i < 2)
					fibonacci [i] = 1;
				else if (i - 1 > start) {
					fibonacci [i] = fibonacci [i - 1] + fibonacci [i - 2];
				} else if (i == start) {
					fibonacci [i] = fibonacci [fibonacci.Length + 1] + fibonacci [fibonacci.Length];
				} else if (i == start + 1) {
					fibonacci [i] = fibonacci [fibonacci [0]] + fibonacci[fibonacci.Length + 1];
				}
			}
			return fibonacci;
		}
	}
}
