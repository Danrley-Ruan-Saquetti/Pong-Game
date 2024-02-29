using Microsoft.Xna.Framework;
using Pong.Global;

namespace Pong.Components;

public class BaseRectangle
{
    public Rectangle rectangle;
    public Color color;

    public BaseRectangle(int x, int y, int width, int height, Color color)
    {
        this.rectangle = new(x, y, width, height);
        this.color = color;
    }

    public void Draw(GameTime gameTime)
    {
        Globals.spriteBatch.Draw(Globals.pixel, this.rectangle, this.color);
    }

    public bool IsCollided(BaseRectangle rect)
    {
        var bounds1 = this.GetBounds();
        var bounds2 = rect.GetBounds();

        if (bounds2.PointX > bounds1.PointWidth || bounds2.PointWidth < bounds1.PointX)
        {
            return false;
        }
        if (bounds2.PointY > bounds1.PointHeight || bounds2.PointHeight < bounds1.PointY)
        {
            return false;
        }

        return true;
    }

    public dynamic GetBounds()
    {
        dynamic bounds = new
        {
            PointX = this.rectangle.X,
            PointY = this.rectangle.Y,
            Width = this.rectangle.Width,
            Height = this.rectangle.Height,
            PointWidth = this.rectangle.X + this.rectangle.Width,
            PointHeight = this.rectangle.Y + this.rectangle.Height,
            PointCenterX = this.rectangle.X + (this.rectangle.Width / 2),
            PointCenterY = this.rectangle.Y + (this.rectangle.Height / 2)
        };

        return bounds;
    }
}