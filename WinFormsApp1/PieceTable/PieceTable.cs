using WinFormsApp1.Constants;

namespace WinFormsApp1.PieceTable;

public class PieceTable : IPieceTable
{
    private List<Piece> pieces;
    private String originalBuffer; // the initial content
    private String addBuffer; //

    public PieceTable(List<Piece> pieces)
    {
        this.originalBuffer = "Hello World";
        this.addBuffer = "";
        this.pieces = new List<Piece> { new Piece(PieceType.ORIGINAL, 0, originalBuffer.Length) };
    }

    public void insert(int idx, string text)
    {
        this.addBuffer += text;
        int start = addBuffer.Length - text.Length; // starting index of new text
        pieces.Add(new Piece(PieceType.ADD_BUFFER, start, text.Length));
    }

    public void delete(int begin, int end)
    {
        throw new NotImplementedException();
    }

    public void replace(int begin, int end, string replacement)
    {
        throw new NotImplementedException();
    }

    public string RenderText()
    {
        string result = string.Empty;

        foreach (Piece piece in pieces)
        {
            if (piece.Source == PieceType.ORIGINAL)
            {
                result += originalBuffer.Substring(piece.Start, piece.Length);
            }
            else if (piece.Source == PieceType.ADD_BUFFER)
            {
                result += addBuffer.Substring(piece.Start, piece.Length);
            }
        }

        return result;
    }
}
