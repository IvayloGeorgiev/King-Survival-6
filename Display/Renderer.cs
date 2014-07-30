namespace KingSurvivalGame.Display
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using KingSurvivalGame.Interfaces;

    /// <summary>
    /// Public class, implemeting IShapeDisplay interface
    /// It instantiates draws all additional visible part of the game(figures, messages and input prompts)
    /// through its methods, apart from the board itself
    /// </summary>
    public class Renderer : IDrawingDisplay
    {
        private const int MessagesPositionX = 60;
        private const int MessagesPositionY = 5;
        private const int InfoPositionOffsetY = 5;
        private const int InfoPositionOffsetX = 13;
        private const int StringLineLength = 30;

        private Board board;

        /// <summary>
        /// Public constructor that initializes the board and its first visualization
        /// </summary>
        public Renderer()
        {
            this.board = Board.Instance;
            this.board.DrawBoard();
        }

        /// <summary>
        /// Draws all kinds of figures on the board
        /// </summary>
        /// <param name="figsToDraw">List of IDrawable objects to be drawn</param>
        public void DrawFigures(List<IDrawable> figsToDraw)
        {
            Console.BackgroundColor = ConsoleColor.Black; 
            Console.Clear();
            this.board.DrawBoard();
            foreach (var figure in figsToDraw)
            {
                Console.OutputEncoding = Encoding.UTF8;
                /// <summary>
                /// Takes the array of strings from the board consisting of all necessary measures for of board
                /// </summary>
                int[] boardMeasures = this.board.BoardMeasures;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                for (int i = 0; i < figure.Shape.Length; i++)
                {
                    Console.SetCursorPosition(
                        boardMeasures[0] + (figure.Position.X * boardMeasures[1]),
                        boardMeasures[2] + (figure.Position.Y * boardMeasures[3]) + i);
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
            Console.SetCursorPosition(MessagesPositionX, MessagesPositionY);
            Console.WriteLine(message);
        }

        /// <summary>
        /// Shows the possible moves on every turn on the board in specific location
        /// </summary>
        /// <param name="message">String of commands to be written</param>
        public void ShowInfo(string[] message)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(MessagesPositionX, MessagesPositionY + InfoPositionOffsetY);
           
            for (int i = 0; i < message.Length; i++)
            {
                Console.SetCursorPosition(MessagesPositionX, MessagesPositionY + i + InfoPositionOffsetY);
                Console.WriteLine(new string(' ', StringLineLength));
                Console.SetCursorPosition(MessagesPositionX, MessagesPositionY + i + InfoPositionOffsetY);
                Console.WriteLine(new string(' ', InfoPositionOffsetX) + message[i]);
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
            Console.SetCursorPosition(MessagesPositionX, MessagesPositionY - 2);
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Gets the customer input on every turn
        /// Returns a string with the command
        /// </summary>
        public string GetInputRequest()
        {
            Console.SetCursorPosition(MessagesPositionX, MessagesPositionY + 1);
            Console.WriteLine(new string(' ', StringLineLength));
            Console.SetCursorPosition(MessagesPositionX, MessagesPositionY + 1);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string playerRequest = Console.ReadLine();
            return playerRequest;
        }
    }
}
