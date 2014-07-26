namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Public class, implemeting IShapeDisplay interface
    /// It instantiates draws all additional visible part of the game(figures, messages and input prompts)
    /// through its methods, apart from the board itself
    /// </summary>
    public class Renderer : IDrawingDisplay
    {
        private Board board;
        const int MessagesPosition_X = 60;
        const int MessagesPosition_Y = 5;

        /// <summary>
        /// Public constructor that initializes the board and its first visualization
        /// </summary>
        public Renderer()
        {
            this.board = Board.Instance;
            board.DrawBoard();
        }

        /// <summary>
        /// Draws all kinds of figures on the board
        /// </summary>
        /// <param name="figsToDraw">List of IDrawable objects to be drawn</param>
        public void DrawFigures(List<IDrawable> figsToDraw)
        {
            Console.BackgroundColor = ConsoleColor.Black; 
            Console.Clear();
            board.DrawBoard();
            foreach (var figure in figsToDraw)
            {
                Console.OutputEncoding = Encoding.UTF8;
                /// <summary>
                /// Takes the array of strings from the board consisting of all necessary measures for of board
                /// </summary>
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


        /// <summary>
        /// Shows message on the board in specific location
        /// </summary>
        /// <param name="message">Message to be written</param>
        public void ShowMessage(string message)
        {                        
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(MessagesPosition_X, MessagesPosition_Y);
            Console.Write(message);
        }

        /// <summary>
        /// Shows the possible moves on every turn on the board in specific location
        /// </summary>
        /// <param name="message">String of commands to be written</param>
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

        /// <summary>
        /// Shows the ERROR message if there is a wrong command input
        /// </summary>
        /// <param name="message">The type of the error</param>
        public void ShowError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(MessagesPosition_X, MessagesPosition_Y-2);
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Gets the customer input on every turn
        /// Returns a string with the command
        /// </summary>
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
