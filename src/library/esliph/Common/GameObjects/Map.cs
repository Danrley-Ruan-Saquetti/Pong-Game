using Library.Esliph.Utils;
using Microsoft.Xna.Framework;

namespace Library.Esliph.Components.GameObjects;

public class MapGameObject : RectangleGameObject
{
    public MapGameObject(Dimension dimension, Color color) : base(new(0, 0), dimension, 0, null, color)
    {
        this.AddTags("_MAP");
    }
}