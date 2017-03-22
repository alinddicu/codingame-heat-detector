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

		public double GetDistance(Window other)
		{
			var x = X - other.X;
			var y = Y - other.Y;
			return Math.Sqrt(x * x + y * y);
		}

		public bool IsInline(Direction bombDirection, Window currentPosition)
		{
			if (IsHorizontal(bombDirection) && Y == currentPosition.Y)
			{
				return true;
			}

			if (IsVertical(bombDirection) && X == currentPosition.Y)
			{
				return true;
			}

			var deltaX = Math.Abs(Math.Abs(X) - Math.Abs(currentPosition.X));
			var deltaY = Math.Abs(Math.Abs(Y) - Math.Abs(currentPosition.Y));
			if (IsOblic(bombDirection) && deltaX == deltaY)
			{
				return true;
			}

			return false;
		}

		private static bool IsHorizontal(Direction direction)
		{
			return direction == Direction.L || direction == Direction.R;
		}

		private static bool IsVertical(Direction direction)
		{
			return direction == Direction.U || direction == Direction.D;
		}

		private static bool IsOblic(Direction direction)
		{
			return !IsHorizontal(direction) && !IsVertical(direction);
		}
	}
}