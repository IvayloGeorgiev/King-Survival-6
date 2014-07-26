﻿namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;

    class KingTurn : Turn
    {
        /// <summary>
        /// Constant representing the message to be displayed when requesting user input.
        /// </summary>
        private const string StartTurnMessage = "Please enter the king's turn: ";        

        /// <summary>
        /// Used when initializing a KingTurn when no other turns have existed before it.
        /// </summary>
        /// <param name="logic">The engine that acts as a bridge between the turn logic with the display.</param>
        public KingTurn(KingPawnEngine logic)
            : base()
        {
            this.Engine = logic;            
        }

        /// <summary>
        /// Called when initializing a new king turn from another turn.
        /// </summary>
        /// <param name="turn">The instance of the previous turn.</param>
        public KingTurn(Turn turn)
            : base(turn)
        {            
        }

        /// <summary>
        /// Checks if the given command actually exists in the king figure. Valid commnads are KUL, KUR, KDR, KDL
        /// </summary>
        /// <param name="input">The string representing the command.</param>
        /// <returns>True if command exists, false otherwise.</returns>
        public override bool CheckCommandExists(string input)
        {
            string inputToUpper = input.ToUpper();
            Figure affectedFigure = this.King;
            if (string.IsNullOrEmpty(inputToUpper))
            {
                return false;
            }            
            else if (affectedFigure.CheckCommand(inputToUpper))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Executes the given command on the figure it refers to. If no figure has the provided command, the method throws an argument exception.
        /// </summary>
        /// <param name="input">The command to execute</param>
        /// <exception cref="Argument exception">Thrown when when no command matches the given input.</exception>
        /// <returns>True if command executed successfully, false when the command was valid but a figure/board size prevented its execution</returns>
        public override bool ExecuteCommand(string input)
        {
            if (!CheckCommandExists(input))
            {
                throw new ArgumentException("Invalid command.");
            }
            string inputToUpper = input.ToUpper();

            int[] newPosition = (int[]) this.King.Position.Clone();
            int[] offset = this.King.MovementCommands[inputToUpper];
            newPosition[0] += offset[0];
            newPosition[1] += offset[1];
            if (this.BoardPositionIsValidAndEmpty(newPosition))
            {
                this.King.Move(offset);
                this.KingWon = CheckWinCondition();
                this.TurnCount += 1;
                this.NextTurn();
                return true;
            }                        
            return false;
        }

        /// <summary>
        /// Returns a string array containing all commands valid for the KingTurn type. Those include all king movement commands - KUR, KUL, KDR, KDL.
        /// </summary>
        /// <returns>String array containing all possible king movement commands.</returns>
        public override string[] GetCommands()
        {
            List<string> commands = new List<string>();
            commands.Add("Commands:");
            foreach (var command in King.MovementCommands.Keys)
            {
                commands.Add(command);
            }            
            return commands.ToArray();
        }

        /// <summary>
        /// Checks to see if the king figure related to this turn still has available moves.
        /// </summary>
        /// <returns>True when the figure can still move to some location, false otherwise.</returns>
        public override bool FiguresCanMove()
        {
            if (FigureIsAlive(this.King))
            {
                return true;
            }
            else
            {
                return false;
            }
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
        /// Returns a message constant to be displayed at the end of the game if the king lost because he has no more available moves.
        /// </summary>
        /// <returns>A message regarding the turn on which the king lost.</returns>
        public override string GetNoLiveFiguresMessage()
        {
            return string.Format("King lost on turn {0}", this.TurnCount);
        }

        /// <summary>
        /// Checks if the king has reached the topmost row of the board.
        /// </summary>
        /// <returns>True if the king is at the topmost row, false otherwise.</returns>
        private bool CheckWinCondition()
        {
            bool kingWon = (this.King.Position[1] == 0);
            return kingWon;
        }

        /// <summary>
        /// Used to switch between different turns (states) of the executinos cycle.
        /// </summary>
        protected override void NextTurn()
        {
            this.Engine.CurrentTurn = new PawnTurn(this);
        }
    }
}
