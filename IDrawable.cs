namespace KingSurvivalGame
{
    public interface IDrawable
    {
        int[] Position { get; }

        char Symbol { get; }

        string[] Shape { get; }
    }
}
