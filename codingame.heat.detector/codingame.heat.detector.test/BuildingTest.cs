namespace codingame.heat.detector.test
{
	using common;
	using detector;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class BuildingTest
    {
        [TestMethod]
		[Ignore]
        public void Given10By10WhenUrAndRThen54And74()
        {
			var consoleSimulator = new ConsoleSimulator(
				"10 10",
				"99",
				"2 5",
				"UR",
				"R");
            var building = new Building(consoleSimulator.ReadLine, consoleSimulator.WriteLine);

			building.Run();

			Check.That(consoleSimulator.WrittenLines).ContainsExactly("5 4", "7 4"); }

        [TestMethod]
		[Ignore]
        public void Tower()
        {
            // bomb(0,7)
            //var building = new Building(1, 14, new Window(0, 0));

            //Check.That(building.PredictJump(Direction.D).ToString()).IsEqualTo("0 7");
        }
    }
}
