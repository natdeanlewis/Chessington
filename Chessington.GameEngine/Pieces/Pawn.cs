using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {

        public Pawn(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            var availableMoves = new List<Square>();
            var row = currentSquare.Row;
            var col = currentSquare.Col;
            if (Player == Player.White)
            {
                availableMoves.Add(Square.At(row - 1, col));
                if (!hasMoved) availableMoves.Add(Square.At(row - 2, col));
            }
            else
            {
                availableMoves.Add(Square.At(row + 1, col));
                if (!hasMoved) availableMoves.Add(Square.At(row + 2, col));
            }

            return availableMoves;
        }
    }
}