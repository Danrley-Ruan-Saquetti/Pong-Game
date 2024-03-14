using Library.Esliph.Common;
using Library.Esliph.Sprites;
using Microsoft.Xna.Framework;

namespace Library.Esliph.Components;

public interface IRectangleColliderComponentObject : IGameObject<RectangleSprite>, IColliderComponentObject { }

public class RectangleColliderComponent : ColliderComponent
{
    public override void Update(GameTime gameTime, IGameObject gameObject)
    {
        var gameObjects = this.gameController.GetCurrentScenario().GetGameObjectsIsComponentGame<RectangleSprite>();

        foreach (var _gameObject in gameObjects)
        {
            if (_gameObject.GetId() == gameObject.GetId())
            {
                continue;
            }
        }

        base.Update(gameTime, gameObject);
    }
}