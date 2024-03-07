namespace Library.Esliph.Components;

public class Dimension
{
    public int Width, Height;

    public Dimension() { }
    public Dimension(float value) : this((int)value, (int)value) { }
    public Dimension(float width, float height) : this((int)width, (int)height) { }
    public Dimension(int value) : this(value, value) { }
    public Dimension(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }
}