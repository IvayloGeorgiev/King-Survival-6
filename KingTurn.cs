using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    class KingTurn : Turn
    {
        private const string startMessage = "Please enter the king's turn: ";        

        public KingTurn(GameLogic logic)
        {
            this.Logic = logic;
            this.Message = startMessage;
        }

        public override bool CheckCommand(string input)
        {
            string inputToUpper = input.ToUpper();
            Figure affectedFigure = this.Logic.King;
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

        public override string ExecuteCommand(string input)
        {
            if (!CheckCommand(input))
            {
                throw new ArgumentException("Invalid command.");
            }
            string inputToUpper = input.ToUpper();

            int[] newPosition = (int[]) this.Logic.King.Position.Clone();
            int[] offset = this.Logic.GetCommandOffset(inputToUpper.Substring(1));
            newPosition[0] += offset[0];
            newPosition[1] += offset[1];
            if (this.Logic.BoardPositionIsFree(newPosition))
            {
                this.Logic.King.Move(offset);
                this.Logic.CurrentTurn = new PawnTurn(this.Logic);
                this.Logic.IncrementTurnCounter();
            }                        
            return string.Empty;
        }

        public override bool FiguresCanMove()
        {
            if (this.Logic.FigureIsAlive(this.Logic.King))
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
    }
}
