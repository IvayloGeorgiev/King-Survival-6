namespace KingSurvivalGame
{
    using System;    
    using System.Collections.Generic;

    public class Board
    {
        private const int TableSize = 8;
        private const int CellWidth = 6;
        private const int CellHeight = 4;
        private const int XStart = 30;
        private const int YStart = 5;
        private static Board instance;

        public int[] BoardMeasures
        {
            get
            {
                return new int[]{XStart,CellWidth,YStart,CellHeight};
            }
        }

        private Board()
        {            
        }

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
