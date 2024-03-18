using Library.Esliph.Components.GameObjects;
using Pong.Global;

namespace Pong.Entities;

public class Floor : MapGameObject
{
    public Floor() : base(GameGlobals.WINDOW_DIMENSION, new()) { }
}