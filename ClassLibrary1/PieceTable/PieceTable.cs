using ClassLibrary1.Constants;

namespace ClassLibrary1.PieceTable;

public class PieceTable : IPieceTable
{
    private List<Piece> _pieces; //
    private readonly String _originalBuffer; // the initial content
    private String _addBuffer; //

    public PieceTable(String originalBuffer)
    {
        this._originalBuffer = originalBuffer;
        this._addBuffer = "";
        this._pieces = new List<Piece> { new Piece(PieceType.ORIGINAL, 0, originalBuffer.Length) };
    }

    public void Insert(int idx, string text)
    {
        this._addBuffer += text;
        int start = _addBuffer.Length - text.Length; // starting index of new text
        _pieces.Add(new Piece(PieceType.ADD_BUFFER, start, text.Length));
    }

    public void Delete(int begin, int length) // deletes [begin, end]
    {
        if (length == 0)
        {
            return;
        }

        int end = begin + length;

        for (int i = 0; i < _pieces.Count; i++)
        {
            Piece piece = _pieces[i];
            int pieceEnd = piece.Start + piece.Length;

            // check if piece is in range
            if (piece.Start <= end || pieceEnd >= begin) // checks if the given deletion bounds are within the piece's bounds
            {
                // delete is in one piece or spanning multiple pieces
                // change given parameters into the range to delete according to this specific piece
                int deleteStart = Math.Max(begin, piece.Start); // deleteStart is bounded by pieceStart on the left
                int deleteEnd = Math.Min(end, pieceEnd); // deleteEnd is bounded by pieceEnd on the right

                if (piece.Start == deleteStart && pieceEnd == deleteEnd) // Deletion range spans the entire piece
                {
                    _pieces.Remove(piece);
                }
                else if (piece.Start == deleteStart) // Delete from left
                {
                    int num = deleteEnd - deleteStart;
                    piece.Start += num;
                    piece.Length -= num;
                }
                else if (pieceEnd == deleteEnd) // Delete from right
                {
                    int num = deleteEnd - deleteStart;
                    piece.Length -= num;
                }
                else // Splits into two pieces
                {
                    // change current piece to left_piece, length = begin - piece.Start
                    piece.Length = begin - piece.Start;

                    // add right_piece with length pieceEnd - deleteEnd
                    Piece rightPiece = new Piece(piece.Source, end, pieceEnd - deleteEnd);
                    _pieces.Add(rightPiece);
                }
            }
        }
    }

    public void Replace(int begin, int length, string replacement)
    {
        Delete(begin, length);
        Insert(begin, replacement);
    }

    public string RenderText()
    {
        string result = string.Empty;

        foreach (Piece piece in _pieces)
        {
            if (piece.Source == PieceType.ORIGINAL)
            {
                result += _originalBuffer.Substring(piece.Start, piece.Length);
            }
            else if (piece.Source == PieceType.ADD_BUFFER)
            {
                result += _addBuffer.Substring(piece.Start, piece.Length);
            }
        }

        return result;
    }

    // Only for debugging purposes
    public override string ToString()
    {
        string pieces = "";

        foreach (Piece piece in _pieces)
        {
            pieces += piece.ToString();
            pieces += "\n";
        }

        return pieces;
    }
}
