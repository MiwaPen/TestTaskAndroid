using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class BallisticAmmoScript : MonoBehaviour, IPooledObject
{
    [SerializeField] private float _throwForce = 0;
    private Transform _transform;
    private int _damage = 0;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _transform = transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void GetFromPool(Transform startPosition, Vector2 direction, int damage)
    {
        _transform.position = startPosition.position;
        _damage = damage;
        _rigidbody2D.AddForce(direction * _throwForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            damageable.TryApplyDamage(_damage);
        gameObject.SetActive(false);
    }
    
}
