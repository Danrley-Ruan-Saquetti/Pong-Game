namespace Library.Esliph.Components;

public interface IColliderComponentObject
{
    public void OnCollision();
}

public class ColliderComponent<T> : Component<T> where T : IColliderComponentObject
{
    public ColliderComponent(T componentObject) : base(componentObject) { }
}