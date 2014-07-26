using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    class PawnDrawing : Drawing, IDrawable
    {
        private static readonly string[] generalShape = new string[] { "  \u25E2\u25E3  ", " \u25E2\u2588\u2588\u25E3 ", " \u25E2\u2588\u2588\u25E3 ", " \u2588\u2588\u2588\u2588 "};        

        public PawnDrawing(Figure figure)
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
