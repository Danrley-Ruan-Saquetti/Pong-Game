using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Common;
using Library.Esliph.Shapes;

namespace Library.Esliph.Components.GameObjects;

public class TriangleGameObject : GameObject
{
    public TriangleGameObject(Vector2 position1 = new(), Vector2 position2 = new(), Vector2 position3 = new(), Texture2D texture2D = null) : base()
    {
        this.AddComponents(
            new TriangleShape2D(position1, position2, position3, texture2D)
        );

        this.AddTags("_TriangleShape");
    }

    public TriangleShape2D GetShape2D()
    {
        return this.GetShape2D<TriangleShape2D>();
    }
}