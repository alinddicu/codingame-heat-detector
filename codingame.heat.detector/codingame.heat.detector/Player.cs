namespace codingame.heat.detector
{
	using System;

	/**
     * Auto-generated code below aims at helping you parse
     * the standard input according to the problem statement.
     **/
	public class Player
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

			var building = new Building(width, height, new Window(x0, y0));

			// game loop
			while (true)
			{
				var bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

				// Write an action using Console.WriteLine()
				// To debug: Console.Error.WriteLine("Debug messages...");

				var bombDirection = (Direction)Enum.Parse(typeof(Direction), bombDir);
				Console.WriteLine(building.PredictJump(bombDirection)); // the location of the next window Batman should jump to.
			}
		}
	}
}
