namespace codingame.heat.detector
{
	public class CompositeDirection
	{
		public CompositeDirection(Direction primary, Direction? secondary = null)
		{
			Primary = primary;
			Secondary = secondary;
		}

		public CompositeDirection(Direction component)
			: this(component.Decompose().Primary, component.Decompose().Secondary)
		{
		}

		public Direction Primary { get; }

		public Direction? Secondary { get; }

		public bool IsDiagonal()
		{
			return Secondary != null;
		}

		public bool IsVertical()
		{
			return !IsDiagonal()
				&& (Primary == Direction.U || Primary == Direction.D);
		}

		public bool IsHorizontal()
		{
			return !IsDiagonal() && !IsVertical();
		}
	}
}
