using Library.Esliph.Common;
using Library.Esliph.Sprites;

namespace Library.Esliph.Components;

public interface IRectangleColliderComponentObject : IGameObject<RectangleSprite>, IColliderComponentObject { }

public class RectangleColliderComponent<T> : ColliderComponent<T> where T : IRectangleColliderComponentObject
{
    public RectangleColliderComponent(T componentObject) : base(componentObject) { }
}