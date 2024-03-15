using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Sprites;

namespace Library.Esliph.Components;

public class RectangleColliderComponent : Component
{
    private IColliderComponentObject colliderComponentObject;

    public RectangleColliderComponent(IColliderComponentObject colliderComponentObject)
    {
        this.colliderComponentObject = colliderComponentObject;
    }

    public override void Update(GameTime gameTime, IGameObject gameObject)
    {
        RectangleSprite rectangleSprite = gameObject.GetComponentActive<RectangleSprite>();

        if (rectangleSprite == null)
        {
            return;
        }

        var gameObjects = this.gameController.GetGameObjectsAliveOfTheCurrentScenario();

        foreach (var _gameObject in gameObjects)
        {
            if (_gameObject.GetId() == gameObject.GetId())
            {
                continue;
            }

            RectangleSprite _rectangleSprite = _gameObject.GetComponentActive<RectangleSprite>();
            if (_rectangleSprite == null)
            {
                continue;
            }

            if (rectangleSprite.GetRectangle().Intersects(_rectangleSprite.GetRectangle()))
            {
                this.colliderComponentObject.OnCollision(_gameObject);
            }
        }

        base.Update(gameTime, gameObject);
    }
}