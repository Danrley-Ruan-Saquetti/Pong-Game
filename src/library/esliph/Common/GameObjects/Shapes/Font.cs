using Microsoft.Xna.Framework;
using Library.Esliph.Shapes;
using Library.Esliph.Common;

namespace Library.Esliph.Components.GameObjects;

public class FontGameObject : GameObject
{
    private FontShape shape;

    public FontGameObject(string contentName, Vector2 position, Color color = new()) : base()
    {
        this.shape = new(contentName, position, color);

        this.AddComponents(
            this.shape
        );

        this.AddTags("_FontShape");
    }

    public FontShape GetFontShape()
    {
        return this.shape;
    }
}