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

            Square oneAhead;
            Square twoAhead;
            Square leftDiagonal;
            Square rightDiagonal;
            
            if (Player == Player.White)
            {
                oneAhead = Square.At(row - 1, col);
                twoAhead = Square.At(row - 2, col);
                leftDiagonal = Square.At(row - 1, col - 1);
                rightDiagonal = Square.At(row - 1, col + 1);

            }
            else
            {
                oneAhead = Square.At(row + 1, col);
                twoAhead = Square.At(row + 2, col);
                leftDiagonal = Square.At(row + 1, col - 1);
                rightDiagonal = Square.At(row + 1, col + 1);
            }

            if (oneAhead.IsInBounds() && board.GetPiece(oneAhead) == null)
            {
                availableMoves.Add(oneAhead);

                if (!hasMoved && board.GetPiece(twoAhead) == null) availableMoves.Add(twoAhead);
            }

            if (leftDiagonal.IsInBounds() && board.GetPiece(leftDiagonal) != null &&
                board.GetPiece(leftDiagonal).IsOpponents(Player))
            {
                availableMoves.Add(leftDiagonal);
            }
            if (rightDiagonal.IsInBounds() && board.GetPiece(rightDiagonal) != null &&
                board.GetPiece(rightDiagonal).IsOpponents(Player))
            {
                availableMoves.Add(rightDiagonal);
            }
            
            

            
            return availableMoves;
        }
    }
}