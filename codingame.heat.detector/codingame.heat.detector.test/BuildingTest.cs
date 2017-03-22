namespace codingame.heat.detector.test
{
    using detector;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class BuildingTest
    {
        [TestMethod]
        public void Given10By10WhenUrAndDrThen52And74()
        {
            var building = new Building(10, 10, new Window(2, 5));

            Check.That(building.PredictJump(Direction.UR).ToString()).IsEqualTo("5 2");
            Check.That(building.PredictJump(Direction.DR).ToString()).IsEqualTo("7 4");
        }

        [TestMethod]
        [Ignore]
        public void Tower()
        {
            // bomb(0,7)
            var building = new Building(1, 14, new Window(0, 0));

            Check.That(building.PredictJump(Direction.D).ToString()).IsEqualTo("0 7");
        }
    }
}
