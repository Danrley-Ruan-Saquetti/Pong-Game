namespace Library.Esliph.Common.Estates;

public enum CollisionStateType
{
    NONE,
    INTERSECTION,
    CONTAINED,
    TRIGGER
}

public class CollisionState
{
    private readonly bool isCollided;
    private readonly CollisionStateType typeCollision;

    public CollisionState(bool isCollided, CollisionStateType typeCollision)
    {
        this.isCollided = isCollided;
        this.typeCollision = typeCollision;
    }

    public bool IsCollided()
    {
        return this.isCollided;
    }

    public CollisionStateType GetTypeCollision()
    {
        return this.typeCollision;
    }
}