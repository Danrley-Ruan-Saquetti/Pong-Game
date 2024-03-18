using Library.Esliph.Common;
using Library.Esliph.Shapes;
using Library.Esliph.Utils;
using Microsoft.Xna.Framework;

namespace Library.Esliph.Components.GameObjects;

public class MapGameObject : GameObject
{
    public MapGameObject(Dimension dimension, Color color)
    {
        this.AddComponents(
            new RectangleShape2D(new(0, 0), dimension, 0, null, color)
        );
        this.AddTags("_MAP");
    }
}