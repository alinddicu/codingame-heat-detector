namespace codingame.heat.detector.test
{
    using codingame.heat.detector;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class BuildingTest
    {
        [TestMethod]
        public void BaseTest()
        {
            var building = new Player.Building(10, 10, new Player.Window(2, 5));

            Check.That(building.PredictJump(Player.Direction.UR).ToString()).IsEqualTo("3 4");
            Check.That(building.PredictJump(Player.Direction.R).ToString()).IsEqualTo("4 4");
            Check.That(building.PredictJump(Player.Direction.R).ToString()).IsEqualTo("5 4");
            Check.That(building.PredictJump(Player.Direction.R).ToString()).IsEqualTo("6 4");
            Check.That(building.PredictJump(Player.Direction.R).ToString()).IsEqualTo("7 4");
        }
    }
}
