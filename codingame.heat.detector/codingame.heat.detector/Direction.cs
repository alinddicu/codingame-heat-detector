namespace codingame.heat.detector
{
	using System;
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
		private static bool IsComposed(this Direction direction)
		{
			return direction.ToString().Length == 2;
		}

		public static CompositeDirection Decompose(this Direction direction)
		{
			var parts = direction.ToString().ToCharArray().Select(s => s.ToString()).ToArray();
			var firstDirection = (Direction) Enum.Parse(typeof(Direction), parts[0]);
			var secondDirection = 
				direction.IsComposed() 
				? (Direction?) Enum.Parse(typeof(Direction), parts[1]) 
				: null;

			return new CompositeDirection(firstDirection, secondDirection);
		}
	}
}