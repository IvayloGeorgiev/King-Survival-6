namespace KingSurvivalGame.Figures
{
    /// <summary>
    /// Allows an object to change its position on the game field.
    /// </summary>
    public interface IMovable
    {        
        /// <summary>
        /// When invoked, moves the current object by adding its natural position to the offset.
        /// </summary>
        /// <param name="offset">The change in position.</param>
        void Move(Position offset);
    }
}
