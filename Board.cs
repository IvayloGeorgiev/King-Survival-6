namespace KingSurvivalGame
{
    using System;
    using System.Text;
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
            DrawBoard();
            IList<Figure> initialFigureList = new List<Figure>();
            initialFigureList.Add(FigureSimpleFactory.GetFigure(FigureType.King, new int[] { 3, 7 }, 'K'));
            initialFigureList.Add(FigureSimpleFactory.GetFigure(FigureType.Pawn, new int[] { 0, 0 }, 'A'));
            initialFigureList.Add(FigureSimpleFactory.GetFigure(FigureType.Pawn, new int[] { 2, 0 }, 'B'));
            initialFigureList.Add(FigureSimpleFactory.GetFigure(FigureType.Pawn, new int[] { 4, 0 }, 'C'));
            initialFigureList.Add(FigureSimpleFactory.GetFigure(FigureType.Pawn, new int[] { 6, 0 }, 'D'));
            //DrawPlayers(initialFigureList);
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
        //public void DrawPlayers(IList<Figure> figures)
        //{
        //
        //    foreach (Figure fig in figures)
        //    {
        //        if (fig.Symbol == 'K')
        //        {
        //            DrawKing(fig);
        //        }
        //        else
        //        {
        //            DrawPawn(fig);
        //        }
        //    }
        //    GetInputRequest();
        //}
        //public void DrawPawn(Figure figToDraw) 
        //{
        //    Console.OutputEncoding = Encoding.UTF8;
        //    string[] pawn = { "  \u25E2\u25E3  ", " \u25E2\u2588\u2588\u25E3 ", " \u25E2\u2588\u2588\u25E3 ", " \u2588\u2588\u2588\u2588 ", figToDraw.Symbol.ToString() };
        //    for (int i = 0; i < pawn.Length; i++)
        //    {
        //        Console.BackgroundColor = ConsoleColor.Gray;
        //        Console.ForegroundColor = ConsoleColor.DarkYellow;
        //        Console.SetCursorPosition(XStart + figToDraw.Position[0] * CellWidth, YStart + figToDraw.Position[1] * CellHeight + i);
        //        Console.WriteLine(pawn[i]);
        //    }
        //}
        //public void DrawKing(Figure figToDraw)
        //{
        //    string[] king = { "K","\u2588 \u2588\u2588 \u2588", " \u2588\u2588\u2588\u2588 ", " \u2588\u2588\u2588\u2588 ", "\u2588\u2588\u2588\u2588\u2588\u2588" };
        //    for (int i = 0; i < king.Length; i++)
        //    {
        //        Console.BackgroundColor = ConsoleColor.Gray;
        //        Console.ForegroundColor = ConsoleColor.DarkBlue;
        //        Console.SetCursorPosition(XStart + figToDraw.Position[0] * CellWidth, (YStart + figToDraw.Position[1] * CellHeight + i)-1);
        //        Console.WriteLine(king[i]);
        //    }
        //}
        //public string GetInputRequest()
        //{
        //    Console.BackgroundColor = ConsoleColor.Gray;
        //    Console.ForegroundColor = ConsoleColor.DarkBlue;
        //    Console.SetCursorPosition(30, 39);
        //    Console.Write("    Enter the next move: ");
        //    string playerRequest = Console.ReadLine();
        //    return playerRequest;
        //}
    }
}
