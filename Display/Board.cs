﻿namespace KingSurvivalGame.Display
{
    using System;    

    /// <summary>
    /// Public class, implemeting Singleton patter representing the visible "board" part of the game.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Constants representing the size of a cell on the square board (width and height)
        /// </summary>        
        private const int CellWidth = 6;
        private const int CellHeight = 4;
        
        /// <summary>
        /// Constant representing the intitial X position where the board starts on the console
        /// </summary>
        private const int XStart = 5;
        
        /// <summary>
        /// Constant representing the intitial Y position where the board starts on the console
        /// </summary>
        private const int YStart = 5;

        /// <summary>
        /// Private field containing the single instance of the board
        /// </summary>
        private static Board instance;

        /// <summary>
        /// Initializes a new instance of the Board class
        /// </summary>
        private Board()
        {
        }

        /// <summary>
        /// Initializes a single new instance of the Board class through a check for existence of such 
        /// </summary>
        public static Board Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Board();
                }

                return instance;
            }
        }

        /// <summary>
        /// Public read only property, returning the initial coordinates and sizes of the board to the other rendering methods 
        /// </summary>
        public int[] BoardMeasures
        {
            get
            {
                return new int[] { XStart, CellWidth, YStart, CellHeight };
            }
        }        

        /// <summary>
        /// Public class rendering the board once initialized. It uses the constants TableSize, CellWidth and
        /// SellHeight to draw the correct form using three nested loops.
        /// </summary>
        public void DrawBoard()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;            
            for (int row = 0; row < GlobalConstants.GameBoardSize; row++)
            {
                for (int col = 0; col < GlobalConstants.GameBoardSize; col++)
                {
                    for (int cellY = 0; cellY < CellHeight; cellY++)
                    {
                        Console.SetCursorPosition(XStart + (row * CellWidth), YStart + (col * CellHeight) + cellY);
                        if ((col % 2) + (row % 2) == 0 || (col % 2) - (row % 2) == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(new string(' ', CellWidth));
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.Write(new string(' ', CellWidth));
                        }
                    }
                }
            }
        }
    }
}
