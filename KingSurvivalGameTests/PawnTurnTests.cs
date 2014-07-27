namespace KingSurvivalGameTests
{
    using System;    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvivalGame.BasicLogic;    

    [TestClass]
    public class PawnTurnTests
    {
        [TestMethod]      
        public void CheckCommandCallReturnsFalseWhenStringIsNull()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            PawnTurn turn = new PawnTurn(engine);
            Assert.IsFalse(turn.CheckCommandExists(null));
        }

        [TestMethod]
        public void CheckCommandCallReturnsFalseWhenStringIsEmpty()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            PawnTurn turn = new PawnTurn(engine);
            Assert.IsFalse(turn.CheckCommandExists(string.Empty));
        }

        [TestMethod]
        public void CheckCommandCallReturnsFalseWhenCommandDoesntExist()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            PawnTurn turn = new PawnTurn(engine);
            Assert.IsFalse(turn.CheckCommandExists("bugabuga"));
        }

        [TestMethod]
        public void CheckCommandReturnsTrueWhenCommandExists()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            PawnTurn turn = new PawnTurn(engine);
            Assert.IsTrue(turn.CheckCommandExists("ADR"));      
        }

        [TestMethod]
        public void CheckValidDownLeftCommandExecutes()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            PawnTurn turn = new PawnTurn(engine);
            Assert.IsTrue(turn.ExecuteCommand("BDL"));            
        }

        [TestMethod]
        public void CheckValidDownRightCommandExecutes()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            PawnTurn turn = new PawnTurn(engine);
            Assert.IsTrue(turn.ExecuteCommand("ADR"));            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckInvalidCommandExecuteThrowsError()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            PawnTurn turn = new PawnTurn(engine);
            Assert.IsTrue(turn.ExecuteCommand("safds"));            
        }

        [TestMethod]
        public void CheckValidButImpossibleCommandExecuteReturnsFalse()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            PawnTurn turn = new PawnTurn(engine);
            Assert.IsFalse(turn.ExecuteCommand("ADL"));            
        }

        [TestMethod]
        public void CheckIfStartingFiguresAreAlive()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            PawnTurn turn = new PawnTurn(engine);
            Assert.IsTrue(turn.FiguresCanMove());
        }

        [TestMethod]
        public void CheckIfGetFiguresReturnsAllFigures()
        {
            KingSurvivalEngine engine = new KingSurvivalEngine();
            PawnTurn turn = new PawnTurn(engine);
            Assert.AreEqual(turn.GetFigures().Count, 5);            
        }                        
    }
}
