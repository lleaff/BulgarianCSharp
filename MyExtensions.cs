using System;

namespace ExtensionMethods
{
	public static class MyExtensions
	{
		public static bool IsSymmetric<T> (this T[] input) where T : IComparable { //idk if the "where" is needed with Equals()
			if (input.Length <= 1) {
				return true;
			} else {
				for (int i = 0; i < input.Length / 2; i++) {
					if (!input [i].Equals(input[input.Length - 1 - i])) {
						return false;
					}
				}
				return true;
			}
		}

		public static int Factorial (this int input, int startFrom = 1) {
			int result = 1;
			if (input < 0) {
				result = 0;
			} else if (input <= 1) {
				result = 1;
			} else if (input <= 12) {
				for (; input > startFrom; input--) {
					result = result * (input);
				}
			} else { 
				Console.WriteLine ("Result too big for int type, 12! is biggest possible");
				result = Int32.MaxValue;
			}
			return result;
		}

		public static int FactorialDivision (this int input1, int input2) {
			int result = input1.Factorial (input2);
			return result;
		}
	}
}

