using System;
using Microsoft.Xna.Framework;

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

    public TriangleSprite() : this(new(), new(), new()) { }
    public TriangleSprite(Vector2 position1, Vector2 position2, Vector2 position3) : base()
    {
        this.positions = new Vector2[3];

        this.positions[0] = position1;
        this.positions[1] = position2;
        this.positions[2] = position3;
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