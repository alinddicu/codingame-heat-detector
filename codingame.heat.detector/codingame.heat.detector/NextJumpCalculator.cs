namespace codingame.heat.detector
{
	using System;
	using System.Collections.Generic;

	public class NextJumpCalculator
	{
		private readonly int _buildingWidth;
		private readonly int _buildingHeight;
		private readonly Stack<Window> _windowsHistory;

		public NextJumpCalculator(int buildingWidth, int buildingHeight, Stack<Window> windowsHistory)
		{
			_buildingWidth = buildingWidth;
			_buildingHeight = buildingHeight;
			_windowsHistory = windowsHistory;
		}

		public Window Execute(CompositeDirection compositeDirection)
		{
			var actualWindow = _windowsHistory.Peek();
			if (compositeDirection.IsDiagonal())
			{
				var direction = compositeDirection.Component1;
				if (direction == Direction.U)
				{
					var y = actualWindow.Y + (_buildingHeight - actualWindow.Y) / 2 + 1;
					return new Window(actualWindow.X, y);
				}

				if (direction == Direction.D)
				{
					var y = actualWindow.Y / 2 - 1;
					return new Window(actualWindow.X, y);
				}

				//if (direction == Direction.R)
				//{
				//	var x = actualWindow.X + (_buildingWidth - actualWindow.X) / 2 + 1;
				//	return new Window(x, actualWindow.Y);
				//}

				//if (direction == Direction.L)
				//{
				//	var x = actualWindow.X / 2 - 1;
				//	return new Window(x, actualWindow.Y);
				//}
			}

			throw new NotImplementedException();
		}
	}
}
