using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Sprite2Ds;

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
        RectangleSprite2D rectangleSprite2D = gameObject.GetComponentActive<RectangleSprite2D>();

        if (rectangleSprite2D == null)
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

            RectangleSprite2D _rectangleSprite2D = _gameObject.GetComponentActive<RectangleSprite2D>();
            if (_rectangleSprite2D == null)
            {
                continue;
            }

            if (rectangleSprite2D.GetRectangle().Intersects(_rectangleSprite2D.GetRectangle()))
            {
                this.colliderComponentObject.OnCollision(_gameObject);
            }
        }

        base.Update(gameTime, gameObject);
    }
}