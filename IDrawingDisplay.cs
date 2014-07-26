namespace KingSurvivalGame
{
    using System;    
    using System.Collections.Generic;

    public interface IDrawingDisplay
    {
        void DrawFigures(List<IDrawable> figures);

        void ShowMessage(string message);

        void ShowError(string message);

        void ShowInfo(string[] info);

        string GetInputRequest();
    }
}
