using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Library.Esliph.Sprites;

public class Pixel
{
    public static Texture2D Texture;

    public virtual void LoadContent(GraphicsDevice graphicsDevice)
    {
        Pixel.Texture = new Texture2D(graphicsDevice, 1, 1);
        Pixel.Texture.SetData(new[] { Color.White });
    }

    public Texture2D GetTexture2D()
    {
        return Pixel.Texture;
    }
}