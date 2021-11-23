using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            var availableMoves = new List<Square>();
            var row = currentSquare.Row;
            var col = currentSquare.Col;
            
            for (var i = 0; i < 8; i++)
            {
                availableMoves.Add(Square.At(row, i));
                availableMoves.Add(Square.At(i, col));
                int y1 = col - row + i;
                if (0 <= y1 && y1 <= 7)
                {
                    availableMoves.Add(Square.At(i, y1));

                }
                int y2 = 8 - i + row - col;
                if (0 <= y2 && y2 <= 7)
                {
                    availableMoves.Add(Square.At(i, y2));
                }

            }
            
            availableMoves.RemoveAll(s => s == Square.At(row, col));
            return availableMoves;
        }
    }
}