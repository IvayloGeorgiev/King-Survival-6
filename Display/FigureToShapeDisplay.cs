namespace KingSurvivalGame.Display
{
    using System;
    using System.Collections.Generic;
    using KingSurvivalGame.Interfaces;
    using KingSurvivalGame.Figures;

    class FigureToShapeDisplay : IDisplay
    {
        private readonly IDrawingDisplay shapeDisplay;

        /// <summary>
        /// Instantiates a new FigureToShapeDisplay which will adapt for an IDrawingDisplay.
        /// </summary>
        public FigureToShapeDisplay()
        {
            this.shapeDisplay = new Renderer();
        }

        /// <summary>
        /// Draws the provided figures together with the game board.
        /// </summary>
        /// <param name="figures"></param>
        public void DrawFigures(List<Figure> figures)
        {
            List<IDrawable> drawings = GetDrawings(figures);
            shapeDisplay.DrawFigures(drawings);
        }

        /// <summary>
        /// Displays the given message.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public void ShowMessage(string message)
        {
            shapeDisplay.ShowMessage(message);
        }

        /// <summary>
        /// Displays an error message.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public void ShowError(string message)
        {
            shapeDisplay.ShowError(message);
        }

        /// <summary>
        /// Displays an info box. The informatin to be displayed is supplied as an array of strings. Each string is displayed on a new line.
        /// </summary>
        /// <param name="info">The string array with information.</param>
        public void ShowInfo(string[] info)
        {
            shapeDisplay.ShowInfo(info);
        }

        /// <summary>
        /// Get an input string from the display.
        /// </summary>
        /// <returns>The user input string.</returns>
        public string GetInputRequest()
        {
            return shapeDisplay.GetInputRequest();
        }

        /// <summary>
        /// Transforms a list of figures into a list of drawings to be displayed by the shapeDisplay.
        /// </summary>
        /// <param name="figures">The figures that will be transformed.</param>
        /// <returns>The list of drawing objects to be displayed.</returns>
        private List<IDrawable> GetDrawings(List<Figure> figures)
        {
            List<IDrawable> drawings = new List<IDrawable>();
            foreach (var figure in figures)
            {
                if (figure is King)
                {
                    drawings.Add(new KingDrawing(figure));
                }
                else if (figure is Pawn)
                {
                    drawings.Add(new PawnDrawing(figure));
                }
            }
            return drawings;
        }
    }
}
