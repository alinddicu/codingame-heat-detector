namespace codingame.heat.detector
{
	using System;

	public class MovementVector
	{
		public static Window GetWindow(
			Window currentWindow,
			CompositeDirection bombDirection,
			int buildingWidth,
			int buildingHeight)
		{
			var firstDirection = bombDirection.First;
			var secondDirection = bombDirection.Second;
			var x = currentWindow.X;
			var y = currentWindow.Y;
			var vX = x;
			var vY = y;
			if (secondDirection.HasValue && firstDirection == Direction.L)
			{
				vX = x - 1;
			}

			if (secondDirection.HasValue && firstDirection == Direction.R)
			{
				vX = x + 1;
			}

			if (secondDirection.HasValue && firstDirection == Direction.U)
			{
				vY = y - 1;
			}

			if (secondDirection.HasValue && firstDirection == Direction.D)
			{
				vY = y + 1;
			}

			secondDirection = secondDirection ?? firstDirection;
			if (secondDirection == Direction.L)
			{
				vX = x + (0 - x) / 2;
			}

			if (secondDirection == Direction.R)
			{
				vX = x + (buildingWidth - 1 - x) / 2;
			}

			if (secondDirection == Direction.U)
			{
				vY = y + (0 - y) / 2;
			}

			if (secondDirection == Direction.D)
			{
				vY = y + (buildingHeight - 1 - y) / 2;
			}

			return new Window(vX, vY);
		}
	}
}
