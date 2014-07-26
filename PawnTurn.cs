namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PawnTurn : Turn
    {
        private const string StartTurnMessage = "Please enter the pawn's turn: ";                

        public PawnTurn(GameLogic gameLogic)
            : base()
        {
            this.Logic = gameLogic;            
        }

        public PawnTurn(Turn turn)
            : base(turn)
        {
        }

        public override bool CheckCommandExists(string input)
        {
            string inputToUpper = input.ToUpper(); 
            Figure affectedFigure = this.Pawns.Find((x) => x.Symbol == inputToUpper[0]);

            if (string.IsNullOrEmpty(inputToUpper))
            {
                return false;
            }
            if (affectedFigure == default(Figure))
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
            char identifier = inputToUpper[0];
            Figure pawnToMove = this.Pawns.Find((x) => x.Symbol == identifier);

            int[] offset = pawnToMove.MovementCommands[inputToUpper];
            int[] newPosition = (int[]) pawnToMove.Position.Clone();
            newPosition[0] += offset[0];
            newPosition[1] += offset[1];
            if (this.BoardPositionIsValid(newPosition))
            {
                pawnToMove.Move(offset);
                this.Logic.CurrentTurn = new KingTurn(this);
                return true;
            }
            return false;               
        }

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

        public override string GetStartTurnMessage()
        {
            return StartTurnMessage;
        }

        public override string GetEndGameMessage()
        {
            return string.Format("King won on turn {0}.", this.TurnCount);
        }
    }
}
