using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Utils;
using Library.Esliph.Shapes;
using Library.Esliph.Common;

namespace Library.Esliph.Components.GameObjects;

public class RectangleGameObject : GameObject
{
    private RectangleShape2D shape2D;

    public RectangleGameObject(Vector2 position = new(), Dimension dimension = default, float rotation = 0, Texture2D texture2D = null, Color color = new()) : base()
    {
        this.shape2D = new(position, dimension, rotation, texture2D, color);

        this.AddComponents(
            this.shape2D
        );

        this.AddTags("_RectangleShape");
    }

    public RectangleShape2D GetShape2D()
    {
        return this.shape2D;
    }
}