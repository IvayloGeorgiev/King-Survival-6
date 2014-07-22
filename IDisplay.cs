namespace KingSurvivalGame
{
    using System;    
    using System.Collections.Generic;

    public interface IDisplay
    {
        void DrawFigures(List<IDrawable> figures);

        void ShowMessage(string message);

        void ShowError(string message);

        string GetInputRequest();
    }
}
