namespace Library.Esliph.Components;

public class Bounds
{
    public Position position { get; set; }
    public Dimension dimension { get; set; }
    public Position center => new(this.position.X + (this.dimension.Width / 2), this.position.Y + (this.dimension.Height / 2));
    public Position positionEnd => new(this.position.X + this.dimension.Width, this.position.Y + this.dimension.Height);

    public Bounds() { }
    public Bounds(Position position)
    {
        this.position = position;
        this.dimension = new();
    }
    public Bounds(Dimension dimension)
    {
        this.dimension = dimension;
        this.position = new();
    }
    public Bounds(Position position, Dimension dimension)
    {
        this.position = position;
        this.dimension = dimension;
    }
    public Bounds(int x, int y, int width, int height)
    {
        this.position = new(x, y);
        this.dimension = new(width, height);
    }

    public override string ToString()
    {
        return "{X = " + this.position.X
            + ", Y = " + this.position.Y
            + ", Width = " + this.dimension.Width
            + ", Height = " + this.dimension.Height
            + ", Center X = " + this.center.X
            + ", Center Y = " + this.center.Y
            + ", End X = " + this.positionEnd.X
            + ", End Y = " + this.positionEnd.Y
            + "}";
    }
}