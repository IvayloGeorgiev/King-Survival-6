namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;

    class KingTurn : Turn
    {
        private const string StartTurnMessage = "Please enter the king's turn: ";        

        public KingTurn(GameLogic logic)
            : base()
        {
            this.Logic = logic;            
        }

        public KingTurn(Turn turn)
            : base(turn)
        {            
        }

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
            if (this.BoardPositionIsValid(newPosition))
            {
                this.King.Move(offset);
                this.KingWon = CheckWinCondition();
                this.TurnCount += 1;
                this.Logic.CurrentTurn = new PawnTurn(this);
                return true;
            }                        
            return false;
        }

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

        public override string GetStartTurnMessage()
        {
            return StartTurnMessage;
        }

        public override string GetEndGameMessage()
        {
            return string.Format("King lost on turn {0}", this.TurnCount);
        }

        private bool CheckWinCondition()
        {
            bool kingWon = (this.King.Position[1] == 0);
            return kingWon;
        }
    }
}
