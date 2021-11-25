using System;

namespace Monty_Hall
{
	class Program
	{
		public delegate bool Function(int numDoors, bool stay);

		public static void Profiling(Function f, int numDoors, int count)
		{
			int stayWin = 0, changeWin = 0;
			for(int i = 0; i < count; i++)
			{
				if (f(numDoors, true))
					stayWin++;
				else
					changeWin++;
			}
			Console.WriteLine("Staying in the door you chose out of {0} doors works {1}% of the time! ({2} out of {3} times)", numDoors, (float)stayWin*100 / count, stayWin, count);
			Console.WriteLine("Changing to the newer door out of {0} doors works {1}% of the time! ({2} out of {3} times)", numDoors, (float)changeWin*100 / count, changeWin, count);
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			while(Console.ReadLine() != "exit")
				Profiling(MontyHall, 100, 100000);
		}

		public static bool MontyHall(int numDoors, bool stay)
		{
			Random r = new Random();
			int car = r.Next() % numDoors;
			int choose = r.Next() % numDoors;
			int other;
			if (choose == car)
				other = r.Next() % numDoors;
			else
				other = car;

			if (stay)
				return choose == car;
			else
				return other == car;
		}
	}
}
