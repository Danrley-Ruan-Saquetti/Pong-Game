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

        var gameObjects = this.gameController.GetGameObjectsAliveOfTheCurrentScenario(gameObject.GetId());

        foreach (var _gameObject in gameObjects)
        {
            RectangleShape2D _rectangleShape2D = _gameObject.GetShape2D<RectangleShape2D>();
            if (_rectangleShape2D == null)
            {
                continue;
            }

            if (rectangleShape2D.IsBiggestThan(_rectangleShape2D))
            {
                if (rectangleShape2D.GetRectangle().Contains(_rectangleShape2D.GetRectangle()))
                {
                    this.colliderComponentObject.OnContainsThisEnter(_gameObject);
                }
                else if (rectangleShape2D.GetRectangle().Intersects(_rectangleShape2D.GetRectangle()))
                {
                    this.colliderComponentObject.OnCollisionEnter(_gameObject);
                }
            }
            else
            {
                if (_rectangleShape2D.GetRectangle().Contains(rectangleShape2D.GetRectangle()))
                {
                    this.colliderComponentObject.OnContainsEnter(_gameObject);
                }
                else if (rectangleShape2D.GetRectangle().Intersects(_rectangleShape2D.GetRectangle()))
                {
                    this.colliderComponentObject.OnCollisionEnter(_gameObject);
                }
            }
        }

        base.Update(gameTime, gameObject);
    }
}