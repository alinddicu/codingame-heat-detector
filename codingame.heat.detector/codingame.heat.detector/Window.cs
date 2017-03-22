namespace codingame.heat.detector
{
	using System;

	public class Window
	{
		public Window(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int Y { get; }

		public int X { get; }

		public override string ToString()
		{
			return X + " " + Y;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			var other = obj as Window;
			return other != null && Equals(other);
		}

		private bool Equals(Window other)
		{
			return X == other.X && Y == other.Y;
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}
	}
}