using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    class PawnTurn : Turn
    {
        private const string turnMessage = "Please enter the pawn's turn: ";        
        private readonly Dictionary<string, int[]> validCommands = new Dictionary<string, int[]> 
        {
            {"dr", new int[] {1, 1}},
            {"dl", new int[] {1, -1}}
        };

        public PawnTurn(GameLogic gameLogic)
        {
            this.Logic = gameLogic;
            this.Message = turnMessage;
        }

        public override bool CheckCommand(string input)
        {
            if (input.Length != 3)
            {
                return false;
            }
            else if (!this.validCommands.ContainsKey(input.Substring(1).ToLower()))
            {
                return false;
            }
            else if (this.Logic.Pawns.Any((x) => char.ToLower(x.Symbol) == char.ToLower(input[0])))
            {
                return false;
            }
            return true;
        }

        public override string ExecuteCommand(string input)
        {
            if (!CheckCommand(input))
            {
                throw new ArgumentException("Invalid command.");
            }            
            char identifier = input[0];
            Pawn pawnToMove = this.Logic.Pawns.Find((x) => char.ToLower(x.Symbol) == char.ToLower(identifier));

            string direction = input.Substring(1).ToLower();
            int[] offset = validCommands[direction];
            int[] newPosition = (int[]) pawnToMove.Position.Clone();
            newPosition[0] += offset[0];
            newPosition[1] += offset[1];
            if (this.Logic.BoardPositionIsFree(newPosition))
            {
                pawnToMove.Move(offset);
            }
            
            pawnToMove.Move(validCommands[direction]);
            this.Logic.CurrentTurn = new KingTurn(this.Logic);

            return string.Empty;
        }

        public override bool FiguresCanMove()
        {
            foreach (var pawn in this.Logic.Pawns)
            {
                if (this.Logic.FigureIsAlive(pawn)) 
                {
                    return true;
                }                
            }
            return false;
        }
    }
}
