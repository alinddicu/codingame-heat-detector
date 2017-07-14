namespace codingame.heat.detector.test
{
	using System.Collections.Generic;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class NextJumpCalculatorTest
	{
		private static readonly List<Window> WindowsHistory = new List<Window>();
		private static readonly List<Direction> DirectionsHistory = new List<Direction>();

		[TestInitialize]
		public void Initialize()
		{
			WindowsHistory.Clear();
			DirectionsHistory.Clear();
		}

		private static NextJumpCalculator InitCalculator()
		{
			return new NextJumpCalculator(10, 10, WindowsHistory, DirectionsHistory);
		}

		[TestMethod]
		public void GivenStartAtX2Y5WhenDirectionIsUrThenReturnX2Y8()
		{
			WindowsHistory.Add(new Window(2, 5));
			var calculator = InitCalculator();

			var nextJump = calculator.Execute(new CompositeDirection(Direction.UR));

			Check.That(nextJump).Equals(new Window(2, 7));
		}

		[TestMethod]
		public void UpThenDown()
		{
			WindowsHistory.Add(new Window(2, 5));
			WindowsHistory.Add(new Window(2, 8));
			DirectionsHistory.Add(Direction.UR);
			var calculator = InitCalculator();

			var nextJump = calculator.Execute(new CompositeDirection(Direction.DR));

			Check.That(nextJump).Equals(new Window(2, 7));
		}

		[TestMethod]
		public void GivenStartAtX2Y5WhenDirectionIsDrThenReturnX2Y8()
		{
			WindowsHistory.Add(new Window(2, 5));
			var calculator = InitCalculator();

			var nextJump = calculator.Execute(new CompositeDirection(Direction.DR));

			Check.That(nextJump).Equals(new Window(2, 3));
		}

		[TestMethod]
		public void DownThenUp()
		{
			WindowsHistory.Add(new Window(2, 5));
			WindowsHistory.Add(new Window(2, 1));
			DirectionsHistory.Add(Direction.DR);
			var calculator = InitCalculator();

			var nextJump = calculator.Execute(new CompositeDirection(Direction.UR));

			Check.That(nextJump).Equals(new Window(2, 3));
		}

		[TestMethod]
		public void GivenStartAtX2Y5WhenDirectionIsRThenReturnX7Y5()
		{
			WindowsHistory.Add(new Window(2, 5));
			var calculator = InitCalculator();

			var nextJump = calculator.Execute(new CompositeDirection(Direction.R));

			Check.That(nextJump).Equals(new Window(6, 5));
		}

		[TestMethod]
		public void GivenStartAtX2Y5WhenDirectionIsLThenReturnX0Y5()
		{
			WindowsHistory.Add(new Window(2, 5));
			var calculator = InitCalculator();

			var nextJump = calculator.Execute(new CompositeDirection(Direction.L));

			Check.That(nextJump).Equals(new Window(1, 5));
		}

		[TestMethod]
		public void RightThenLeft()
		{
			WindowsHistory.Add(new Window(2, 5));
			WindowsHistory.Add(new Window(7, 5));
			var calculator = new NextJumpCalculator(10, 10, WindowsHistory, new[] { Direction.R });

			var nextJump = calculator.Execute(new CompositeDirection(Direction.L));

			Check.That(nextJump).Equals(new Window(6, 5));
		}

		[TestMethod]
		public void LeftThenRight()
		{
			WindowsHistory.Add(new Window(2, 5));
			WindowsHistory.Add(new Window(0, 5));
			DirectionsHistory.Add(Direction.L);
			var calculator = InitCalculator();

			var nextJump = calculator.Execute(new CompositeDirection(Direction.R));

			Check.That(nextJump).Equals(new Window(1, 5));
		}
	}
}
