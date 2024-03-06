namespace Library.Esliph.Components;

public class Dimension
{
    public int Width, Height;

    public Dimension() { }
    public Dimension(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }
    public Dimension(int value)
    {
        this.Width = value;
        this.Height = value;
    }
}