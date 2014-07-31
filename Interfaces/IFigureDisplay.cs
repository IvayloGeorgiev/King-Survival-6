namespace KingSurvivalGame.Interfaces
{    
    using System.Collections.Generic;
    using KingSurvivalGame.Figures;

    /// <summary>
    /// Used by the game engine to display information to the user.
    /// </summary>
    public interface IFigureDisplay
    {
        /// <summary>
        /// When invoked, displays the list of figures in their respective positions.
        /// </summary>
        /// <param name="figures">The figures to be displayed.</param>
        void DrawFigures(IEnumerable<Figure> figures);

        /// <summary>
        /// Displays a message to the user.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void ShowMessage(string message);

        /// <summary>
        /// Displays an error to the user.
        /// </summary>
        /// <param name="error">the error to be dispalyed</param>
        void ShowError(string error);

        /// <summary>
        /// Displays an array of strings as an information. Could be used to list the users commands.
        /// </summary>
        /// <param name="info">The different strings to be displayed.</param>
        void ShowInfo(string[] info);

        /// <summary>
        /// Gets a string input from the user and passes it back.
        /// </summary>
        /// <returns>The user's input as a string.</returns>
        string GetInputRequest();
    }
}
