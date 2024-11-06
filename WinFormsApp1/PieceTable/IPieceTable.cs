namespace WinFormsApp1.PieceTable;

public interface IPieceTable
{
    /// <summary>
    /// Inserts text at the index idx, such that the first character of text begins at idx.
    /// </summary>
    /// <param name="idx"></param>
    /// <param name="text"></param>
    void insert(int idx, string text);

    /// <summary>
    /// Deletes the substring from begin to end (excluded). [begin, end).
    /// </summary>
    /// <param name="begin"></param>
    /// <param name="end"></param>
    void delete(int begin, int end);

    /// <summary>
    /// Replaces the substring [begin, end) with replacement string. The replacement string can be of any length.
    /// </summary>
    /// <param name="begin"></param>
    /// <param name="end"></param>
    /// <param name="replacement"></param>
    void replace(int begin, int end, string replacement);

    /// <summary>
    /// Renders the text given the piece list
    /// </summary>
    string RenderText();
}
