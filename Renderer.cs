namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;

    public class Renderer : IDisplay
    {
        private Board board;

        public Renderer()
        {
            this.board = Board.Instance;
            board.DrawBoard();
        }

        public void DrawFigures(List<IDrawable> figsToDraw)
        {
            Console.Clear();
            board.DrawBoard();
            foreach (var figure in figsToDraw)
            {                
                int[] boardMeasures = board.BoardMeasures;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                for (int i = 0; i < figure.Shape.Length; i++)
                {
                    Console.SetCursorPosition(boardMeasures[0] + figure.Position[0] * boardMeasures[1],
                                            boardMeasures[2] + figure.Position[1] * boardMeasures[3] + i);
                    Console.WriteLine(figure.Shape[i]);
                }                                
            }            
        }

        public void ShowMessage(string message)
        {                        
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(30, 39);
            Console.Write(message);
        }

        public void ShowError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(30, 38);
            Console.Write(message);
        }

        public string GetInputRequest()
        {                        
            string playerRequest = Console.ReadLine();
            return playerRequest;
        }
    }
}
