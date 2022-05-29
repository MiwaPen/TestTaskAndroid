using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class StandartAmmoScript : MonoBehaviour, IBullet
{
    [SerializeField] private float _speed;
    private int _damage;
    private Transform _transform;
    private Vector3 _direction = Vector3.zero;

    private void Awake()
    {
        _transform = transform;
    }

    public void Initialize(Transform startPosition, Vector2 direction, int damage)
    {
        _transform.position = startPosition.position;
        _damage = damage;
        _direction = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            damageable.TryApplyDamage(_damage);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_direction == Vector3.zero) return;
        _transform.position = _transform.position + _direction * _speed * Time.deltaTime;
    }

    private void OnDisable()
    {
        _direction = Vector3.zero;
    }
}
