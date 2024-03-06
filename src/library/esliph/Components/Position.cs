namespace Library.Esliph.Components;

public class Position
{
    public int X, Y;

    public Position() { }
    public Position(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
    public Position(int value)
    {
        this.X = value;
        this.Y = value;
    }

    public override string ToString()
    {
        return "{X: " + this.X + ", Y: " + this.Y + "}";
    }
}