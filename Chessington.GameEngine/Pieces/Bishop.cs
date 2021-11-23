using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32.SafeHandles;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
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
            {
                if (Square.At(row + i, col + i).IsInBounds() && board.GetPiece(Square.At(row + i, col + i)) == null)
                {
                    availableMoves.Add(Square.At(row + i, col + i));
                }
                else break;
            }
            
            for (var i = 1; i <= 7; i++)
            {
                if (Square.At(row + i, col - i).IsInBounds() && board.GetPiece(Square.At(row + i, col - i)) == null)
                {
                    availableMoves.Add(Square.At(row + i, col - i));
                }
                else break;
            }
            
            for (var i = 1; i <= 7; i++)
            {
                if (Square.At(row - i, col + i).IsInBounds() && board.GetPiece(Square.At(row - i, col + i)) == null)
                {
                    availableMoves.Add(Square.At(row - i, col + i));
                }
                else break;
            }
            
            for (var i = 1; i <= 7; i++)
            {
                if (Square.At(row - i, col - i).IsInBounds() && board.GetPiece(Square.At(row - i, col - i)) == null)
                {
                    availableMoves.Add(Square.At(row - i, col - i));
                }
                else break;
            }

            return availableMoves;        
        }
    }
}