namespace codingame.heat.detector
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class NextJumpCalculator
	{
		private readonly int _buildingWidth;
		private readonly int _buildingHeight;
		private readonly Window[] _windowsHistory;
		private readonly IEnumerable<Direction> _directionsHistory;

		public NextJumpCalculator(
			int buildingWidth, 
			int buildingHeight, 
			Stack<Window> windowsHistory,
			IEnumerable<Direction> directionsHistory)
		{
			_buildingWidth = buildingWidth;
			_buildingHeight = buildingHeight;
			_windowsHistory = windowsHistory.Reverse().ToArray();
			_directionsHistory = directionsHistory;
		}

		public Window Execute(CompositeDirection compositeDirection)
		{
			var actualWindow = _windowsHistory.Last();
			var isFirstJump = _windowsHistory.Length == 1;
			var previousWindow = isFirstJump ? null : _windowsHistory[_windowsHistory.Length - 2];
			if (compositeDirection.IsDiagonal())
			{
				var direction = compositeDirection.Component1;
				if (direction == Direction.U && isFirstJump)
				{
					var y = actualWindow.Y + (_buildingHeight - actualWindow.Y) / 2 + 1;
					return new Window(actualWindow.X, y);
				}

				if (direction == Direction.D && isFirstJump)
				{
					var y = actualWindow.Y / 2 - 1;
					return new Window(actualWindow.X, y);
				}

				if (direction == Direction.U &&
					!isFirstJump
					&& _directionsHistory.Last().IsOpposite(Direction.U))
				{
					var y = actualWindow.Y + (previousWindow.Y - actualWindow.Y) / 2 + 1;
					return new Window(actualWindow.X, y);
				}

				if (direction == Direction.D &&
					!isFirstJump
					&& _directionsHistory.Last().IsOpposite(Direction.D))
				{
					var y = actualWindow.Y - (actualWindow.Y - previousWindow.Y) / 2 - 1;
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
