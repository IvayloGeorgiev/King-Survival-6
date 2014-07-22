namespace KingSurvivalGame
{
    public interface IDrawable
    {
        int[] Position { get; set; }

        char Symbol { get; set; }

        string[] Shape { get; set; }
    }
}
