namespace KingSurvivalGameTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvivalGame.BasicLogic;

    [TestClass]
    public class KingTurnTests
    {
        private KingSurvivalEngine engine;
        private KingTurn turn;

        [TestInitialize]
        public void Initialize()
        {
            this.engine = new KingSurvivalEngine();
            this.turn = new KingTurn(this.engine);
        }

        [TestMethod]
        public void CheckCommandCallReturnsFalseWhenStringIsNull()
        {            
            Assert.IsFalse(this.turn.CheckCommandExists(null));
        }

        [TestMethod]
        public void CheckCommandCallReturnsFalseWhenStringIsEmpty()
        {
            Assert.IsFalse(this.turn.CheckCommandExists(string.Empty));
        }

        [TestMethod]
        public void CheckCommandCallReturnsFalseWhenCommandDoesntExist()
        {
            Assert.IsFalse(this.turn.CheckCommandExists("bugabuga"));
        }

        [TestMethod]
        public void CheckCommandReturnsTrueWhenCommandExists()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("KUL"));
        }

        [TestMethod]
        public void CheckValidUpLeftCommandExecutes()
        {
            Assert.IsTrue(this.turn.ExecuteCommand("KUL"));
        }

        [TestMethod]
        public void CheckValidUpRightCommandExecutes()
        {
            Assert.IsTrue(this.turn.ExecuteCommand("KUR"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidCommandExecuteThrowsError()
        {
            Assert.IsTrue(this.turn.ExecuteCommand("safds"));
        }

        [TestMethod]
        public void CheckValidButImpossibleCommandExecuteReturnsFalse()
        {
            Assert.IsFalse(this.turn.ExecuteCommand("KDL"));
        }

        [TestMethod]
        public void CheckIfStartingFiguresAreAlive()
        {
            Assert.IsTrue(this.turn.FiguresCanMove());
        }

        [TestMethod]
        public void CheckIfGetFiguresReturnsAllFigures()
        {
            Assert.AreEqual(this.turn.GetFigures().Count, 5);
        }
    }
}
