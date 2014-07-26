namespace KingSurvivalGame
{
    public abstract class FigureFactory
    {
        protected const string DownLeftCommand = "DL";
        protected const string DownRightCommand = "DR";
        protected const string UpLeftCommand = "UL";
        protected const string UpRightCommand = "UR";

        protected static readonly int[] DownLeftOffset = new int[] { -1, 1 };
        protected static readonly int[] DownRightOffset = new int[] { 1, 1 };
        protected static readonly int[] UpLeftOffset = new int[] { -1, -1 };
        protected static readonly int[] UpRightOffset = new int[] { 1, -1 };

        public abstract Figure CreateFigure(int[] initialPosition, char symbol);
    }
}
