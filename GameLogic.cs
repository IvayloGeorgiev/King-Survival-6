using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public class GameLogic
    {
        private Turn currentTurn;
        private int turnCount;
        private List<Pawn> pawns;
        private King king;

        public GameLogic()
        {
            currentTurn = new PawnTurn(this);
            turnCount = 0;
            //Factory call for pawns and king here; 
            var kingCreator = new KingCreator();
            var pawnCreator = new PawnCreator();
        }


        public List<Pawn> Pawns
        {
            get { return this.pawns; }
            private set { this.pawns = value; }
        }

        public King King
        {
            get { return this.king; }
            private set { this.King = value; }
        }

        public Turn CurrentTurn
        {
            get { return this.currentTurn; }
            set { this.currentTurn = value; }
        }

        public void IncrementTurnCounter()
        {
            this.turnCount += 1;
        }
    }
}
