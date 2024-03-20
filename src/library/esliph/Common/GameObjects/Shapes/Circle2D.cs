using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Shapes;
using Library.Esliph.Common;

namespace Library.Esliph.Components.GameObjects;

public class CircleGameObject : GameObject
{
    private CircleShape2D shape2D;

    public CircleGameObject(Vector2 position = new(), float radius = 0, int? segments = null, float rotation = 0, Texture2D texture2D = null, Color color = new()) : base()
    {
        this.shape2D = new(position, radius, segments, rotation, texture2D, color);

        this.AddComponents(
            this.shape2D
        );

        this.AddTags("_CircleShape");
    }

    public CircleShape2D GetShape2D()
    {
        return this.shape2D;
    }
}