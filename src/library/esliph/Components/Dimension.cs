namespace Library.Esliph.Components;

public class Dimension
{
    public float Width, Height;

    public Dimension(float value = 0) : this(value, value) { }
    public Dimension(float width, float height)
    {
        this.Width = width;
        this.Height = height;
    }
}