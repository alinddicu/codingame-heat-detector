namespace codingame.heat.detector
{
	public class CompositeDirection
	{
		public CompositeDirection(Direction component1, Direction? component2 = null)
		{
			Component1 = component1;
			Component2 = component2;
		}

		public CompositeDirection(Direction component)
			: this(component.Decompose().Component1, component.Decompose().Component2)
		{
		}

		public Direction Component1 { get; }

		public Direction? Component2 { get; }

		public bool IsDiagonal()
		{
			return Component2 != null;
		}

		public bool IsVertical()
		{
			return !IsDiagonal()
				&& (Component1 == Direction.U || Component1 == Direction.D);
		}

		public bool IsHorizontal()
		{
			return !IsDiagonal() && !IsVertical();
		}
	}
}
