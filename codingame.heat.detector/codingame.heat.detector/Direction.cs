namespace codingame.heat.detector
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public enum Direction
	{
		U,
		UR,
		R,
		DR,
		D,
		DL,
		L,
		UL
	}

	public static class DirectionExtensions
	{
		private static readonly IEnumerable<KeyValuePair<Direction, Direction>> Opposites = new[]
		{
			new KeyValuePair<Direction, Direction>(Direction.D, Direction.U),
			new KeyValuePair<Direction, Direction>(Direction.U, Direction.D),
			new KeyValuePair<Direction, Direction>(Direction.L, Direction.R),
			new KeyValuePair<Direction, Direction>(Direction.R, Direction.L)
		};

		private static bool IsComposed(this Direction direction)
		{
			return direction.ToString().Length == 2;
		}

		public static bool IsOpposite(this Direction direction, Direction otherDirection)
		{
			var directionCompoenent1 = direction.Decompose().Component1;
			var otherDirectionComponent1 = otherDirection.Decompose().Component1;
			var oppositeCandidate = new KeyValuePair<Direction, Direction>(directionCompoenent1, otherDirectionComponent1);
			return Opposites.Contains(oppositeCandidate);
		}

		public static CompositeDirection Decompose(this Direction direction)
		{
			var parts = direction.ToString().ToCharArray().Select(s => s.ToString()).ToArray();
			var firstDirection = (Direction)Enum.Parse(typeof(Direction), parts[0]);
			var secondDirection =
				direction.IsComposed()
				? (Direction?)Enum.Parse(typeof(Direction), parts[1])
				: null;

			return new CompositeDirection(firstDirection, secondDirection);
		}
	}
}