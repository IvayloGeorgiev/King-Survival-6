namespace KingSurvivalGameTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvivalGame;
    using KingSurvivalGame.Figures;

    [TestClass]
    public class PawnFigureTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateAaPawnWithInvalidPosition()
        {
            PawnCreator creator = new PawnCreator();
            Figure pawn = creator.CreateFigure(new Position(3, 10), 'P');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MovePawnToInvalidPosition()
        {
            PawnCreator creator = new PawnCreator();
            Figure figure = creator.CreateFigure(new Position(0, 0), 'P');
            figure.Move(new Position(10, 10));
        }

        [TestMethod]
        public void MovePawnWithMoveCommand()
        {
            PawnCreator creator = new PawnCreator();
            Figure figure = creator.CreateFigure(new Position(0, 0), 'P');
            figure.Move(figure.MovementCommands["PDR"]);
        }

        [TestMethod]
        public void CheckCommandReturnsFalseWithInvalidCommand()
        {
            PawnCreator creator = new PawnCreator();
            Figure figure = creator.CreateFigure(new Position(3, 3), 'P');
            Assert.IsFalse(figure.CheckCommand("AAAAAAAAAA"));
        }

        [TestMethod]
        public void CheckCommandReturnsTrueWithValidCommand()
        {
            PawnCreator creator = new PawnCreator();
            Figure figure = creator.CreateFigure(new Position(3, 3), 'P');
            Assert.IsTrue(figure.CheckCommand("PDR"));
        }
    }
}
