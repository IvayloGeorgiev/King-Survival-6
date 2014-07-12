namespace KingSurvivalGame
{
    using System;
    using System.Text;

    public class Board
    {
        private const int TableSize = 8;
        private const int CellWidth = 6;
        private const int CellHeight = 4;
        private const int XStart = 30;
        private const int YStart = 5;
        private static Board instance;

        private Board()
        {
            DrawBoard();
            DrawPlayers();
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
        public static void DrawPlayers()
        {
            DrawPawn(0, 0);
            DrawPawn(2, 0);
            DrawPawn(4, 0);
            DrawPawn(6, 0);
            DrawKing(3, 7);
        }
        public static void DrawPawn(int x,int y) 
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] pawn = { "  \u25E2\u25E3  ", " \u25E2\u2588\u2588\u25E3 ", " \u25E2\u2588\u2588\u25E3 ", " \u2588\u2588\u2588\u2588 " };
            for (int i = 0; i < pawn.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(XStart+x*CellWidth,YStart+y*CellHeight+i);
                Console.WriteLine(pawn[i]);
            }
        }
        public static void DrawKing(int x, int y)
        {
            string[] king = { "\u2588\u2582\u2588\u2588\u2582\u2588", "\u25E5\u2588\u2588\u2588\u2588\u25E4", " \u2588\u2588\u2588\u2588 ", "\u2588\u2588\u2588\u2588\u2588\u2588" };
            for (int i = 0; i < king.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(XStart + x * CellWidth, YStart + y * CellHeight + i);
                Console.WriteLine(king[i]);
            }
        }
    }
}
