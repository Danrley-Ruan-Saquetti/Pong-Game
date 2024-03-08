using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Core;

namespace Library.Esliph.Sprites;

public class TriangleSprite : Sprite
{
    private Vector2[] positions;
    public Vector2 position1
    {
        get { return this.GetPosition(0); }
        set { this.positions[0] = value; }
    }
    public Vector2 position2
    {
        get { return this.GetPosition(1); }
        set { this.positions[1] = value; }
    }
    public Vector2 position3
    {
        get { return this.GetPosition(2); }
        set { this.positions[2] = value; }
    }

    public TriangleSprite(Vector2 position1 = new(), Vector2 position2 = new(), Vector2 position3 = new(), Texture2D texture2D = null) : base(texture2D)
    {
        this.positions = new Vector2[3];

        this.positions[0] = position1;
        this.positions[1] = position2;
        this.positions[2] = position3;
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatchExtensions.DrawTriangle(this.GetPosition(0), this.GetPosition(1), this.GetPosition(2), this.GetColor());
    }

    public Vector2 GetPosition(int index)
    {
        if (index < 0 || index > this.positions.Length - 1)
        {
            throw new Exception("Index position triangle \"" + index + "\" must be greater than zero and less than \"" + this.positions.Length + "\"");
        }

        return this.positions[index];
    }

    public Vector2[] GetPositions()
    {
        return this.positions;
    }
}