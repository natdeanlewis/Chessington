using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        public bool hasMoved = false;

        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        public bool IsOpponents(Player player)
        {
            return Player != player;
        }

        public List<Square> iterativeMoveCheck(int row, int col, List<Square> availableMoves, Board board,
            Tuple<int, int> direction, int range)
        {
            var isDone = false;
            Square square;
            for (var i = 1; i <= range; i++)
                if (!isDone)
                {
                    square = Square.At(row + direction.Item1 * i, col + direction.Item2 * i);
                    if (!square.IsInBounds())
                    {
                        isDone = true;
                    }
                    else
                    {
                        var piece = board.GetPiece(square);
                        if (piece == null)
                        {
                            availableMoves.Add(square);
                        }
                        else if (piece.IsOpponents(Player))
                        {
                            availableMoves.Add(square);
                            isDone = true;
                        }
                        else
                        {
                            isDone = true;
                        }
                    }
                }

            return availableMoves;
        }
    }
}