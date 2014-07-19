using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    class PawnTurn : Turn
    {
        private GameLogic gameLogic;
        private readonly Dictionary<string, int[]> validCommands = new Dictionary<string, int[]> 
        {
            {"dr", new int[] {1, 1}},
            {"dl", new int[] {1, -1}}
        };

        public PawnTurn(GameLogic gameLogic)
        {
            this.gameLogic = gameLogic;
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
            else if (gameLogic.Pawns.Any((x) => char.ToLower(x.Symbol) == char.ToLower(input[0])))
            {
                return false;
            }
            return true;
        }

        public override string ExecuteCommand(string input)
        {
            if (!CheckCommand(input))
            {
                throw new ArgumentException("Unknown command string.");
            }
            string direction = input.Substring(1).ToLower();
            char identifier = input[0];
            Pawn toMove = gameLogic.Pawns.Find((x) => char.ToLower(x.Symbol) == char.ToLower(identifier));
            toMove.Move(validCommands[direction]);
            gameLogic.CurrentTurn = new KingTurn(this.gameLogic);

            return string.Empty;
        }
    }
}
