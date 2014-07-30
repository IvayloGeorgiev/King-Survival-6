namespace KingSurvivalGame.BasicLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KingSurvivalGame.Figures;    

    public abstract class Turn
    {        
        /// <summary>
        /// Default value for initialization of the king and pawn figures associated with the game.
        /// </summary>
        private const char KingSymbol = 'K';
        private static readonly char[] PawnSymbols = new char[] { 'A', 'B', 'C', 'D' };
        private static readonly Position[] PawnStartingPositions = new Position[] { new Position(0, 0), new Position(2, 0), new Position(4, 0), new Position(6, 0) };
        private static readonly Position KingStartingPosition = new Position(3, 7);

        private KingSurvivalEngine engine;                  
        private List<Figure> pawns;
        private Figure king;
        private bool kingWon;
        private int turnCount;

        /// <summary>
        /// Initializes a fresh turn object, also populating the pawns and king objects.
        /// </summary>
        protected Turn()
        {
            this.turnCount = 0;
            this.Pawns = new List<Figure>();
            this.KingWon = false;

            // Calls the factory to initialize starting pawns and king figures.                        
            this.InitializeFigures();
        }

        /// <summary>
        /// Initializes a turn object with the values of the previous one by reference.
        /// </summary>
        /// <param name="turn">The value of the previous turn.</param>
        protected Turn(Turn turn)
        {
            this.TurnCount = turn.TurnCount;
            this.Pawns = turn.Pawns;
            this.King = turn.King;
            this.KingWon = turn.KingWon;
            this.Engine = turn.Engine;
        }

        /// <summary>
        /// Property holding the current instance of the engine, used for communication with the display interface.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if attempting to set a null GameEngine value.</exception>
        public KingSurvivalEngine Engine
        {
            get
            {
                return this.engine;
            }

            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Game engine should not be null.");
                }

                this.engine = value;                                
            }
        }                

        /// <summary>
        /// Property for access to the kingWon variable, which is true when the King figure reaches the top of the game board.
        /// </summary>
        public bool KingWon
        {
            get 
            { 
                return this.kingWon; 
            }

            protected set 
            { 
                this.kingWon = value; 
            }
        }

        /// <summary>
        /// Property for the turnCount variable which is incremented at the end of every KingTurn.
        /// </summary>
        public int TurnCount
        {
            get 
            { 
                return this.turnCount; 
            }

            protected set 
            { 
                this.turnCount = value; 
            }
        }

        /// <summary>
        /// Property holding the current instance of the pawns used by the pawn turn class for movement and by all turn classes for position board checks.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when attempting to set null as a value.</exception>
        protected List<Figure> Pawns
        {
            get
            {
                return this.pawns;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pawns figure list should not be null.");
                }

                this.pawns = value;
            }
        }

        /// <summary>
        /// Property holding the current instance of the king used by the king turn class for movement and by all turn classes for position board checks.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when attempting to set null as a value.</exception>
        protected Figure King
        {
            get
            {
                return this.king;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("King figure should not be null.");
                }

                this.king = value;
            }
        }

        /// <summary>
        /// Returns the default message to be displayed before requesting user input.
        /// </summary>
        /// <returns>The message prompting input for the next turn.</returns>
        public abstract string GetStartTurnMessage();

        /// <summary>
        /// Returns the default message when no figures associated with the current turn are alive.
        /// </summary>
        /// <returns></returns>
        public abstract string GetNoLiveFiguresMessage();

        /// <summary>
        /// Checks if a given command exists.
        /// </summary>
        /// <param name="command">The command that is checked.</param>
        /// <returns>True if the command exists for the current turn, false otherwise.</returns>
        public abstract bool CheckCommandExists(string command);

        /// <summary>
        /// Attempts to execute a command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>True upon successful execution, false otherwise.</returns>
        public abstract bool ExecuteCommand(string command);

        /// <summary>
        /// Returns a string array with all commands that exist for the current turn.
        /// </summary>
        /// <returns>The array with current valid commands.</returns>
        public abstract string[] GetCommands();

        /// <summary>
        /// Checks if any figures associated with the current turn can still move.
        /// </summary>
        /// <returns>True if any figures still have possible moves, false otherwise.</returns>
        public abstract bool FiguresCanMove();

        /// <summary>
        /// Returns a list of all figures associated with the turn class (all pawns and the king).
        /// </summary>
        /// <returns>A new list with all figures contained in any turn class.</returns>
        public List<Figure> GetFigures()
        {
            List<Figure> result = new List<Figure>();
            result.Add(this.king);
            foreach (var figure in this.Pawns)
            {
                result.Add(figure);
            }

            return result;
        }

        /// <summary>
        /// Changes the current execution instance of the turn class in the engine to another.
        /// </summary>
        protected abstract void NextTurn();

        /// <summary>
        /// Checks if a given board is valid (within the bounds of the board) and empty (no other figures currently occupy it).
        /// </summary>
        /// <param name="newPosition">An integer array with two values representing the new position.</param>
        /// <returns>True if the position is valid and empty, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the arrays has length different from two.</exception>
        protected bool BoardPositionIsValidAndEmpty(Position newPosition)
        {
            if (newPosition == null)
            {
                throw new ArgumentNullException("Position should not be null.");
            }                         
            
            if (newPosition.X < 0 || newPosition.X >= GlobalConstants.GameBoardSize || newPosition.Y < 0 || newPosition.Y >= GlobalConstants.GameBoardSize)
            {
                return false;
            }

            foreach (var pawn in this.Pawns)
            {
                if (newPosition.Equals(pawn.Position))
                {
                    return false;
                }
            }

            if (newPosition.Equals(this.King.Position))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if a given figure has any possible moves.
        /// </summary>
        /// <param name="figure">The figure for which the checks are made.</param>
        /// <returns>True if the figure has can move, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the figure is null.</exception>
        protected bool FigureIsAlive(Figure figure)
        {
            if (figure == null)
            {
                throw new ArgumentNullException("Figure should not be null.");
            }

            foreach (var command in figure.MovementCommands)
            {                
                Position offset = command.Value;                

                if (this.BoardPositionIsValidAndEmpty(figure.Position + offset))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Initializes the pawns and king figures used by all turns using default constants.
        /// </summary>
        private void InitializeFigures()
        {
            var pawnCreator = new PawnCreator();
            for (int i = 0; i < PawnSymbols.Length; i++)
            {
                Figure pawn = pawnCreator.CreateFigure(PawnStartingPositions[i], PawnSymbols[i]);
                this.Pawns.Add(pawn);
            }

            var kingCreator = new KingCreator();
            this.King = kingCreator.CreateFigure(KingStartingPosition, KingSymbol);
        }
    }
}
