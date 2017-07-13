namespace codingame.heat.detector
{
	public class Window
	{
		public Window(string readLine)
			: this(ParseCoordinate(readLine, 0), ParseCoordinate(readLine, 1))
		{
		}

		public Window(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int Y { get; }

		public int X { get; }

		private static int ParseCoordinate(string readLine, int coordinateRank)
		{
			return int.Parse(readLine.Split(' ')[coordinateRank]);
		}

		public override string ToString()
		{
			return X + " " + Y;
		}
	}
}