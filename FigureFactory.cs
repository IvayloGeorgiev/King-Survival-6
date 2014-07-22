namespace KingSurvivalGame
{
    public abstract class FigureFactory
    {
        public abstract Figure CreateFigure(int[] initialPosition, char symbol);
    }
}
