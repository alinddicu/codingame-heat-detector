namespace codingame.heat.detector.test
{
	using System.Collections.Generic;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class NextJumpCalculatorTest
	{
		[TestMethod]
		public void GivenStartAtX2Y5WhenDirectionIsUrThenReturnX2Y8()
		{
			var windowsHistory = new Stack<Window>(new[] { new Window(2, 5) });
			var calculator = new NextJumpCalculator(10, 10, windowsHistory);

			var nextJump = calculator.Execute(new CompositeDirection(Direction.UR));

			Check.That(nextJump).Equals(new Window(2, 8));
		}

		[TestMethod]
		public void GivenStartAtX2Y5WhenDirectionIsDrThenReturnX2Y8()
		{
			var windowsHistory = new Stack<Window>(new[] { new Window(2, 5) });
			var calculator = new NextJumpCalculator(10, 10, windowsHistory);

			var nextJump = calculator.Execute(new CompositeDirection(Direction.DR));

			Check.That(nextJump).Equals(new Window(2, 1));
		}
	}
}
