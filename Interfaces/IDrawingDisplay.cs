namespace KingSurvivalGame.Interfaces
{
    using System;    
    using System.Collections.Generic;

    /// <summary>
    /// Uses shapes to display and receive information from the user.
    /// </summary>
    public interface IDrawingDisplay
    {
        /// <summary>
        /// Draws the given shapes on the display.
        /// </summary>
        /// <param name="shapes">The list of shapes to display.</param>
        void DrawFigures(IEnumerable<IDrawable> shapes);

        /// <summary>
        /// Displays the given message.
        /// </summary>
        /// <param name="message">The message to display.</param>
        void ShowMessage(string message);

        /// <summary>
        /// Displays an error to the user.
        /// </summary>
        /// <param name="message">The error to display.</param>
        void ShowError(string error);

        /// <summary>
        /// Displays an array of strings to the user.
        /// </summary>
        /// <param name="info"></param>
        void ShowInfo(string[] info);

        /// <summary>
        /// Gets a string input from the user.
        /// </summary>
        /// <returns>The user's input.</returns>
        string GetInputRequest();
    }
}
