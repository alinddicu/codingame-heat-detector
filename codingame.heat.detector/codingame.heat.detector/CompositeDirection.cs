namespace codingame.heat.detector
{
	public class CompositeDirection
	{
		public CompositeDirection(Direction component1, Direction? component2)
		{
			Component1 = component1;
			Component2 = component2;
		}

		public Direction Component1 { get; private set; }

		public Direction? Component2 { get; private set; }
	}
}
