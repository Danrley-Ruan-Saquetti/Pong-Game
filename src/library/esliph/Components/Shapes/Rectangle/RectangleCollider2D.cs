using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Shapes;

namespace Library.Esliph.Components;

public class RectangleCollider2DComponent : Component
{
    private IColliderComponentObject colliderComponentObject;

    public RectangleCollider2DComponent(IColliderComponentObject colliderComponentObject)
    {
        this.colliderComponentObject = colliderComponentObject;
    }

    public override void Update(GameTime gameTime, IGameObject gameObject)
    {
        RectangleShape2D rectangleShape2D = gameObject.GetShape2D<RectangleShape2D>();

        if (rectangleShape2D == null)
        {
            return;
        }

        var gameObjects = this.gameController.GetGameObjectsAliveInAreaOfTheCurrentScenario(rectangleShape2D.center, rectangleShape2D.Width + rectangleShape2D.Height);

        foreach (var _gameObject in gameObjects)
        {
            if (_gameObject.GetId() == gameObject.GetId())
            {
                continue;
            }

            RectangleShape2D _rectangleShape2D = _gameObject.GetShape2D<RectangleShape2D>();
            if (_rectangleShape2D == null)
            {
                continue;
            }

            if (rectangleShape2D.GetRectangle().Intersects(_rectangleShape2D.GetRectangle()))
            {
                this.colliderComponentObject.OnCollision(_gameObject);
            }
        }

        base.Update(gameTime, gameObject);
    }
}