namespace codingame.heat.detector
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class Building
	{
		private readonly int _width;
		private readonly int _height;

		private List<Window> _possibleJumps = new List<Window>();
		private Window _currentPosition;

		public Building(int width, int height, Window intialPosition)
		{
			_width = width;
			_height = height;
			_currentPosition = intialPosition;
			InitPossibleJumps();
		}

		private void InitPossibleJumps()
		{
			for (int x = 0; x < _width; x++)
			{
				for (int y = 0; y < _height; y++)
				{
					_possibleJumps.Add(new Window(x, y));
				}
			}

			_possibleJumps.Remove(_currentPosition);
		}

		public Window PredictJump(Direction bombDirection)
		{
			DiminishPossibleJumps(bombDirection);

			var xAbsMargin = Math.Abs(_currentPosition.X - _width);
			var yAbsMargin = Math.Abs(_currentPosition.Y - _height);
			var leastMargin = (new[] { xAbsMargin, yAbsMargin }).Min(m => m);
			var delta = (int)Math.Ceiling((double)leastMargin / 2);

			Window newWindow = null;
			switch (bombDirection)
			{
				case Direction.U:
					newWindow = new Window(_currentPosition.X, _currentPosition.Y - 1);
					break;
				case Direction.UR:
					newWindow = new Window(_currentPosition.X + delta, _currentPosition.Y - delta);
					break;
				case Direction.R:
					newWindow = new Window(_currentPosition.X + 1, _currentPosition.Y);
					break;
				case Direction.DR:
					newWindow = new Window(_currentPosition.X + delta, _currentPosition.Y + delta);
					break;
				case Direction.D:
					newWindow = new Window(_currentPosition.X, _currentPosition.Y + 1);
					break;
				case Direction.DL:
					newWindow = new Window(_currentPosition.X - 1, _currentPosition.Y + 1);
					break;
				case Direction.L:
					newWindow = new Window(_currentPosition.X - 1, _currentPosition.Y);
					break;
				case Direction.UL:
					newWindow = new Window(_currentPosition.X - 1, _currentPosition.Y - 1);
					break;
			}

			_currentPosition = Minor(newWindow, bombDirection);

			return _currentPosition;
		}

		private Window Minor(Window newWindow, Direction bombDirection)
		{
			if (_possibleJumps.Contains(newWindow))
			{
				return newWindow;
			}

			return IsInlineAndClosest(bombDirection, newWindow);
		}

		public Window IsInlineAndClosest(Direction bombDirection, Window newWindow)
		{
			var inlines = _possibleJumps.Where(w => w.IsInline(bombDirection, _currentPosition)).ToArray();
			var minDistance = inlines.Min(i => i.GetDistance(newWindow));

			return inlines.Single(i => i.GetDistance(newWindow) == minDistance);
		}

		private void DiminishPossibleJumps(Direction bombDirection)
		{
			IEnumerable<Window> newList = null;
			switch (bombDirection)
			{
				case Direction.U:
					newList = _possibleJumps.Where(w => w.Y < _currentPosition.Y).ToList();
					break;
				case Direction.UR:
					newList = _possibleJumps.Where(w => w.Y < _currentPosition.Y && w.X > _currentPosition.X).ToList();
					break;
				case Direction.R:
					newList = _possibleJumps.Where(w => w.X > _currentPosition.X).ToList();
					break;
				case Direction.DR:
					newList = _possibleJumps.Where(w => w.Y > _currentPosition.Y && w.X > _currentPosition.X).ToList();
					break;
				case Direction.D:
					newList = _possibleJumps.Where(w => w.Y > _currentPosition.Y).ToList();
					break;
				case Direction.DL:
					newList = _possibleJumps.Where(w => w.Y < _currentPosition.Y && w.X > _currentPosition.X).ToList();
					break;
				case Direction.L:
					newList = _possibleJumps.Where(w => w.X < _currentPosition.X).ToList();
					break;
				case Direction.UL:
					newList = _possibleJumps.Where(w => w.Y < _currentPosition.Y && w.X < _currentPosition.X).ToList();
					break;
			}

			_possibleJumps = newList.ToList();
		}
	}
}