using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            var availableMoves = new List<Square>();
            var row = currentSquare.Row;
            var col = currentSquare.Col;
            
            var range = 1;
            var directions = new List<Tuple<int, int>>();

            directions.Add(new Tuple<int, int>(1, 0));
            directions.Add(new Tuple<int, int>(0, 1));
            directions.Add(new Tuple<int, int>(-1, 0));
            directions.Add(new Tuple<int, int>(0, -1));
            directions.Add(new Tuple<int, int>(1, 1));
            directions.Add(new Tuple<int, int>(1, -1));
            directions.Add(new Tuple<int, int>(-1, 1));
            directions.Add(new Tuple<int, int>(-1, -1));

            foreach (var direction in directions)
                availableMoves = iterativeMoveCheck(row, col, availableMoves, board, direction, range);

            return availableMoves;
        }
    }
}