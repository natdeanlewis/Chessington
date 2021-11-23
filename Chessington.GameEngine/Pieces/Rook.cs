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

            Square square;
            Piece piece;

            for (var i = 1; i <= 7; i++)
            {
                square = Square.At(row, col + i);
                if (!square.IsInBounds())
                    break;
                piece = board.GetPiece(square);
                if (piece == null)
                    availableMoves.Add(square);
                else if (piece.IsOpponents(Player))
                {
                    availableMoves.Add(square);
                    break;
                }
                else break;
            }
            
            for (var i = 1; i <= 7; i++)
            {
                square = Square.At(row, col - i);
                if (!square.IsInBounds())
                    break;
                piece = board.GetPiece(square);
                if (piece == null)
                    availableMoves.Add(square);
                else if (piece.IsOpponents(Player))
                {
                    availableMoves.Add(square);
                    break;
                }
                else break;
                
            }for (var i = 1; i <= 7; i++)
            {
                square = Square.At(row + i, col);
                if (!square.IsInBounds())
                    break;
                piece = board.GetPiece(square);
                if (piece == null)
                    availableMoves.Add(square);
                else if (piece.IsOpponents(Player))
                {
                    availableMoves.Add(square);
                    break;
                }
                else break;
                
            }
            for (var i = 1; i <= 7; i++)
            {
                square = Square.At(row - i, col);
                if (!square.IsInBounds())
                    break;
                piece = board.GetPiece(square);
                if (piece == null)
                    availableMoves.Add(square);
                else if (piece.IsOpponents(Player))
                {
                    availableMoves.Add(square);
                    break;
                }
                else break;
            }
            


            // availableMoves.RemoveAll(s => s == Square.At(row, col));
            return availableMoves;
        }
    }
}