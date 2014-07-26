namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FigureToShapeDisplay : IDisplay
    {
        private readonly Renderer shapeDisplay;

        public FigureToShapeDisplay()
        {
            this.shapeDisplay = new Renderer();
        }

        public void DrawFigures(List<Figure> figures)
        {
            List<IDrawable> drawings = GetDrawings(figures);
            shapeDisplay.DrawFigures(drawings);
        }

        public void ShowMessage(string message)
        {
            shapeDisplay.ShowMessage(message);
        }

        public void ShowError(string message)
        {
            shapeDisplay.ShowError(message);
        }

        public void ShowInfo(string[] info)
        {
            shapeDisplay.ShowInfo(info);
        }

        public string GetInputRequest()
        {
            return shapeDisplay.GetInputRequest();
        }

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
