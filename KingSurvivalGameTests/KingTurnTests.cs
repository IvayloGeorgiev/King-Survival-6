namespace KingSurvivalGameTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvivalGame.BasicLogic;

    [TestClass]
    public class KingTurnTests
    {
        [TestMethod]
        public void CheckCommandCallReturnsFalseWhenStringIsNull()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            KingTurn turn = new KingTurn(engine);
            Assert.IsFalse(turn.CheckCommandExists(null));
        }

        [TestMethod]
        public void CheckCommandCallReturnsFalseWhenStringIsEmpty()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            KingTurn turn = new KingTurn(engine);
            Assert.IsFalse(turn.CheckCommandExists(string.Empty));
        }

        [TestMethod]
        public void CheckCommandCallReturnsFalseWhenCommandDoesntExist()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            KingTurn turn = new KingTurn(engine);
            Assert.IsFalse(turn.CheckCommandExists("bugabuga"));
        }

        [TestMethod]
        public void CheckCommandReturnsTrueWhenCommandExists()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            KingTurn turn = new KingTurn(engine);
            Assert.IsTrue(turn.CheckCommandExists("KUL"));
        }

        [TestMethod]
        public void CheckValidUpLeftCommandExecutes()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            KingTurn turn = new KingTurn(engine);
            Assert.IsTrue(turn.ExecuteCommand("KUL"));
        }

        [TestMethod]
        public void CheckValidUpRightCommandExecutes()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            KingTurn turn = new KingTurn(engine);
            Assert.IsTrue(turn.ExecuteCommand("KUR"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidCommandExecuteThrowsError()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            KingTurn turn = new KingTurn(engine);
            Assert.IsTrue(turn.ExecuteCommand("safds"));
        }

        [TestMethod]
        public void CheckValidButImpossibleCommandExecuteReturnsFalse()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            KingTurn turn = new KingTurn(engine);
            Assert.IsFalse(turn.ExecuteCommand("KDL"));
        }

        [TestMethod]
        public void CheckIfStartingFiguresAreAlive()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            KingTurn turn = new KingTurn(engine);
            Assert.IsTrue(turn.FiguresCanMove());
        }

        [TestMethod]
        public void CheckIfGetFiguresReturnsAllFigures()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            KingTurn turn = new KingTurn(engine);
            Assert.AreEqual(turn.GetFigures().Count, 5);
        }
    }
}
