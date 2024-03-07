using Microsoft.Xna.Framework.Graphics;

namespace Library.Esliph.Sprites;

public class Sprite
{
    public Texture2D texture2D;

    public Sprite() : this(new(null, 0, 0)) { }
    public Sprite(Texture2D texture2D)
    {
        this.texture2D = texture2D;
    }
}