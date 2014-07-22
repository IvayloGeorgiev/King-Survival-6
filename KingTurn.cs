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
        private readonly Dictionary<string, int[]> validCommands = new Dictionary<string, int[]> 
        {
            {"kdr", new int[] {1, 1}},
            {"kdl", new int[] {1, -1}},
            {"kur", new int[] {-1, 1}},
            {"kul", new int[] {-1, -1}}
        };

        public KingTurn(GameLogic logic)
        {
            this.Logic = logic;
            this.Message = startMessage;
        }

        public override bool CheckCommand(string input)
        {
            if (input.Length != 3)
            {
                return false;
            }
            else if (this.validCommands.ContainsKey(input.ToLower()))
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

            int[] newPosition = (int[])this.Logic.King.Position.Clone();
            int[] offset = validCommands[input.ToLower()];
            newPosition[0] += offset[0];
            newPosition[1] += offset[1];
            if (this.Logic.BoardPositionIsFree(newPosition))
            {
                this.Logic.King.Move(offset);
            }
            this.Logic.CurrentTurn = new PawnTurn(this.Logic);
            this.Logic.IncrementTurnCounter();
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
