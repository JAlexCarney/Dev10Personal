namespace StatefulUnitTestExercises.Chess
{
    /// <summary>
    /// The most powerful chess piece.
    /// Moves horizontally, vertically, or diagonally as many spaces as she wants.
    /// She tracks her current position with two integer fields: row and column.
    /// Rows and columns are zero-based.
    /// The queen starts at row 0 and column 0, though there is no board.
    /// Row 7 - - - - - - - -
    /// Row 6 - - - - - - - -
    /// Row 5 - - - - - - - -
    /// Row 4 - - - - - - - -
    /// Row 3 - - - - - - - -
    /// Row 2 - - - - - - - -
    /// Row 1 - - - - - - - -
    /// Row 0 Q - - - - - - -
    /// Cols: 0 1 2 3 4 5 6 7
    /// 
    /// See: https://en.wikipedia.org/wiki/Queen_(chess)
    /// </summary>
    public class Queen
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        /// <summary>
        /// Requests a move to a new row and column.
        /// </summary>
        /// <param name="row">the requested row</param>
        /// <param name="column">the requested column</param>
        /// <returns>true if the move is valid, false if it's not</returns>       
        public bool Move(int row, int column)
        {
            // 1. Implement the Move method.
            // If the Move is valid, return true and update `Row` and `Column` properties.
            // If the ove is invalid, return false and do not update fields.
            // Rules for valid moves:
            // - row and column can never be less than 0 or greater than 7 (8 rows and columns on a chess board).
            // - can't equal the existing row and column (same location)
            // - If the row parameter and field are the same but the column is not, the queen is moving horizontally. That's valid.
            // - If the column parameter and field are the same but the row is not, the queen is moving vertically. That's valid.
            // - Otherwise, the absolute difference between row parameter and field
            //   and the absolute difference between the column parameter and field must be the same.
            //   That represents a diagonal move.
            return false;
        }
    }
}
