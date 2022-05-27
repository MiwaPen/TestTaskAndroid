using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private EnemyController _enemy;
    private int _enemyCounter = 0;
    public Action<int> OnEnemyCounterChange; 
    private void Start()
    {
        SpawnEnemy();
    }
    private void SpawnEnemy()
    {
        if (_spawnPoints.Count == 0 || _enemy == null) return;

        foreach (Transform point in _spawnPoints)
        {
            var enemy = Instantiate(_enemy, point) as EnemyController;
            enemy.OnEnemyDead += UpdateEnemyCounter;
            _enemyCounter++;
        }
        OnEnemyCounterChange?.Invoke(_enemyCounter);
    }

    private void UpdateEnemyCounter(EnemyController enemy)
    {
        enemy.OnEnemyDead -= UpdateEnemyCounter;
        if (_enemyCounter > 0)
        {
            _enemyCounter--;
            OnEnemyCounterChange?.Invoke(_enemyCounter);
        }
    }
}
