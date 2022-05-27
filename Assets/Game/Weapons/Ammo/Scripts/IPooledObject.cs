using UnityEngine;

public interface IPooledObject 
{
    public void GetFromPool(Transform startPosition, Vector2 direction, int damage);
}
