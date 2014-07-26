namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Turn
    {        
        private static readonly char[] pawnSymbols = new char[] { 'A', 'B', 'C', 'D' };
        private static readonly int[][] pawnStartingPositions = new int[][] { new int[] { 0, 0 }, new int[] { 2, 0 }, new int[] { 4, 0 }, new int[] { 6, 0 } };
        private const char KingSymbol = 'K';
        private static readonly int[] kingStartingPosition = new int[] { 3, 7 };

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
            for (int i = 0; i < pawnSymbols.Length; i++)
            {
                Figure pawn = pawnCreator.CreateFigure(pawnStartingPositions[i], pawnSymbols[i]);
                this.Pawns.Add(pawn);
            }

            var kingCreator = new KingCreator();
            this.King = kingCreator.CreateFigure(kingStartingPosition, KingSymbol);
        }        

        protected bool BoardPositionIsValid(int[] newPosition)
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

        protected bool FigureIsAlive(Figure figure)
        {
            foreach (var command in figure.MovementCommands)
            {                
                int[] offset = command.Value;
                int[] newPosition = (int[]) figure.Position.Clone();
                newPosition[0] += offset[0];
                newPosition[1] += offset[1];
                if (BoardPositionIsValid(newPosition))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Figure> GetFigures()
        {
            List<Figure> result = new List<Figure>();
            result.Add(king);
            foreach (var figure in Pawns)
            {
                result.Add(figure);
            }
            return result;
        }

        protected abstract void NextTurn();
        public abstract string GetStartTurnMessage();
        public abstract string GetEndGameMessage();
        public abstract bool CheckCommandExists(string input);
        public abstract bool ExecuteCommand(string input);
        public abstract string[] GetCommands();
        public abstract bool FiguresCanMove();        
    }
}
