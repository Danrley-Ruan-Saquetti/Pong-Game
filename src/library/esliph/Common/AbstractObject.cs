using Library.Esliph.Sprites;

namespace Library.Esliph.Common;

public class AbstractObject : GameObject<Sprite>
{
    public AbstractObject() : base(new(), false) { }
}
