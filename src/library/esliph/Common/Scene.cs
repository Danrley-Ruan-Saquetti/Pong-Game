using Microsoft.Xna.Framework;
using Library.Esliph.Controller;

namespace Library.Esliph.Common;

public interface IScene : IGameObjectsController
{
    public void Initialize();
    public Color GetBackgroundColor();
    public void SetBackgroundColor(Color color);
    public string GetName();
    public void SetName(string name);
}

public class Scene : GameObjectsController, IScene
{
    private string name { get; set; }
    private Color backgroundColor;

    public Scene(string name, Color backgroundColor = new()) : base()
    {
        this.name = name;
        this.backgroundColor = backgroundColor;
    }

    public virtual void Initialize() { }

    public Color GetBackgroundColor()
    {
        return this.backgroundColor;
    }

    public void SetBackgroundColor(Color color)
    {
        this.backgroundColor = color;
    }

    public string GetName()
    {
        return this.name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }
}