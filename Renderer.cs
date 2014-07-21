namespace KingSurvivalGame
{
    using System;

    public class Renderer
    {
        public void DrawFigure(IDrawable figToDraw)
        {
            for (int i = 0; i < figToDraw; i++)
            {
                int[] boardMeasures = Board.Instance.BoardMeasures;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(boardMeasures[0] + figToDraw.Position[0] * boardMeasures[1],
                                          boardMeasures[2] + figToDraw.Position[1] * boardMeasures[3] + i);
                Console.WriteLine(figToDraw[i]);
            }
        }
        
        public string GetInputRequest()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(30, 39);
            Console.Write("    Enter the next move: ");
            string playerRequest = Console.ReadLine();
            return playerRequest;
        }
    }
}
