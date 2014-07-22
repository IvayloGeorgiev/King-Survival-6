namespace KingSurvivalGame
{
using System;
using System.Collections.Generic;

    public class GameLogic
    {
        private const string InvalidCommand = "Invalid command name.";
        private readonly char[] PawnSymbols = new char[] {'A', 'B', 'C', 'D'};
        private readonly int[][] PawnStartingPositions = new int[][] { new int[] { 0, 0 }, new int[] { 2, 0 }, new int[] { 4, 0 }, new int[] { 6, 0 } };
        private const char KingSymbol = 'K';
        private readonly int[] KingStartPosition = new int[] { 3, 7 };        

        private Turn currentTurn;
        private int turnCount;
        private List<Figure> pawns;
        private Figure king;
        private IDisplay display;

        public GameLogic()
        {
            currentTurn = new KingTurn(this);
            turnCount = 0;
            this.display = new Renderer();
            this.Pawns = new List<Figure>();
            //Factory call for pawns and king here;                        
            InitializeFigures();
        }

        private void InitializeFigures()
        {            
            var pawnCreator = new PawnCreator();                        
            for (int i = 0; i < PawnSymbols.Length; i++)
            {
                Figure pawn = pawnCreator.CreateFigure(PawnStartingPositions[i], PawnSymbols[i]);
                this.Pawns.Add(pawn);
            }

            var kingCreator = new KingCreator();
            this.King = kingCreator.CreateFigure(KingStartPosition, KingSymbol);
        }

        public List<Figure> Pawns
        {
            get { return this.pawns; }
            private set { this.pawns = value; }
        }

        public Figure King
        {
            get { return this.king; }
            private set { this.king = value; }
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
            }
            if (King.Position[0] == newPosition[0] && King.Position[1] == newPosition[1])
            {
                return false;
            }
            return true;
        }

        public int[] GetCommandOffset(string command)
        {
            string commandToUpper = command.ToUpper();
            switch (commandToUpper)
            {
                case "DR": return new int[] { 1, 1 };
                case "DL": return new int[] { -1, 1 };
                case "UR": return new int[] { 1, -1 };
                case "UL": return new int[] { -1, -1 };
                default: throw new ArgumentException(InvalidCommand);
            }
        }

        public bool FigureIsAlive(Figure figure)
        {
            foreach (var command in figure.ValidSubCommands)
            {
                int[] offset = GetCommandOffset(command.Substring(1));
                int[] newPosition = (int[])figure.Position.Clone();
                newPosition[0] += offset[0];
                newPosition[1] += offset[1];
                if (BoardPositionIsFree(newPosition))
                {
                    return true;
                }
            }
            return false;
        }

        private List<IDrawable> GetFigures()
        {
            List<IDrawable> result = new List<IDrawable>();
            result.Add(king);
            foreach (var figure in Pawns)
            {
                result.Add(figure);
            }
            return result;
        }                

        public void Run()
        {
            display.DrawFigures(GetFigures());
            display.ShowMessage(currentTurn.Message);
            while (currentTurn.FiguresCanMove())
            {
                string input = display.GetInputRequest();
                if (currentTurn.CheckCommand(input))
                {
                    currentTurn.ExecuteCommand(input);
                    display.DrawFigures(GetFigures());
                    display.ShowMessage(currentTurn.Message);
                }
                else
                {
                    display.ShowError(InvalidCommand);
                    display.ShowMessage(currentTurn.Message);
                }
            }
            Console.WriteLine("Game ended"); //TO DO - End game logic
        }
    }
}
