namespace KingSurvivalGameTests
{
    using System;    
    using KingSurvivalGame.BasicLogic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PawnTurnTests
    {
        private KingSurvivalEngine engine;
        private PawnTurn turn;

        [TestInitialize]
        public void Initialize()
        {
            this.engine = new KingSurvivalEngine();
            this.turn = new PawnTurn(this.engine);
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
            Assert.IsTrue(this.turn.CheckCommandExists("ADR"));      
        }

        [TestMethod]
        public void CheckValidDownLeftCommandExecutes()
        {
            Assert.IsTrue(this.turn.ExecuteCommand("BDL"));            
        }

        [TestMethod]
        public void CheckValidDownRightCommandExecutes()
        {
            Assert.IsTrue(this.turn.ExecuteCommand("ADR"));            
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
            Assert.IsFalse(this.turn.ExecuteCommand("ADL"));            
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
