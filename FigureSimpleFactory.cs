using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public static class FigureSimpleFactory
    {
        public static Figure GetFigure(FigureType figureType)
        {
            switch (figureType)
            {
                case FigureType.King:
                    return new King();
                case FigureType.Pawn:
                    return new Pawn();
                default:
                    throw new ArgumentException("Invalid figure type!");
            }
        }
        
    }
}
