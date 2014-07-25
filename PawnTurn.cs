namespace KingSurvivalGame
{
    using System;
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

        public override bool CheckCommand(string input)
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

        public override string ExecuteCommand(string input)
        {
            if (!CheckCommand(input))
            {
                throw new ArgumentException("Invalid command.");
            }
            string inputToUpper = input.ToUpper();
            char identifier = inputToUpper[0];
            Figure pawnToMove = this.Pawns.Find((x) => x.Symbol == identifier);

            string direction = inputToUpper.Substring(1);
            int[] offset = this.GetCommandOffset(direction);
            int[] newPosition = (int[]) pawnToMove.Position.Clone();
            newPosition[0] += offset[0];
            newPosition[1] += offset[1];
            if (this.BoardPositionIsFree(newPosition))
            {
                pawnToMove.Move(offset);
                this.Logic.CurrentTurn = new KingTurn(this);
            }
            
            return string.Empty;
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
