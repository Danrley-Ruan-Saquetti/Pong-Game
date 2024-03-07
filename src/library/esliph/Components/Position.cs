namespace Library.Esliph.Components;

public class Position
{
    public int X, Y;

    public Position() { }
    public Position(int value) : this(value, value) { }
    public Position(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public override string ToString()
    {
        return "{X: " + this.X + ", Y: " + this.Y + "}";
    }
}