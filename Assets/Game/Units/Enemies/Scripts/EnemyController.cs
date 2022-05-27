using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealPoins;
    [SerializeField] private HealthBarController _healthBarController;
    [SerializeField] private AudioSource _breakSound;
    [SerializeField] private int _dieDelay;
    private int _currentHealPoints;
    public Action<EnemyController> OnEnemyDead; 
    private void Start()
    {
        _currentHealPoints = _maxHealPoins;
        _healthBarController.SetHealPointsInfo(_maxHealPoins,_currentHealPoints);
    }
    public void TryApplyDamage(int damage)
    {
        if (_currentHealPoints > 0)
        {
            ApplyDamage(damage);
            _healthBarController.UpdateHealthBar(_currentHealPoints);
            ChechHealPoints();
        }    
    }

    private void ApplyDamage(int damage)
    {
        _currentHealPoints -= damage;
    }

    private async void ChechHealPoints()
    {
        if (_currentHealPoints <= 0)
        {
            PlaySound();
            await UniTask.Delay(_dieDelay);
            OnEnemyDead?.Invoke(this.gameObject.GetComponent<EnemyController>());
            Destroy(this.gameObject);
        }     
    }

    private void PlaySound()
    {
        if (_breakSound != null)
            _breakSound.Play();
    }
}

