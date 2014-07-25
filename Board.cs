namespace KingSurvivalGame
{
    using System;    

    /// <summary>
    /// Public class, implemeting Singleton patter representing the visible "board" part of the game.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Constant representing the size of the square board (width and height)
        /// </summary>
        private const int TableSize = 8;
        private const int CellWidth = 6;
        private const int CellHeight = 4;
        
        /// <summary>
        /// Constant representing the intital X position where the board starts on the console
        /// </summary>
        private const int XStart = 5;
        
        /// <summary>
        /// Constant representing the intital Y position where the board starts on the console
        /// </summary>
        private const int YStart = 5;

        /// <summary>
        /// Private field containing the single instance of the board
        /// </summary>
        private static Board instance;

        /// <summary>
        /// Public read only property, returning the initial coordinates and sizes of the board to the other rendering methods 
        /// </summary>
        public int[] BoardMeasures
        {
            get
            {
                return new int[]{XStart,CellWidth,YStart,CellHeight};
            }
        }

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
        /// Public class rendering the board once initialized. It uses the constants TableSize, CellWidth and
        /// SellHeight to draw the correct form using three nested loops.
        /// </summary>
        public void DrawBoard()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < TableSize; i++)
            {
                for (int g = 0; g < TableSize; g++)
                {
                    for (int k = 0; k < CellHeight; k++)
                    {
                        Console.SetCursorPosition(XStart + i * CellWidth, YStart + g * CellHeight + k);
                        if ((g % 2 + i % 2) == 0 || (g % 2 - i % 2) == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(new String(' ', CellWidth));
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.Write(new String(' ',CellWidth));
                        }
                    }
                }
            }
        }
    }
}
