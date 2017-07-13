namespace codingame.heat.detector
{
	using System;
	using System.Collections.Generic;

	public class NextJumpCalculator
	{
		private readonly int _buildingWidth;
		private readonly int _buildingWHeight;
		private readonly Stack<Window> _windowsHistory;

		public NextJumpCalculator(int buildingWidth, int buildingWHeight, Stack<Window> windowsHistory)
		{
			_buildingWidth = buildingWidth;
			_buildingWHeight = buildingWHeight;
			_windowsHistory = windowsHistory;
		}

		public Window Execute(CompositeDirection compositeDirection)
		{
			throw new NotImplementedException();
		}
	}
}
