namespace ClassLibrary1.PieceTable;

public interface IPieceTable
{
    /// <summary>
    /// Inserts text at the index idx, such that the first character of text begins at idx.
    /// </summary>
    /// <param name="idx"></param>
    /// <param name="text"></param>
    void Insert(int idx, string text);

    /// <summary>
    /// Deletes the substring from begin up to the given length to delete.
    /// </summary>
    /// <param name="begin"></param>
    /// <param name="length"></param>
    void Delete(int begin, int length);

    /// <summary>
    /// Replaces the substring from begin up to the given length with replacement string. The replacement string can be of any length.
    /// </summary>
    /// <param name="begin"></param>
    /// <param name="end"></param>
    /// <param name="length"></param>
    void Replace(int begin, int length, string replacement);

    /// <summary>
    /// Renders the text given the piece list
    /// </summary>
    string RenderText();
}
