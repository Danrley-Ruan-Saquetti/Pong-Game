using Microsoft.Xna.Framework;
using Library.Esliph.Shapes;
using Library.Esliph.Common;

namespace Library.Esliph.Components.GameObjects;

public class FontGameObject : GameObject
{
    public FontGameObject(string contentName, Vector2 position, Color color = new()) : base()
    {
        this.AddComponents(
            new FontShape(contentName, position, color)
        );

        this.AddTags("_FontShape");
    }

    public FontShape GetFontShape()
    {
        return this.GetShape2D<FontShape>();
    }
}