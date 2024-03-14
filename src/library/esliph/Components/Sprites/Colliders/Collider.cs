using Library.Esliph.Common;

namespace Library.Esliph.Components;

public interface IColliderComponentObject : IGameObject
{
    public void OnCollision();
}

public class ColliderComponent<T> : Component<T> where T : IColliderComponentObject { }