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

            for (var i = 1; i <= 7; i++)
                if (col + i <= 7 && board.GetPiece(Square.At(row, col + i)) == null)
                    availableMoves.Add(Square.At(row, col + i));
                else break;

            for (var i = 1; i <= 7; i++)
                if (col - i >= 0 && board.GetPiece(Square.At(row, col - i)) == null)
                    availableMoves.Add(Square.At(row, col - i));
                else break;

            for (var i = 1; i <= 7; i++)
                if (row + i <= 7 && board.GetPiece(Square.At(row + i, col)) == null)
                    availableMoves.Add(Square.At(row + i, col));
                else break;
            
            for (var i = 1; i <= 7; i++)
                if (row - i >= 0 && board.GetPiece(Square.At(row - i, col)) == null)
                    availableMoves.Add(Square.At(row - i, col));
                else break;


            // availableMoves.RemoveAll(s => s == Square.At(row, col));
            return availableMoves;
        }
    }
}

