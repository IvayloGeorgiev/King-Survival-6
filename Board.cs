namespace KingSurvivalGame
{
    using System;

    public class Board
    {
        private const int TableSize = 8;
        private const int CellWidth = 6;
        private const int CellHeight = 4;
        private static Board instance;

        private Board()
        {
            DrawBoard();

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
        public static void DrawBoard()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < TableSize; i++)
            {
                for (int g = 0; g < TableSize; g++)
                {
                    for (int k = 0; k < CellHeight; k++)
                    {
                        Console.SetCursorPosition(40 + i * CellWidth, 20 + g * CellHeight + k);
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
            Console.SetCursorPosition(0, 50);
        }
        public static void DrawPlayers()
        {

        }
    }
}
