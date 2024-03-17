using System;
using Library.Esliph.Common;
using Library.Esliph.Common.Estates;
using Library.Esliph.Shapes;

namespace Library.Esliph.Components;

public interface IColliderComponentObject
{
    public void OnCollisionEnter(IGameObject gameObject);
    public void OnContainsEnter(IGameObject gameObject);
    public void OnContainsThisEnter(IGameObject gameObject);
}

public class ColliderComponent : Component
{
    protected IColliderComponentObject colliderComponentObject;

    public ColliderComponent(IColliderComponentObject colliderComponentObject, bool active = true) : base(active)
    {
        this.colliderComponentObject = colliderComponentObject;
    }

    protected void VerifyCollisionBetweenRectangles(RectangleShape2D rectangleShape2D, RectangleShape2D _rectangleShape2D, IGameObject gameObject)
    {
        CollisionState collisionState = ColliderComponent.ReadCollisionBetweenRectangles(rectangleShape2D, _rectangleShape2D);

        this.EmitEventCollisionState(collisionState, gameObject);
    }

    protected void VerifyCollisionBetweenCircles(CircleShape2D circleShape2D, CircleShape2D _circleShape2D, IGameObject gameObject)
    {
        CollisionState collisionState = ColliderComponent.ReadCollisionBetweenCircles(circleShape2D, _circleShape2D);

        this.EmitEventCollisionState(collisionState, gameObject);
    }

    protected void VerifyCollisionBetweenRectangleAndCircle(RectangleShape2D rectangleShape2D, CircleShape2D _circleShape2D, IGameObject gameObject)
    {
        CollisionState collisionState = ColliderComponent.ReadCollisionBetweenRectangleAndCircle(rectangleShape2D, _circleShape2D);

        this.EmitEventCollisionState(collisionState, gameObject);
    }

    public static CollisionState ReadCollisionBetweenRectangles(RectangleShape2D rectangleShape2D, RectangleShape2D _rectangleShape2D)
    {
        if (rectangleShape2D.IsBiggestThan(_rectangleShape2D) && rectangleShape2D.GetRectangle().Contains(_rectangleShape2D.GetRectangle()))
        {
            return new(true, CollisionStateType.TRIGGER);
        }
        else if (_rectangleShape2D.GetRectangle().Contains(rectangleShape2D.GetRectangle()))
        {
            return new(true, CollisionStateType.CONTAINED);
        }
        if (rectangleShape2D.GetRectangle().Intersects(_rectangleShape2D.GetRectangle()))
        {
            return new(true, CollisionStateType.INTERSECTION);
        }

        return new(false, CollisionStateType.NONE);
    }

    public static CollisionState ReadCollisionBetweenCircles(CircleShape2D circleShape2D, CircleShape2D _circleShape2D)
    {
        return new(false, CollisionStateType.NONE);
    }

    protected static CollisionState ReadCollisionBetweenRectangleAndCircle(RectangleShape2D rectangleShape2D, CircleShape2D circleShape2D)
    {
        float distanceX = Math.Abs(circleShape2D.X - (rectangleShape2D.X + rectangleShape2D.center.X));
        float distanceY = Math.Abs(circleShape2D.Y - (rectangleShape2D.Y + rectangleShape2D.center.Y));

        if (distanceX >= circleShape2D.GetRadius() + rectangleShape2D.center.X || distanceY >= circleShape2D.GetRadius() + rectangleShape2D.center.Y)
        {
            return new(false, CollisionStateType.NONE);
        }

        if (rectangleShape2D.IsBiggestThan(circleShape2D))
        {
            if (rectangleShape2D.X <= circleShape2D.InitialX && rectangleShape2D.EndX >= circleShape2D.EndX && rectangleShape2D.Y <= circleShape2D.InitialY && rectangleShape2D.EndY >= circleShape2D.EndY)
            {
                return new(true, CollisionStateType.TRIGGER);
            }
        }
        else
        {
            if (circleShape2D.InitialX <= rectangleShape2D.X && circleShape2D.EndX >= rectangleShape2D.EndX && circleShape2D.InitialY <= rectangleShape2D.Y && circleShape2D.EndY >= rectangleShape2D.EndY)
            {
                return new(true, CollisionStateType.TRIGGER);
            }
        }


        if (distanceX < rectangleShape2D.center.X && distanceY < rectangleShape2D.center.Y)
        {
            return new(true, CollisionStateType.INTERSECTION);
        }

        distanceX -= rectangleShape2D.center.X;
        distanceY -= rectangleShape2D.center.Y;

        if (distanceX * distanceX + distanceY * distanceY < circleShape2D.GetRadius() * circleShape2D.GetRadius())
        {
            return new(true, CollisionStateType.INTERSECTION);
        }

        return new(false, CollisionStateType.NONE);
    }

    protected void EmitEventCollisionState(CollisionState collisionState, IGameObject gameObject)
    {
        if (!collisionState.IsCollided() && collisionState.GetTypeCollision() == CollisionStateType.NONE)
        {
            return;
        }
        if (collisionState.GetTypeCollision() == CollisionStateType.INTERSECTION)
        {
            this.colliderComponentObject.OnCollisionEnter(gameObject);
            return;
        }
        if (collisionState.GetTypeCollision() == CollisionStateType.CONTAINED)
        {
            this.colliderComponentObject.OnContainsEnter(gameObject);
            return;
        }
        if (collisionState.GetTypeCollision() == CollisionStateType.TRIGGER)
        {
            this.colliderComponentObject.OnContainsThisEnter(gameObject);
        }
    }
}