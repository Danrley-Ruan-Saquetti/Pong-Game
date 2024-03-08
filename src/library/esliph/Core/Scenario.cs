using Microsoft.Xna.Framework;

namespace Library.Esliph.Core;

public class Scenario
{
    public readonly StateGame state;

    public Scenario(Color backgroundColor = new())
    {
        this.state = new(backgroundColor);
    }
}