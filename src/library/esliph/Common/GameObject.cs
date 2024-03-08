using Microsoft.Xna.Framework;
using Library.Esliph.Sprites;

namespace Library.Esliph.Common;

public class GameObject
{
    private Sprite sprite;
    private bool alive { get; set; }

    public GameObject(Sprite sprite)
    {
        this.sprite = sprite;
        this.alive = true;
    }

    public virtual void Update(GameTime gameTime)
    {
        this.GetSprite().Update(gameTime);
    }

    public virtual void Draw(GameTime gameTime)
    {
        this.GetSprite().Draw(gameTime);
    }

    public Sprite GetSprite()
    {
        return this.sprite;
    }

    public void SetSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public bool IsAlive()
    {
        return alive;
    }

    public void SetAlive(bool alive)
    {
        this.alive = alive;
    }
}