using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public static class FigureSimpleFactory
    {
        public static Figure GetFigure(FigureType figureType, int[] initialPosition, char symbol)
        {
            switch (figureType)
            {
                case FigureType.King:
                    return new King(initialPosition, symbol);
                case FigureType.Pawn:
                    return new Pawn(initialPosition, symbol);
                default:
                    throw new ArgumentException("Invalid figure type!");
            }
        }
        
    }
}
