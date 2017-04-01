namespace codingame.heat.detector
{
	using System;
	using System.Collections.Generic;
	using codingame_common;

	public class Building
	{
		private readonly Func<string> _readLine;
		private readonly Action<object> _writeLine;
		private readonly int _width;
		private readonly int _height;
		private readonly Stack<Window> _windowsHistory = new Stack<Window>();

		public Building(Func<string> readLine, Action<object> writeLine)
		{
			_readLine = readLine;
			_writeLine = writeLine;
			var inputs = _readLine().Split(' ');
			_width = int.Parse(inputs[0]); // width of the building.
			_height = int.Parse(inputs[1]); // height of the building.
			var N = int.Parse(_readLine()); // maximum number of turns before game over.
			_windowsHistory.Push(new Window(_readLine()));
		}

		public void Run()
		{
			// game loop
			while (true)
			{
				string bombDir;
				try
				{
					bombDir = _readLine();
				}
				catch (NoMoreLinesToReadException)
				{
					break;
				}

				var bombDirection = (Direction)Enum.Parse(typeof(Direction), bombDir);
				_writeLine(PredictJump(bombDirection)); // the location of the next window Batman should jump to.
			}
		}

		private Window PredictJump(Direction bombDirection)
		{
			var compositeDirection = bombDirection.Decompose();
			var currentWindow = _windowsHistory.Peek();
			var nextWindow = MovementVector.GetWindow(
				currentWindow, 
				compositeDirection,
				_width,
				_height);
			
			_windowsHistory.Push(nextWindow);
			return nextWindow;
		}
	}
}