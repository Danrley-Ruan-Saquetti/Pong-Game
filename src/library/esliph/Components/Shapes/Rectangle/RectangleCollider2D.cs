using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Library.Esliph.Shapes;

namespace Library.Esliph.Components;

public class RectangleCollider2DComponent : ColliderComponent
{
    public RectangleCollider2DComponent(IColliderComponentObject colliderComponentObject) : base(colliderComponentObject) { }

    public override void Update(GameTime gameTime, IGameObject gameObject)
    {
        RectangleShape2D rectangleShape2D = gameObject.GetShape2D<RectangleShape2D>();

        if (rectangleShape2D == null)
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

            if (shape is RectangleShape2D rectangleShape)
            {
                this.ResolveCollisionBetweenRectangles(rectangleShape2D, rectangleShape, _gameObject);
                continue;
            }

            if (shape is CircleShape2D circleShape)
            {
                this.ResolveCollisionBetweenRectangleAndCircle(rectangleShape2D, circleShape, _gameObject);
                continue;
            }
        }

        base.Update(gameTime, gameObject);
    }
}