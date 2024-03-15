using Library.Esliph.Sprites;

namespace Library.Esliph.Common;

public class AbstractObject : GameObject<ISprite>
{
    public AbstractObject() : base(null, false) { }

    public override void Start()
    {
        this.SetVisible(false);
        base.Start();
    }
}
