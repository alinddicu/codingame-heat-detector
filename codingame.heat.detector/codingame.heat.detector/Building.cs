namespace codingame.heat.detector
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class Building
	{
		private readonly int _width;
		private readonly int _height;
		private readonly Func<string> _readLine;
		private readonly Action<object> _writeLine;

		public Building(Func<string> readLine, Action<object> writeLine)
		{
			_readLine = readLine;
			_writeLine = writeLine;
		}

		public void Run()
		{
			// game loop
			while (true)
			{
				var bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

				var bombDirection = (Direction)Enum.Parse(typeof(Direction), bombDir);
				Console.WriteLine(PredictJump(bombDirection)); // the location of the next window Batman should jump to.
			}
		}

		private bool PredictJump(Direction bombDirection)
		{
			throw new NotImplementedException();
		}
	}
}