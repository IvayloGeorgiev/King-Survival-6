﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvivalGame
{
    class KingPawsGame : Game
    {
        protected static void InteractWithUser(int moveCounter)
        {
            if (gameIsFinished)
            { //igrata svyrshi
                Console.WriteLine("Game is finished!");
                return;
            }
            else
            {
                if (moveCounter % 2 == 0)
                {
                    DrawBoard();
                    ProcessKingSide();
                }
                else
                {
                    DrawBoard();
                    ProcessPawnSide();
                }
            }
        }

        static void ProcessKingSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.Write("Please enter king's turn: ");
                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.ToUpper();//! input =
                    isExecuted = Movement(input);
                }
                else
                {
                    isExecuted = false;
                    Console.WriteLine("Please enter something!");
                }
            }
            InteractWithUser(counter);
        }

        static void ProcessPawnSide() 
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.Write("Please enter pawn's turn: ");
                string input = Console.ReadLine();
                //input = input.Trim();
                if (input != null)//"/n")
                {
                    // Console.WriteLine(input);
                    //Console.WriteLine("hahah");
                    input = input.ToUpper();//! input =
                    isExecuted = Movement(input);
                }
                else
                {
                    isExecuted = false;
                    Console.WriteLine("Please enter something!");
                }
            }
            InteractWithUser(counter);
        }
    }
}
