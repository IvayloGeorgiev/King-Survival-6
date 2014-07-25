namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Renderer : IDisplay
    {
        private Board board;
        const int MessagesPosition_X = 60;
        const int MessagesPosition_Y = 5;

        public Renderer()
        {
            this.board = Board.Instance;
            board.DrawBoard();
        }

        public void DrawFigures(List<IDrawable> figsToDraw)
        {
            Console.BackgroundColor = ConsoleColor.Black; 
            Console.Clear();
            board.DrawBoard();
            foreach (var figure in figsToDraw)
            {
                Console.OutputEncoding = Encoding.UTF8;
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
            Console.SetCursorPosition(MessagesPosition_X, MessagesPosition_Y);
            Console.Write(message);
        }

        public void ShowInfo(string[] message)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(MessagesPosition_X, MessagesPosition_Y+5);
           
            for (int i = 0; i < message.GetLength(0); i++)
            {
                Console.SetCursorPosition(MessagesPosition_X, MessagesPosition_Y + i + 5);
                Console.WriteLine(new string(' ',30));
                Console.SetCursorPosition(MessagesPosition_X, MessagesPosition_Y + i + 5);
                Console.WriteLine(new string(' ', 13) + message[i]);
            }
        }

        public void ShowError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(MessagesPosition_X, MessagesPosition_Y-2);
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Gray;
        }

        public string GetInputRequest()
        {
            Console.SetCursorPosition(MessagesPosition_X, MessagesPosition_Y+1);
            Console.WriteLine(new string(' ',30));
            Console.SetCursorPosition(MessagesPosition_X, MessagesPosition_Y + 1);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string playerRequest = Console.ReadLine();
            return playerRequest;
        }
    }
}
