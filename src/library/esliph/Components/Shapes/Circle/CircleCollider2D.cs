using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Shapes;

namespace Library.Esliph.Components;

public class CircleCollider2DComponent : ColliderComponent
{
    public CircleCollider2DComponent(IColliderComponentObject colliderComponentObject) : base(colliderComponentObject) { }

    public override void Update(GameTime gameTime, IGameObject gameObject)
    {
        CircleShape2D circleShape2D = gameObject.GetShape2D<CircleShape2D>();

        if (circleShape2D == null)
        {
            return;
        }

        var gameObjects = this.gameController.GetGameObjectsAliveOfTheCurrentScenario(gameObject.GetId());

        foreach (var _gameObject in gameObjects)
        {
            IShape2D shape = _gameObject.GetShape2D<Shape2D>();

            if (shape == null)
            {
                continue;
            }

            if (shape is RectangleShape2D)
            {
                this.VerifyCollisionBetweenRectangleAndCircle((RectangleShape2D)shape, circleShape2D, gameObject);
                continue;
            }

            if (shape is CircleShape2D)
            {
                this.VerifyCollisionBetweenCircles(circleShape2D, (CircleShape2D)shape, gameObject);
                continue;
            }
        }

        base.Update(gameTime, gameObject);
    }
}