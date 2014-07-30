namespace KingSurvivalGame.Interfaces
{    
    public interface IDrawable
    {
        Position Position { get; }

        char Symbol { get; }

        string[] Shape { get; }
    }
}
