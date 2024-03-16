using Library.Esliph.Common;

namespace Library.Esliph.Components;

public interface IColliderComponentObject
{
    public void OnCollisionEnter(IGameObject gameObject);
    public void OnContainsEnter(IGameObject gameObject);
    public void OnContainsThisEnter(IGameObject gameObject);
}
