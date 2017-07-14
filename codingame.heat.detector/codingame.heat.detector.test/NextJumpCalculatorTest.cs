namespace codingame.heat.detector.test
{
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class NextJumpCalculatorTest
	{
		[TestMethod]
		public void GivenStartAtX2Y5WhenDirectionIsUrThenReturnX2Y8()
		{
			var windowsHistory = new Stack<Window>(new[] { new Window(2, 5) });
			var calculator = new NextJumpCalculator(10, 10, windowsHistory, Enumerable.Empty<Direction>());

			var nextJump = calculator.Execute(new CompositeDirection(Direction.UR));

			Check.That(nextJump).Equals(new Window(2, 8));
		}

		[TestMethod]
		public void UpThenDown()
		{
			var windowsHistory = new Stack<Window>();
			windowsHistory.Push(new Window(2, 5));
			windowsHistory.Push(new Window(2, 8));
			var calculator = new NextJumpCalculator(10, 10, windowsHistory, new[] { Direction.UR });

			var nextJump = calculator.Execute(new CompositeDirection(Direction.DR));

			Check.That(nextJump).Equals(new Window(2, 6));
		}

		[TestMethod]
		public void GivenStartAtX2Y5WhenDirectionIsDrThenReturnX2Y8()
		{
			var windowsHistory = new Stack<Window>(new[] { new Window(2, 5) });
			var calculator = new NextJumpCalculator(10, 10, windowsHistory, Enumerable.Empty<Direction>());

			var nextJump = calculator.Execute(new CompositeDirection(Direction.DR));

			Check.That(nextJump).Equals(new Window(2, 1));
		}

		[TestMethod]
		public void DownThenUp()
		{
			var windowsHistory = new Stack<Window>();
			windowsHistory.Push(new Window(2, 5));
			windowsHistory.Push(new Window(2, 1));
			var calculator = new NextJumpCalculator(10, 10, windowsHistory, new[] { Direction.DR });

			var nextJump = calculator.Execute(new CompositeDirection(Direction.UR));

			Check.That(nextJump).Equals(new Window(2, 4));
		}

		[TestMethod]
		public void GivenStartAtX2Y5WhenDirectionIsRThenReturnX7Y5()
		{
			var windowsHistory = new Stack<Window>(new[] { new Window(2, 5) });
			var calculator = new NextJumpCalculator(10, 10, windowsHistory, Enumerable.Empty<Direction>());

			var nextJump = calculator.Execute(new CompositeDirection(Direction.R));

			Check.That(nextJump).Equals(new Window(7, 5));
		}

		[TestMethod]
		public void GivenStartAtX2Y5WhenDirectionIsLThenReturnX0Y5()
		{
			var windowsHistory = new Stack<Window>(new[] { new Window(2, 5) });
			var calculator = new NextJumpCalculator(10, 10, windowsHistory, Enumerable.Empty<Direction>());

			var nextJump = calculator.Execute(new CompositeDirection(Direction.L));

			Check.That(nextJump).Equals(new Window(0, 5));
		}
	}
}
