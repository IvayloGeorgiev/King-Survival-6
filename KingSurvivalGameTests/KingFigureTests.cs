namespace KingSurvivalGameTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvivalGame;
    using KingSurvivalGame.Figures;

    [TestClass]
    public class KingFigureTests
    {
        private KingCreator creator;

        [TestInitialize]
        public void Initialize()
        {
            this.creator = new KingCreator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateAKingWithInvalidPosition()
        {            
            this.creator.CreateFigure(new Position(0, 0), 'k');  
            Figure figure = this.creator.CreateFigure(new Position(3, 10), 'K');
            figure.Move(new Position(1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MoveKingToInvalidPosition()
        {                        
            Figure figure = this.creator.CreateFigure(new Position(0, 0), 'K');
            figure.Move(new Position(10, 10));
        }

        [TestMethod]        
        public void MoveKingWithMoveCommand()
        {            
            Figure figure = this.creator.CreateFigure(new Position(0, 0), 'K');            
            figure.Move(figure.MovementCommands["KDR"]);
        }

        [TestMethod]
        public void CheckCommandReturnsFalseWithInvalidCommand()
        {            
            Figure figure = this.creator.CreateFigure(new Position(3, 3), 'K');
            Assert.IsFalse(figure.CheckCommand("AAAAAAAAAA"));
        }

        [TestMethod]
        public void CheckCommandReturnsTrueWithValidCommand()
        {            
            Figure figure = this.creator.CreateFigure(new Position(3, 3), 'K');
            Assert.IsTrue(figure.CheckCommand("KUR"));
        }
    }
}
