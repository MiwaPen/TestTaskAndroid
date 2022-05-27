using UnityEngine;
using Zenject;

public class ProjectileWeapon : WeaponBase
{
    [Inject] private AmmoPool _pool;
    [SerializeField] private Transform _throwPos;
    [SerializeField] private string _tag;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    protected override void MakeShoot()
    {
        _pool.GetAmmoFromPool(_tag,_throwPos, _transform.right,_damage);
        PlaySound();
    }

    private void PlaySound()
    {
        if (_shootSound != null)
            _shootSound.Play();
    }
}
