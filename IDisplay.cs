﻿namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;

    interface IDisplay
    {
        void DrawFigures(List<Figure> figures);

        void ShowMessage(string message);

        void ShowError(string message);

        void ShowInfo(string[] info);

        string GetInputRequest();
    }
}
