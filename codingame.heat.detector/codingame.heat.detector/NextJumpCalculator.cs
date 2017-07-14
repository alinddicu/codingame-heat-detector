namespace codingame.heat.detector
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class NextJumpCalculator
	{
		private readonly int _buildingWidth;
		private readonly int _buildingHeight;
		private readonly IEnumerable<Window> _windowsHistory;
		private readonly IEnumerable<Direction> _directionsHistory;

		public NextJumpCalculator(
			int buildingWidth,
			int buildingHeight,
			IEnumerable<Window> windowsHistory,
			IEnumerable<Direction> directionsHistory)
		{
			_buildingWidth = buildingWidth;
			_buildingHeight = buildingHeight;
			_windowsHistory = windowsHistory;
			_directionsHistory = directionsHistory;
		}

		public Window Execute(CompositeDirection compositeDirection)
		{
			var windowsHistory = _windowsHistory.ToArray();
			var directionsHistory = _directionsHistory.ToArray();

			var primaryDirection = compositeDirection.Primary;
			var actualWindow = windowsHistory.Last();
			var isFirstJump = windowsHistory.Length == 1;
			var previousWindow = isFirstJump ? null : windowsHistory[windowsHistory.Length - 2];

			if (compositeDirection.IsDiagonal() || compositeDirection.IsVertical())
			{
				if (primaryDirection == Direction.U && isFirstJump)
				{
					var y = actualWindow.Y + (_buildingHeight - actualWindow.Y) / 2;
					return new Window(actualWindow.X, y);
				}

				if (primaryDirection == Direction.D && isFirstJump)
				{
					var y = actualWindow.Y - actualWindow.Y / 2;
					return new Window(actualWindow.X, y);
				}

				if (primaryDirection == Direction.U &&
					!isFirstJump
					&& directionsHistory.Last().IsOpposite(Direction.U))
				{
					var y = actualWindow.Y + (previousWindow.Y - actualWindow.Y) / 2;
					return new Window(actualWindow.X, y);
				}

				if (primaryDirection == Direction.D &&
					!isFirstJump
					&& directionsHistory.Last().IsOpposite(Direction.D))
				{
					var y = actualWindow.Y - (actualWindow.Y - previousWindow.Y) / 2;
					return new Window(actualWindow.X, y);
				}
			}

			if (compositeDirection.IsHorizontal())
			{
				if (primaryDirection == Direction.R && isFirstJump)
				{
					var x = actualWindow.X + (_buildingWidth - actualWindow.X) / 2;
					return new Window(x, actualWindow.Y);
				}

				if (primaryDirection == Direction.L && isFirstJump)
				{
					var x = actualWindow.X - actualWindow.X / 2;
					return new Window(x, actualWindow.Y);
				}

				if (primaryDirection == Direction.L &&
					!isFirstJump
					&& directionsHistory.Last().IsOpposite(Direction.L))
				{
					var x = actualWindow.X - previousWindow.X / 2;
					return new Window(x, actualWindow.Y);
				}

				if (primaryDirection == Direction.R &&
					!isFirstJump
					&& directionsHistory.Last().IsOpposite(Direction.R))
				{
					var x = actualWindow.X + (previousWindow.X - actualWindow.X) / 2;
					return new Window(x, actualWindow.Y);
				}
			}

			throw new NotImplementedException();
		}
	}
}
