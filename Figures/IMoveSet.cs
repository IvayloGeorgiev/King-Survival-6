namespace KingSurvivalGame.Figures
{
    using System.Collections.Generic;

    /// <summary>
    /// Should be implemented for objects or figures that can store a collections of commands with possitional offset.
    /// </summary>
    public interface IMoveSet
    {
        /// <summary>
        /// A dictionary object holding the selection of possible moves and their positional offset.
        /// </summary>
        Dictionary<string, Position> MovementCommands
        {
            get;
            set;
        }

        /// <summary>
        /// Checks if a given command exists in the dictionary.
        /// </summary>
        /// <param name="command">The command to check.</param>
        /// <returns>True if it exists, false otherwise.</returns>
        bool CheckCommand(string command);
    }
}
