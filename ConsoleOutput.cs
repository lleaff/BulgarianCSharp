namespace System
{
	internal class ConsoleOutput
	{
		static public void Title(string title, string separator = "===================")
		{
			string centerFiller = new string(' ', (separator.Length - title.Length) / 2);
			Console.WriteLine("{1}{0}{2}{3}{0}{1}", Environment.NewLine, separator, centerFiller, title);
		}

		public static void PrintSuperposed(string string1, string string2, int string1SubElementLength = 0, int string2SubElementLength = Int32.MinValue)
		{
			int s1L = string1SubElementLength;
			int s2L = string2SubElementLength == Int32.MinValue ? s1L : string2SubElementLength;
			object smallerElement = s1L < s2L ? s1L : s2L;
			object largerElement = smallerElement.Equals(s1L) ? s2L : s1L;
			int padding = (int)largerElement - (int)smallerElement;
			int frontPadding = padding / 2;
			int backPadding = padding - frontPadding;
			for (int i = 0, j = 0, iStarting = 0, iEnding = 0, jStarting = 0, jEnding = 0, bW = Console.BufferWidth, nL = string2.Length; i < nL - 1; )
			{
				for (j = jStarting; !((i % (int)largerElement == 0 || !(i % s1L == 0)) && i - iStarting >= bW - (int)largerElement)  && i < nL;)
				{
					if (s1L.Equals(smallerElement) && ((i % s2L) < frontPadding || (i % s2L) >= s1L + frontPadding ))
					{
						Console.Write(" ");
						i++;
					}
					else
					{
						Console.Write(string1[j]);
						j++;
						i++;
					}
				}
				jEnding = j;
				iEnding = i;
				Console.WriteLine();
				for (i = iStarting; !((j % (int)largerElement == 0 || !(j % s2L == 0)) && j - jStarting >= bW - (int)largerElement)  && j < nL; j++)
				{
					if (s2L.Equals(smallerElement) && ((j % s1L) < frontPadding || (j % s1L) >= s2L + frontPadding ))
					{
						Console.Write(" ");
						j++;
					}
					else
					{
						Console.Write(string2[i]);
						i++;
						j++;
					}
				}
				iStarting = iEnding;
				jStarting = jEnding;
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}