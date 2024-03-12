using Library.Esliph.Sprites;

namespace Library.Esliph.Components;

public class Collider
{
    private readonly Sprite sprite1, sprite2;

    public Collider(Sprite sprite1, Sprite sprite2)
    {
        this.sprite1 = sprite1;
        this.sprite2 = sprite2;
    }
}