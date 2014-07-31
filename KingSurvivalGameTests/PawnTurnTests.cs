namespace KingSurvivalGameTests
{
    using System;    
    using System.Collections.Generic;

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
        public void CheckCommandExistsReturnsTrueForPawnADownRight()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("ADR"));      
        }

        [TestMethod]
        public void CheckCommandExistsReturnsTrueForPawnADownLeft()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("ADL"));
        }

        [TestMethod]
        public void CheckCommandExistsReturnsTrueForPawnBDownRight()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("BDR"));
        }

        [TestMethod]
        public void CheckCommandExistsReturnsTrueForPawnBDownLeft()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("BDL"));
        }

        [TestMethod]
        public void CheckCommandExistsReturnsTrueForPawnCDownRight()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("CDR"));
        }

        [TestMethod]
        public void CheckCommandExistsReturnsTrueForPawnCDownLeft()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("CDL"));
        }

        [TestMethod]
        public void CheckCommandExistsReturnsTrueForPawnDDownRight()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("DDR"));
        }

        [TestMethod]
        public void CheckCommandExistsReturnsTrueForPawnDDownLeft()
        {
            Assert.IsTrue(this.turn.CheckCommandExists("DDL"));
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
            this.turn.ExecuteCommand("safds");            
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

        [TestMethod]
        public void CheckIfPawnTurnOnlyHasPawnTurnCommands()
        {
            List<string> expectedCommands = new List<string> {"ADR", "ADL", "BDR", "BDL", "CDR", "CDL", "DDR", "DDL"};
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
