﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    class KingTurn : Turn
    {
        private GameLogic gameLogic;
        private readonly Dictionary<string, int[]> validCommands = new Dictionary<string, int[]> 
        {
            {"kdr", new int[] {1, 1}},
            {"kdl", new int[] {1, -1}},
            {"kur", new int[] {-1, 1}},
            {"kul", new int[] {-1, -1}}
        };
        
        public KingTurn(GameLogic gameLogic)
        {
            this.gameLogic = gameLogic;
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
                throw new ArgumentException("Unknown command string.");
            }           
            gameLogic.King.Move(validCommands[input.ToLower()]);
            gameLogic.CurrentTurn = new KingTurn(this.gameLogic);
            gameLogic.IncrementTurnCounter();
            return string.Empty;
        }
    }
}
