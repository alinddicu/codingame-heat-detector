namespace codingame.heat.detector
{
	using System;

	/**
     * Auto-generated code below aims at helping you parse
     * the standard input according to the problem statement.
     **/
	public class Program
	{

		static void Main(string[] args)
		{
			var inputs = Console.ReadLine().Split(' ');
			var width = int.Parse(inputs[0]); // width of the building.
			var height = int.Parse(inputs[1]); // height of the building.
			var N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
			inputs = Console.ReadLine().Split(' ');
			var x0 = int.Parse(inputs[0]);
			var y0 = int.Parse(inputs[1]);

			var building = new Building(Console.ReadLine, Console.WriteLine);

			building.Run();
		}
	}
}
