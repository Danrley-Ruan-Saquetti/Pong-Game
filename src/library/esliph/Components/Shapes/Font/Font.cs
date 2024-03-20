using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Library.Esliph.Core;

namespace Library.Esliph.Shapes;

public interface IFontShape : IShape2D
{
    public string GetContent();
    public void SetContent(string content);
    public Vector2 GetPosition();
    public SpriteFont GetFont();
    public SpriteFont SetFont();
}

public class FontShape : Shape2D, IFontShape
{
    private SpriteFont font;
    private Vector2 position;
    private Color color;
    private string content;

    public FontShape(string contentName, Vector2 position, Color color = new()) : base()
    {
        this.font = this.gameController.GetContentManager().Load<SpriteFont>(contentName);
        this.position = position;
        this.color = color;
    }

    public override void Draw()
    {
        SpriteBatchExtensions.GetSpriteBatch().DrawString(font, this.content, this.GetPosition(), this.GetColor());
        base.Draw();
    }

    public string GetContent()
    {
        return this.content;
    }

    public void SetContent(string content)
    {
        this.content = content;
    }

    public Vector2 GetPosition()
    {
        return this.position;
    }

    public SpriteFont GetFont()
    {
        return this.font;
    }

    public SpriteFont SetFont()
    {
        return this.font;
    }
}