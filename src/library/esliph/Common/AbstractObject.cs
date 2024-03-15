namespace Library.Esliph.Common;

public class AbstractObject : GameObject
{
    public AbstractObject() : base()
    {
        this.SetVisible(false);
    }

    public override void Start()
    {
        this.SetVisible(false);
        base.Start();
    }
}
