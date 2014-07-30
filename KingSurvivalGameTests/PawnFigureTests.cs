namespace KingSurvivalGameTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvivalGame;
    using KingSurvivalGame.Figures;

    [TestClass]
    public class PawnFigureTests
    {
        private PawnCreator creator;

        [TestInitialize]
        public void Initalize()
        {
            this.creator = new PawnCreator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateAaPawnWithInvalidPosition()
        {            
            Figure pawn = this.creator.CreateFigure(new Position(3, 10), 'P');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MovePawnToInvalidPosition()
        {            
            Figure figure = this.creator.CreateFigure(new Position(0, 0), 'P');
            figure.Move(new Position(10, 10));
        }

        [TestMethod]
        public void MovePawnWithMoveCommand()
        {                        
            Figure figure = this.creator.CreateFigure(new Position(0, 0), 'P');
            figure.Move(figure.MovementCommands["PDR"]);
        }

        [TestMethod]
        public void CheckCommandReturnsFalseWithInvalidCommand()
        {            
            Figure figure = this.creator.CreateFigure(new Position(3, 3), 'P');
            Assert.IsFalse(figure.CheckCommand("AAAAAAAAAA"));
        }

        [TestMethod]
        public void CheckCommandReturnsTrueWithValidCommand()
        {            
            Figure figure = this.creator.CreateFigure(new Position(3, 3), 'P');
            Assert.IsTrue(figure.CheckCommand("PDR"));
        }
    }
}
