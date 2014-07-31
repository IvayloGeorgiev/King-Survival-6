namespace KingSurvivalGameTests
{
    using System;
    using System.Collections.Generic;
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
        public void CheckUpLeftCommandExists()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("KUL"));
        }

        [TestMethod]
        public void CheckUpRightCommandExists()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("KUR"));
        }

        [TestMethod]
        public void CheckDownLeftCommandExists()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("KDL"));
        }

        [TestMethod]
        public void CheckDownRightCommandExists()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("KDR"));
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

        [TestMethod]
        public void CheckIfPawnTurnOnlyHasPawnTurnCommands()
        {
            List<string> expectedCommands = new List<string> { "KDR", "KDL", "KUL", "KUR" };
            IEnumerable<string> actualCommands = this.turn.GetCommands();
            bool result = true;

            foreach (var command in actualCommands)
            {
                if (!expectedCommands.Contains(command))
                {
                    result = false;
                    break;
                }

                expectedCommands.Remove(command);
            }

            if (expectedCommands.Count != 0)
            {
                result = false;
            }

            Assert.IsTrue(result);

        }
    }
}
