﻿using System;

namespace Twosixteen
{
	class MainClass
	{
		public static int Main (string[] args)
		{
      string name;
      if (args.Length < 1) {
        Console.WriteLine ("What's you name boy?");
        if (String.IsNullOrEmpty(name = Console.ReadLine())) {
          throw new Exception("I NEED A NAME GODAMIT");
        }
      } else {
        name = args[0];
      }
			Console.WriteLine ("Hello {0}", name);
      return 0;
		}
	}
}
