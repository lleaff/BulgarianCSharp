using System;
using System.Collections.Generic;

namespace FundamentalsOfProgrammingWithCSharp
{
	public class MITAlgorithmsIntroduction
	{

		public static bool IsThereAPeak (float[] input)
		{
			int index;
			return IsThereAPeak(input, out index);
		}

		#region IsThereAPeak
		public static bool IsThereAPeak(float[] input, out int index)
		{
			bool result = false;
			int length = input.Length;
			int divideLimit = 0; //Number of times you can divide the array.
			while (length >= 3) {
				length /= 2;
				divideLimit++;
			}
			length = input.Length;
			Console.WriteLine ("divideLimit = " + divideLimit);//DEBUG

			int range = length / 2;
			index = range;
			int offset = 0;
			int p = 1;

			Console.WriteLine ("input.Length = " + input.Length);//DEBUG
			while(index <= input.Length && index >= 0) {
				if (index == 0 || input [index] < input [index - 1]) {
					if (p < divideLimit) {
						index = range + offset;
						range /= 2;
						p++;
						Console.WriteLine ("i < i - 1,  p=" + p + "   range=" + range + "   offset=" + offset +  "   index=" + index + "    value=" + input[index]);//DEBUG
					} else {
						if (input [index] > input [index + 1] && index == 0) {
							Console.WriteLine ("i > i + 1,  p=" + p + "   range=" + range + "   offset=" + offset + "   index=" + index + "    value=" + input[index]);//DEBUG
							result = true;
							break;
						}
						index -= 1; 
					}
				} else if (input [index] > input [index - 1]) {
					if (p < divideLimit) {
						index = range + offset;
						offset += range;
						range /= 2;
						p++;
						Console.WriteLine ("i > i - 1,  p=" + p + "   range=" + range + "   offset=" + offset + "   index=" + index + "    value=" + input[index]);//DEBUG
					} else {
						Console.WriteLine ("yo");//DEBUG
						if (index == (input.Length - 1)) {
							Console.WriteLine ("Allelujah");//DEBUG
							result = true;
							break;
						}
						Console.WriteLine ("index {0}, input.Length {1}", index, input.Length);
						if (index != (input.Length - 1)) {
							Console.WriteLine (index + "      " + (index + 1));
							Console.WriteLine (index + "      " + (input [index + 1]));
							if (input [index] > input [index + 1]) {
								Console.WriteLine ("i < i + 1,  p=" + p + "   range=" + range + "   offset=" + offset + "   index=" + index + "    value=" + input [index]);//DEBUG
								result = true;
								break;
							}
						}
						index += 1;
					}
				}
			}

			Console.WriteLine ("main loop end");//DEBUG
			return result;

		}
		#endregion


		public static void Exercises ()
		{

			List<float[]> testArrays = new List<float[]>();
			testArrays.Add(new float[] { 46f, 1f, 0f, -20f, 10.555f, 11f, 0f, 2f, 2.5f, 3f, 2f, 5f, 6.13f, 356f });
			testArrays.Add(new float[] { 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10f, 11, 12, 13, 12});
			testArrays.Add(new float[] {22, 12, -4f, -10, -50, -1230, -24556, -999999});
			testArrays.Add(new float[] {1, 3, 5});



			bool peak;
			int peakIndex = -555;

			for (int i = 0; i < testArrays.Count; i++) {

				peak = IsThereAPeak (testArrays[i], out peakIndex);

				Console.WriteLine ("There {0} a peak{1}", peak ? "is" : "isn't", peak ? " in position " + peakIndex + " and of value " + testArrays[i][peakIndex] : "");
				Console.WriteLine ("---------------------------------------");
			}
		}
	}
}

