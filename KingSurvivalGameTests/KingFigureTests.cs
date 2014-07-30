namespace KingSurvivalGameTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvivalGame;
    using KingSurvivalGame.Figures;

    [TestClass]
    public class KingFigureTests
    {        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateAKingWithInvalidPosition()
        {
            KingCreator creator = new KingCreator();
            creator.CreateFigure(new Position(0, 0), 'k');  
            Figure figure = creator.CreateFigure(new Position(3, 10), 'K');
            figure.Move(new Position(1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MoveKingToInvalidPosition()
        {
            KingCreator creator = new KingCreator();
            Figure figure = creator.CreateFigure(new Position(0, 0), 'K');
            figure.Move(new Position(10, 10));
        }

        [TestMethod]        
        public void MoveKingWithMoveCommand()
        {
            KingCreator creator = new KingCreator();
            Figure figure = creator.CreateFigure(new Position(0, 0), 'K');            
            figure.Move(figure.MovementCommands["KDR"]);
        }

        [TestMethod]
        public void CheckCommandReturnsFalseWithInvalidCommand()
        {
            KingCreator creator = new KingCreator();
            Figure figure = creator.CreateFigure(new Position(3, 3), 'K');
            Assert.IsFalse(figure.CheckCommand("AAAAAAAAAA"));
        }

        [TestMethod]
        public void CheckCommandReturnsTrueWithValidCommand()
        {
            KingCreator creator = new KingCreator();
            Figure figure = creator.CreateFigure(new Position(3, 3), 'K');
            Assert.IsTrue(figure.CheckCommand("KUR"));
        }
    }
}
