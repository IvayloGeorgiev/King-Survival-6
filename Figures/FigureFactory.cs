namespace KingSurvivalGame.Figures
{
    public abstract class FigureFactory
    {
        /// <summary>
        /// Constants relating to figure movement string commands.
        /// </summary>
        protected const string DownLeftCommand = "DL";
        protected const string DownRightCommand = "DR";
        protected const string UpLeftCommand = "UL";
        protected const string UpRightCommand = "UR";

        /// <summary>
        /// Constants relating to figure movement offset.
        /// </summary>
        protected static readonly int[] DownLeftOffset = new int[] { -1, 1 };
        protected static readonly int[] DownRightOffset = new int[] { 1, 1 };
        protected static readonly int[] UpLeftOffset = new int[] { -1, -1 };
        protected static readonly int[] UpRightOffset = new int[] { 1, -1 };

        public abstract Figure CreateFigure(int[] initialPosition, char symbol);
    }
}
