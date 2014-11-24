using ExtensionMethods;
using System;

namespace FundamentalsOfProgrammingWithCSharp
{
	public static class TestScratchpad
	{
		public static void DoScratchpad()
		{
			int[] testArray123 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
			foreach (int num in testArray123)
			{
				Console.WriteLine(num + "! = " + num.Factorial());
			}
		}
	}
}