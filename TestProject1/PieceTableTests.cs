namespace TestProject1;

using ClassLibrary1.PieceTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PieceTableTests
{
    [SetUp]
    public void Setup() { }

    [TestMethod]
    public void TestSingleInsertion()
    {
        String originalBuffer = "Hello World";
        PieceTable pieceTable = new PieceTable(originalBuffer);

        String textToInsert = " I am a new piece of text";
        pieceTable.Insert(originalBuffer.Length, textToInsert);

        String actual = pieceTable.RenderText();
        String expected = originalBuffer + textToInsert;

        Assert.AreEqual(actual, expected, "The inserted text is not being updated properly.");
    }

    [TestMethod]
    public void TestInsertionBetweenPieces()
    {
        String originalBuffer = "Hello World";
        PieceTable pieceTable = new PieceTable(originalBuffer);

        String firstTextToInsert = "Cats";
        pieceTable.Insert(originalBuffer.Length, firstTextToInsert);

        String secondTextToInsert = "Dogs";
        pieceTable.Insert(originalBuffer.Length, secondTextToInsert);

        String actual = pieceTable.RenderText();
        String expected = originalBuffer + secondTextToInsert + firstTextToInsert;

        Assert.AreEqual(
            actual,
            expected,
            "The text is not being inserted properly between two pieces."
        );
    }

    [TestMethod]
    public void TestInsertionInsideAPiece()
    {
        String originalBuffer = "Hello World";
        PieceTable pieceTable = new PieceTable(originalBuffer);

        String textToInsert = "Developing";
        pieceTable.Insert(5, textToInsert);

        String actual = pieceTable.RenderText();
        String expected = "HelloDevelopingWorld";

        Assert.AreEqual(
            actual,
            expected,
            "The text is not being inserted properly inside a piece."
        );
    }

    [TestMethod]
    public void TestDeleteFromEmptyBuffer()
    {
        String originalBuffer = "";
        PieceTable pieceTable = new PieceTable(originalBuffer);

        pieceTable.Delete(0, 1);

        String actual = pieceTable.RenderText();
        String expected = "";

        Assert.AreEqual(
            actual,
            expected,
            "The deletion of an empty buffer is not being handled properly"
        );
    }

    [TestMethod]
    public void TestDeleteFromOutOfRange()
    {
        String originalBuffer = "Hello World!";
        PieceTable pieceTable = new PieceTable(originalBuffer);

        pieceTable.Delete(-1, 1);

        String actual = pieceTable.RenderText();
        String expected = "Hello World!";

        Assert.AreEqual(
            actual,
            expected,
            "The deletion of a given out-of-bounds index is not being handled properly"
        );
    }

    [TestMethod]
    public void TestDeleteFromLeftSide()
    {
        String originalBuffer = "Hello World!";
        PieceTable pieceTable = new PieceTable(originalBuffer);

        pieceTable.Delete(-4, 10); // left side is out of bounds

        String actual = pieceTable.RenderText();
        String expected = "World!";

        Assert.AreEqual(
            actual,
            expected,
            "The deletion of the left-hand side of a piece is not being handled properly"
        );
    }

    [TestMethod]
    public void TestDeleteFromRightSide()
    {
        String originalBuffer = "Hello World!";
        PieceTable pieceTable = new PieceTable(originalBuffer);

        pieceTable.Delete(5, 10); // right side is out of bounds

        String actual = pieceTable.RenderText();
        String expected = "Hello";

        Assert.AreEqual(
            actual,
            expected,
            "The deletion of the right-hand side of a piece is not being handled properly"
        );
    }

    [TestMethod]
    public void TestDeleteWholePiece()
    {
        String originalBuffer = "Hello World!";
        PieceTable pieceTable = new PieceTable(originalBuffer);

        pieceTable.Delete(0, originalBuffer.Length);

        String actual = pieceTable.RenderText();
        String expected = "";

        Assert.AreEqual(
            actual,
            expected,
            "The deletion of an entire piece is not being handled properly"
        );
    }

    [TestMethod]
    public void TestDeleteInsideAPiece()
    {
        String originalBuffer = "Hello World!";
        PieceTable pieceTable = new PieceTable(originalBuffer);

        pieceTable.Delete(5, 6);

        String actual = pieceTable.RenderText();
        String expected = "Hello!";

        Assert.AreEqual(
            actual,
            expected,
            "The deletion of a segment within a piece is not being handled properly"
        );
    }
}
