namespace KingSurvivalGame.BasicLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KingSurvivalGame.Figures;

    class PawnTurn : Turn
    {
        /// <summary>
        /// Constant representing the message to be displayed when requesting user input.
        /// </summary>
        private const string StartTurnMessage = "Please enter the pawn's turn: ";

        /// <summary>
        /// Used when initializing a PawnTurn when no other turns have existed before it.
        /// </summary>
        /// <param name="logic">The engine that acts as a bridge between the turn logic with the display.</param>
        public PawnTurn(KingPawnEngine gameLogic)
            : base()
        {
            this.Engine = gameLogic;            
        }

        /// <summary>
        /// Called when initializing a pawn turn from another turn.
        /// </summary>
        /// <param name="turn">The instance of the previous turn.</param>
        public PawnTurn(Turn turn)
            : base(turn)
        {
        }

        /// <summary>
        /// Checks if the given command actually exists in any pawn figure. Valid commnads are stored within each pawn.
        /// </summary>
        /// <param name="command">The string representing the command.</param>
        /// <returns>True if command exists, false otherwise.</returns>
        public override bool CheckCommandExists(string command)
        {
            string commandToUpper = command.ToUpper(); 
            Figure affectedFigure = this.Pawns.Find((x) => x.Symbol == commandToUpper[0]);

            if (string.IsNullOrEmpty(commandToUpper))
            {
                return false;
            }
            if (affectedFigure == default(Figure))
            {
                return false;
            }
            else if (affectedFigure.CheckCommand(commandToUpper))
            {
                return true;
            }            
            return false;
        }

        /// <summary>
        /// Executes the given command on the pawn it refers to. If no pawn has the provided command, the method throws an argument exception.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <exception cref="Argument exception">Thrown when when no command matches the given input.</exception>
        /// <returns>True if command executed successfully, false when the command was valid but a figure/board size prevented its execution</returns>
        public override bool ExecuteCommand(string command)
        {
            if (!CheckCommandExists(command))
            {
                throw new ArgumentException("Invalid command.");
            }
            string commandToUpper = command.ToUpper();
            char identifier = commandToUpper[0];
            Figure pawnToMove = this.Pawns.Find((x) => x.Symbol == identifier);

            int[] offset = pawnToMove.MovementCommands[commandToUpper];
            int[] newPosition = (int[]) pawnToMove.Position.Clone();
            newPosition[0] += offset[0];
            newPosition[1] += offset[1];
            if (this.BoardPositionIsValidAndEmpty(newPosition))
            {
                pawnToMove.Move(offset);
                this.NextTurn();
                return true;
            }
            return false;               
        }

        /// <summary>
        /// Returns all commands related to all pawn figures as a string array.
        /// </summary>
        /// <returns>A string array containing all possible pawn commands for all pawns.</returns>
        public override string[] GetCommands()
        {
            List<string> commands = new List<string>();
            commands.Add("Commands:");
            foreach (var pawn in Pawns)
            {                
                foreach (var command in pawn.MovementCommands.Keys)
                {
                    commands.Add(command);
                }
            }
            return commands.ToArray();
        }

        /// <summary>
        /// Checks to see if any pawn figures still have available moves.
        /// </summary>
        /// <returns>True when any pawn can still move to some location, false otherwise.</returns>
        public override bool FiguresCanMove()
        {
            foreach (var pawn in this.Pawns)
            {
                if (this.FigureIsAlive(pawn)) 
                {
                    return true;
                }                
            }
            return false;
        }

        /// <summary>
        /// Returns a message constant to be displayed at the start of each move when requesting input.
        /// </summary>
        /// <returns>String requsting an input prompt.</returns>
        public override string GetStartTurnMessage()
        {
            return StartTurnMessage;
        }

        /// <summary>
        /// Returns a message constant to be displayed at the end of the game if the king won because no pawns can move.
        /// </summary>
        /// <returns>A message regarding the turn on which the king won.</returns>
        public override string GetNoLiveFiguresMessage()
        {
            return string.Format("King won on turn {0}.", this.TurnCount);
        }

        /// <summary>
        /// Used to switch between different turns (states) of the executinos cycle.
        /// </summary>
        protected override void NextTurn()
        {
            this.Engine.CurrentTurn = new KingTurn(this);
        }
    }
}
