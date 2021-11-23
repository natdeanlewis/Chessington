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
            
            if (Player == Player.White)
            {
                oneAhead = Square.At(row - 1, col);
                twoAhead = Square.At(row - 2, col);
                
            }
            else
            {
                oneAhead = Square.At(row + 1, col);
                twoAhead = Square.At(row + 2, col);
            }

            if (oneAhead.IsInBounds() && board.GetPiece(oneAhead) == null)
            {
                availableMoves.Add(oneAhead);
                
                if (!hasMoved && board.GetPiece(twoAhead) == null) availableMoves.Add(twoAhead);
            }

            
            return availableMoves;
        }
    }
}