namespace KingSurvivalGame
{
using System;
using System.Collections.Generic;

    public class GameLogic
    {
        private const string InvalidCommand = "Invalid command name.";
        private Turn currentTurn;
        private int turnCount;
        private List<Pawn> pawns;
        private King king;
        private IDisplay display;

        public GameLogic(IDisplay display)
        {
            currentTurn = new PawnTurn(this);
            turnCount = 0;
            this.display = display;
            //Factory call for pawns and king here;            
            var kingCreator = new KingCreator();
            var pawnCreator = new PawnCreator();
        }

        public List<Pawn> Pawns
        {
            get { return this.pawns; }
            private set { this.pawns = value; }
        }

        public King King
        {
            get { return this.king; }
            private set { this.King = value; }
        }

        public Turn CurrentTurn
        {
            get { return this.currentTurn; }
            set { this.currentTurn = value; }
        }

        public void IncrementTurnCounter()
        {
            this.turnCount += 1;
        }

        public bool BoardPositionIsFree(int[] newPosition)
        {
            if (newPosition[0] < 0 || newPosition[0] > 7 || newPosition[1] < 0 || newPosition[1] > 7)
            {
                return false;
            }
            foreach (var pawn in Pawns)
            {
                if ((pawn.Position[0] == newPosition[0]) && (pawn.Position[1] == newPosition[1]))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            if (King.Position[0] == newPosition[0] && King.Position[1] == newPosition[1])
            {
                return false;
            }
            return true;
        }

        private List<Figure> GetFigures()
        {
            List<Figure> result = new List<Figure>();
            result.Add(king);
            foreach (var figure in Pawns)
            {
                result.Add(figure);
            }
            return result;
        }

        public bool FigureIsAlive(Figure figure)
        {
            foreach (var command in figure.Commands.Values)
            {
                int[] newPosition = (int[])figure.Position.Clone();
                newPosition[0] += command[0];
                newPosition[1] += command[1];
                if (BoardPositionIsFree(newPosition))
                {
                    return true;
                }
            }
            return false;
        }

        public void Run()
        {
            while (currentTurn.FiguresCanMove())
            {
                string input = display.GetInput();
                if (currentTurn.CheckCommand(input))
                {
                    currentTurn.ExecuteCommand(input);
                    display.DrawBoard(GetFigures());
                    display.ShowMessage(currentTurn.Message);
                }
                else
                {
                    display.ShowMessage(InvalidCommand);
                }
            }
        }
    }
}
