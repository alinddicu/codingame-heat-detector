using System;

namespace codingame.heat.detector
{
	public class CompositeDirection
	{
		public CompositeDirection(Direction first, Direction? second)
		{
			First = first;
			Second = second;
		}

		public Direction First { get; private set; }

		public Direction? Second { get; private set; }

		public static CompositeDirection Create(Direction bombDirection)
		{
			throw new NotImplementedException();
		}
	}
}
