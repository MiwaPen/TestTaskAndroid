using UnityEngine;

public interface IBullet 
{
    public void Initialize(Transform startPosition, Vector2 direction, int damage);
}
