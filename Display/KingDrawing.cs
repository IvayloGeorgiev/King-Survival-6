namespace KingSurvivalGame.Display
{
    using System;
    using System.Collections.Generic;
    using KingSurvivalGame.Interfaces;
    using KingSurvivalGame.Figures;

    public class KingDrawing : Drawing, IDrawable
    {
        /// <summary>
        /// Represents the nominal shape of the king figure, without its identifying symbol.
        /// </summary>
        private static readonly string[] generalShape = new string[] { "\u2588 \u2588\u2588 \u2588", " \u2588\u2588\u2588\u2588 ", " \u2588\u2588\u2588\u2588 ", "\u2588\u2588\u2588\u2588\u2588\u2588"};

        public KingDrawing(Figure figure)
            : base(figure)
        {
            this.Shape = GetShapeWithSymbol();
        }

        /// <summary>
        /// Adds the symbol used for identification to the bottom of the figure.
        /// </summary>
        /// <returns>The figure shape as a string array with the last line being the symbol identifier.</returns>
        private string[] GetShapeWithSymbol()
        {
            List<string> shapeWithSymbol = new List<string>(generalShape);
            shapeWithSymbol.Add(this.Symbol.ToString());
            return shapeWithSymbol.ToArray();
        }
    }
}
