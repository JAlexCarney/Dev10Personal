using NUnit.Framework;
using StatefulUnitTestExercises.Chess;

namespace StatefulUnitTestExercises.Tests.Chess
{
    public class QueenTest
    {
        Queen queen = new Queen();

        [Test]
        public void ShouldMoveToFourCorners()
        {
            Assert.IsTrue(queen.Move(7, 0)); // top left;
            Assert.AreEqual(7, queen.Row);
            Assert.AreEqual(0, queen.Column);

            Assert.IsTrue(queen.Move(7, 7)); // top right;
            Assert.AreEqual(7, queen.Row);
            Assert.AreEqual(7, queen.Column);

            Assert.IsTrue(queen.Move(0, 7)); // bottom right;
            Assert.AreEqual(0, queen.Row);
            Assert.AreEqual(7, queen.Column);

            Assert.IsTrue(queen.Move(0, 0)); // bottom left;
            Assert.AreEqual(0, queen.Row);
            Assert.AreEqual(0, queen.Column);
        }

        // 1. Add tests to validate Queen movement.
        // Required tests:
        // - anything off the board is invalid, should return false and leave field values alone.
        // - requesting the existing location should return false and leave field values alone.
        // - should still be able to move after an invalid move.
        // - can move diagonally in various ways
        // Always confirm that fields have been properly updated using properties.
    }
}