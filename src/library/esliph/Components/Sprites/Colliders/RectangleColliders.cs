using Library.Esliph.Common;
using Library.Esliph.Sprites;
using Microsoft.Xna.Framework;

namespace Library.Esliph.Components;

public interface IRectangleColliderComponentObject : IGameObject<RectangleSprite>, IColliderComponentObject { }

public class RectangleColliderComponent : Component
{
    public override void Update(GameTime gameTime, IGameObject<ISprite> gameObject)
    {
        var gameObjects = this.gameController.GetCurrentScenario().GetGameObjectsIsComponentGame<RectangleSprite>();

        foreach (var _gameObject in gameObjects)
        {
            if (_gameObject.GetId() == gameObject.GetId())
            {
                continue;
            }

            IRectangleColliderComponentObject gameObjectRectangle = gameObject as IRectangleColliderComponentObject;

            if (gameObjectRectangle.GetSprite().GetRectangle().Intersects(_gameObject.GetSprite().GetRectangle()))
            {
                gameObjectRectangle.OnCollision();
            }
        }

        base.Update(gameTime, gameObject);
    }
}