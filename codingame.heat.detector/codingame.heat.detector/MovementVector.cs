namespace codingame.heat.detector
{
	public class MovementVector
	{
		public static Window GetWindow(
			Window currentWindow,
			CompositeDirection bombDirection,
			int buildingWidth,
			int buildingHeight)
		{
			var component1 = bombDirection.Primary;
			var component2 = bombDirection.Secondary;
			var x = currentWindow.X;
			var y = currentWindow.Y;
			var vX = x;
			var vY = y;
			if (component2.HasValue && component1 == Direction.L)
			{
				vX = x - 1;
			}

			if (component2.HasValue && component1 == Direction.R)
			{
				vX = x + 1;
			}

			if (component2.HasValue && component1 == Direction.U)
			{
				vY = y - 1;
			}

			if (component2.HasValue && component1 == Direction.D)
			{
				vY = y + 1;
			}

			component2 = component2 ?? component1;
			if (component2 == Direction.L)
			{
				vX = x + (0 - x) / 2;
			}

			if (component2 == Direction.R)
			{
				vX = x + (buildingWidth - 1 - x) / 2;
			}

			if (component2 == Direction.U)
			{
				vY = y + (0 - y) / 2;
			}

			if (component2 == Direction.D)
			{
				vY = y + (buildingHeight - 1 - y) / 2;
			}

			return new Window(vX, vY);
		}
	}
}
