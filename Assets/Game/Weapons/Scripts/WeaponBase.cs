using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected AudioSource _shootSound;

    public void TryMakeShoot()
    {
       MakeShoot();
    }

    protected abstract void MakeShoot();
}
