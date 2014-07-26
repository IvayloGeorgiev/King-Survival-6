namespace KingSurvivalGame
{
    using System;
    using System.Collections.Generic;

    public class KingDrawing : Drawing, IDrawable
    {
        private static readonly string[] generalShape = new string[] { "\u2588 \u2588\u2588 \u2588", " \u2588\u2588\u2588\u2588 ", " \u2588\u2588\u2588\u2588 ", "\u2588\u2588\u2588\u2588\u2588\u2588"};

        public KingDrawing(Figure figure)
            : base(figure)
        {
            this.Shape = GetShapeWithSymbol();
        }

        private string[] GetShapeWithSymbol()
        {
            List<string> shapeWithSymbol = new List<string>(generalShape);
            shapeWithSymbol.Add(this.Symbol.ToString());
            return shapeWithSymbol.ToArray();
        }
    }
}
