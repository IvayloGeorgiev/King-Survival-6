namespace KingSurvivalGame.Display
{    
    /// <summary>
    /// Implemented by objects that have to be displayed with shape displays.
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// The position (as x and y coordinates) of the object to be displayed.
        /// </summary>
        Position Position { get; }

        /// <summary>
        /// The character of the shape to serve as identifier.
        /// </summary>
        char Symbol { get; }

        /// <summary>
        /// The shape of the object to the be displayed as an array of strings.
        /// </summary>
        string[] Shape { get; }
    }
}
