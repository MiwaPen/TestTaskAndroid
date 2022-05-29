using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderScript : MonoBehaviour
{
    [SerializeField] private CrosshairController _crossController;
    [SerializeField] private List<WeaponBase> _weapons;
    [SerializeField] private AudioSource _changeWeaponSound;
    private WeaponBase _currentWeapon;
    private Rigidbody2D _weaponRigidbody;

    private void Awake()
    {
        ChangeWeapon(0);
    }

    public void Shoot()
    {
        _currentWeapon.TryMakeShoot();
    }

    private void FixedUpdate()
    {
        RotateWeapon();
    }

    private void RotateWeapon()
    {
        if (_currentWeapon == null) return;
        Vector3 difference  = _crossController.CrossPos.position - _weaponRigidbody.transform.position;

        difference = difference.normalized;
        float rotationZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;

        _weaponRigidbody.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);           
    }

    public void ChangeWeapon(int weaponIndex)
    {
        if (_weapons.Count <= 0) return;

        if(_currentWeapon!=null)
            _currentWeapon.gameObject.SetActive(false);

        _currentWeapon = _weapons[weaponIndex];
        _weaponRigidbody = _currentWeapon.GetComponent<Rigidbody2D>();
        _currentWeapon.gameObject.SetActive(true);
        PlaySound();
    }

    private void PlaySound()
    {
        if (_changeWeaponSound != null)
            _changeWeaponSound.Play();
    }
}
