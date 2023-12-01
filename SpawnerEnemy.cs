using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Enemy _enemyPrefab;

    private float _randomDelay = 2f;
    private Coroutine _coroutineSpawnEnemy;

    private void OnEnable()
    {
        _coroutineSpawnEnemy = StartCoroutine(SpawnEnemy());
    }

    private void OnDisable()
    {
        if (_coroutineSpawnEnemy != null)
            StopCoroutine(_coroutineSpawnEnemy);
    }

    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds delaySpawn = new WaitForSeconds(_randomDelay);

        while (true)
        {
            Enemy enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);

            if (enemy.TryGetComponent(out MovementEnemy movementEnemy))
                movementEnemy.SetTarget(_targetPoint);

            yield return delaySpawn;
        }
    }
}
