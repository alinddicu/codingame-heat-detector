namespace codingame.heat.detector.test
{
    using codingame.heat.detector;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class BuildingTest
    {
        [TestMethod]
        public void SomeJumps()
        {
            var building = new Player.Building(10, 10, new Player.Window(2, 5));

            Check.That(building.PredictJump(Player.Direction.UR).ToString()).IsEqualTo("5 2");
            Check.That(building.PredictJump(Player.Direction.DR).ToString()).IsEqualTo("7 4");
        }

        [TestMethod]
        [Ignore]
        public void Tower()
        {
            // bomb(0,7)
            var building = new Player.Building(1, 14, new Player.Window(0, 0));

            Check.That(building.PredictJump(Player.Direction.D).ToString()).IsEqualTo("0 7");
        }
    }
}
