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
        protected static readonly Position DownLeftOffset = new Position(-1, 1);
        protected static readonly Position DownRightOffset = new Position(1, 1);
        protected static readonly Position UpLeftOffset = new Position(-1, -1);
        protected static readonly Position UpRightOffset = new Position(1, -1);

        public abstract Figure CreateFigure(Position initialPosition, char symbol);
    }
}
