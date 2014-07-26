namespace KingSurvivalGame.Interfaces
{
    public interface IDrawable
    {
        int[] Position { get; }

        char Symbol { get; }

        string[] Shape { get; }
    }
}
