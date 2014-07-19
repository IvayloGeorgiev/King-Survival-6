using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public class Engine
    {
        private GameLogic gameLogic;        

        //Initialization logic goes here.
        public void Initialize()
        {
            this.gameLogic = new GameLogic();
        }

        //Basic game logic goes here (increment counters, contact proxy to check input/move figures, etc).
        public void Run()
        {
            throw new NotImplementedException();
        }
     
        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}
