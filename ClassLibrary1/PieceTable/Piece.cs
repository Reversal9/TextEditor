using ClassLibrary1.Constants;

namespace ClassLibrary1.PieceTable;

public class Piece
{
    private PieceType source; // the source of the piece
    private int start; // starting position of the piece within the source
    private int length; // the number of characters in the piece

    public PieceType Source
    {
        get => source;
        set => source = value;
    }

    public int Start
    {
        get => start;
        set => start = value;
    }

    public int Length
    {
        get => length;
        set => length = value;
    }

    public Piece(PieceType source, int start, int length)
    {
        this.source = source;
        this.start = start;
        this.length = length;
    }

    public override string ToString()
    {
        return String.Format($"[Piece({source}, {start}, {length})]");
    }
}
