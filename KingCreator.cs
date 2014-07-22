namespace KingSurvivalGame
{
    public class KingCreator : FigureFactory
    {
        public override Figure CreateFigure(int[] initialPosition, char symbol)
        {
            var king = new King(initialPosition, symbol)
            {
                ValidSubCommands = new string[] { symbol + "UL", symbol + "UR", symbol + "DL", symbol + "DR" },
                Shape = new string[] { "\u2588 \u2588\u2588 \u2588", " \u2588\u2588\u2588\u2588 ", " \u2588\u2588\u2588\u2588 ", "\u2588\u2588\u2588\u2588\u2588\u2588", symbol.ToString()}
            };

            return king;
        }
    }
}
