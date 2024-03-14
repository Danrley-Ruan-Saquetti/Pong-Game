using Library.Esliph.Common;

namespace Library.Esliph.Components;

public interface IColliderComponentObject : IGameObject
{
    public void OnCollision();
}

public class ColliderComponent : Component { }