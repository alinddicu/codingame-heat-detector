namespace codingame.heat.detector.test
{
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class CompositeDirectionTest
	{

		private static readonly IEnumerable<CompositeDirection> Diagonals = new[]
		{
			new CompositeDirection(Direction.L),
			new CompositeDirection(Direction.R),
			new CompositeDirection(Direction.UL),
			new CompositeDirection(Direction.UR),
			new CompositeDirection(Direction.DL),
			new CompositeDirection(Direction.DR)
		};

		[TestMethod]
		public void CheckIsVertical()
		{
			var verticals = new[]
			{
				new CompositeDirection(Direction.U),
				new CompositeDirection(Direction.D)
			};

			Check.That(verticals.All(v => v.IsVertical())).IsTrue();
			Check.That(Diagonals.All(v => v.IsVertical())).IsFalse();
		}

		[TestMethod]
		public void CheckIsHorizontal()
		{
			var horizontals = new[]
			{
				new CompositeDirection(Direction.L),
				new CompositeDirection(Direction.R)
			};

			Check.That(horizontals.All(v => v.IsHorizontal())).IsTrue();
			Check.That(Diagonals.All(v => v.IsHorizontal())).IsFalse();
		}
	}
}
