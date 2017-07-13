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

		protected bool Equals(Window other)
		{
			return Y == other.Y && X == other.X;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;

			return Equals((Window) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Y*397) ^ X;
			}
		}
	}
}