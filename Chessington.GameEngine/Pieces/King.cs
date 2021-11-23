using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            var availableMoves = new List<Square>();
            var row = currentSquare.Row;
            var col = currentSquare.Col;
            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    
                    if(Square.At(row + i, col + j).IsInBounds())
                    {
                        availableMoves.Add(Square.At(row + i, col + j));
                    }
                }
            }
            
            

            availableMoves.RemoveAll(s => s == Square.At(row, col));
            return availableMoves;        
        }
    }
}