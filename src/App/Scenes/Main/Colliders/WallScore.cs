using Library.Esliph.Components.GameObjects;
using Pong.Global;

namespace Pong.Scenes.Main.Colliders;

public class WallScoreCollider : RectangleGameObject
{
    public WallScoreCollider(int x) : base(new(x, 0), new(1, GlobalGame.WINDOW_DIMENSION.Height))
    {
        this.AddTags("WallScore");
    }
}