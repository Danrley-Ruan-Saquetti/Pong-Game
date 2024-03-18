using Library.Esliph.Components.GameObjects;
using Pong.Global;

namespace Pong.Entities;

public class Floor : MapGameObject
{
    public Floor() : base(GlobalGame.WINDOW_DIMENSION, new()) { }
}