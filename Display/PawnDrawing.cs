namespace KingSurvivalGame.Display
{    
    using System.Collections.Generic;
    using KingSurvivalGame.Figures;
    using KingSurvivalGame.Interfaces;

    /// <summary>
    /// Creates a shape for the pawn type figures at the same position as the position of the figure.
    /// </summary>
    public class PawnDrawing : Drawing, IDrawable
    {
        /// <summary>
        /// Represents the nominal shape of the pawn figure, without its identifying symbol.
        /// </summary>
        private static readonly string[] GeneralShape = new string[] { "  \u25E2\u25E3  ", " \u25E2\u2588\u2588\u25E3 ", " \u25E2\u2588\u2588\u25E3 ", " \u2588\u2588\u2588\u2588 " };        

        public PawnDrawing(Figure figure)
            : base(figure)
        {
            this.Shape = this.GetShapeWithSymbol();
        }

        /// <summary>
        /// Adds the symbol used for identification to the bottom of the figure.
        /// </summary>
        /// <returns>The figure shape as a string array with the last line being the symbol identifier.</returns>
        private string[] GetShapeWithSymbol()
        {
            List<string> shapeWithSymbol = new List<string>(GeneralShape);
            shapeWithSymbol.Add(this.Symbol.ToString());
            return shapeWithSymbol.ToArray();
        }       
    }
}
