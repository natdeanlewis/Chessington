using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
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
            }

            availableMoves.Remove(Square.At(row, col));
            return availableMoves;
        }
    }
}