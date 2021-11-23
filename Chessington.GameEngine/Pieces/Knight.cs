using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            var availableMoves = new List<Square>();
            var row = currentSquare.Row;
            var col = currentSquare.Col;

            // availableMoves.Add(Square.At(row + 1, col + 2));
            // availableMoves.Add(Square.At(row - 1, col + 2));
            // availableMoves.Add(Square.At(row + 1, col - 2));
            // availableMoves.Add(Square.At(row - 1, col - 2));
            // availableMoves.Add(Square.At(row + 2, col + 1));
            // availableMoves.Add(Square.At(row - 2, col + 1));
            // availableMoves.Add(Square.At(row + 2, col - 1));
            // availableMoves.Add(Square.At(row - 2, col - 1));

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        var sq = Square.At(row + (2 * j - 1) * (2 - i), col + (2 * k - 1) * (i + 1));
                        if (sq.IsInBounds()) availableMoves.Add(sq);
                    }
                }
            }

            return availableMoves;
        }
    }
}