using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public abstract class Turn
    {        
        private static readonly char[] PawnSymbols = new char[] { 'A', 'B', 'C', 'D' };
        private static readonly int[][] PawnStartingPositions = new int[][] { new int[] { 0, 0 }, new int[] { 2, 0 }, new int[] { 4, 0 }, new int[] { 6, 0 } };
        private const char KingSymbol = 'K';
        private static readonly int[] KingStartPosition = new int[] { 3, 7 };

        private GameLogic logic;          

        private int turnCount;
        private List<Figure> pawns;
        private Figure king;
        private bool kingWon;

        protected Turn()
        {
            this.turnCount = 0;
            this.Pawns = new List<Figure>();
            KingWon = false;
            //Calls the factory to initialize starting pawns and king figures.                        
            InitializeFigures();
        }

        protected Turn(Turn turn)
        {
            this.TurnCount = turn.TurnCount;
            this.Pawns = turn.Pawns;
            this.King = turn.King;
            this.KingWon = turn.KingWon;
            this.Logic = turn.Logic;
        }

        public GameLogic Logic
        {
            get
            {
                return this.logic;
            }
            protected set
            {
                this.logic = value;
            }
        }                

        public List<Figure> Pawns
        {
            get { return this.pawns; }
            protected set { this.pawns = value; }
        }

        public Figure King
        {
            get { return this.king; }
            protected set { this.king = value; }
        }

        public bool KingWon
        {
            get { return this.kingWon; }
            protected set { this.kingWon = value; }
        }

        public int TurnCount
        {
            get { return this.turnCount; }
            protected set { this.turnCount = value; }
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

        protected bool BoardPositionIsFree(int[] newPosition)
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

        protected int[] GetCommandOffset(string command)
        {
            string commandToUpper = command.ToUpper();
            switch (commandToUpper)
            {
                case "DR": return new int[] { 1, 1 };
                case "DL": return new int[] { -1, 1 };
                case "UR": return new int[] { 1, -1 };
                case "UL": return new int[] { -1, -1 };
                default: throw new ArgumentException("Invalid command.");
            }
        }

        protected bool FigureIsAlive(Figure figure)
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

        public List<IDrawable> GetFigures()
        {
            List<IDrawable> result = new List<IDrawable>();
            result.Add(king);
            foreach (var figure in Pawns)
            {
                result.Add(figure);
            }
            return result;
        }

        public abstract string GetStartTurnMessage();
        public abstract string GetEndGameMessage();
        public abstract bool CheckCommand(string input);
        public abstract string ExecuteCommand(string input);
        public abstract bool FiguresCanMove();        
    }
}
