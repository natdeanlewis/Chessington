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
            

            Square square;
            Piece piece;

            for (var i = 1; i <= 7; i++)
            {
                square = Square.At(row + i, col + i);
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
                square = Square.At(row + i, col - i);
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
                square = Square.At(row - i, col + i);
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
                square = Square.At(row - i, col - i);
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

            return availableMoves;        
        }
    }
}