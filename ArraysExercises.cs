using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalsOfProgrammingWithCSharp
{
	class ArraysExercises
	{
		public static void DoExercises()
		{
			string exercise = "";
			while (exercise != "q")
			{
				Console.WriteLine("Exercise n°?");
				exercise = Console.ReadLine();

				#region Exercise 1
				if (exercise == "1")
				{
					int[] myArray = new int[20];
					for (int i = 0; i < myArray.Length; i++)
					{
						myArray[i] = i * 5;
						Console.Write("{0}{1}", myArray[i], (i < myArray.Length - 1) ? "." : ", ");
					}
				}
				#endregion

				#region Exercise 2
				if (exercise == "2")
				{

					//TODO
					
				}
				#endregion
			}
		}

	public static bool IsEqualTo<T>(this IList<T> array1, IList<T> array2)  {
		if (array1.Count != array2.Count)
		{
			return false;
		}
		for (int i = 0; i < array1.Count; i++) 
		{
			if (EqualityComparer<T>.Default.Equals(array1[i], array2[i])) {
				return false;
			}
		}
		return false;
		}
	}

}
