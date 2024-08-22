using System.Collections.Generic;
using UnityEngine;

public class scr_Enemy_Pool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyList; // List of enemies already in the scene
    [SerializeField] private int _maxEnemyOnMap = 5;
    [SerializeField] private int _pauseBetweenSpawnsInSeconds = 5;

    private Timer _timer;
    private int _currentEnemyCount = 0;

    private void Awake()
    {
        // Initialize the timer
        _timer = new Timer(this);
        _timer.Set(_pauseBetweenSpawnsInSeconds);
        _timer.OnTimeIsOver += V_SpawnEnemy;
        _timer.StartCountingTime();
    }

    private void V_SpawnEnemy()
    {
        if (_currentEnemyCount < _maxEnemyOnMap)
        {
            // Find an inactive enemy in the list and activate it
            foreach (var enemy in _enemyList)
            {
                if (!enemy.activeInHierarchy)
                {
                    enemy.SetActive(true);
                    _currentEnemyCount++;
                    break;
                }
            }
        }

        // Restart the timer for the next spawn
        _timer.Set(_pauseBetweenSpawnsInSeconds);
        _timer.StartCountingTime();
    }

    private void Update()
    {
        // Optional: Clean up inactive enemies to reset _currentEnemyCount
        _currentEnemyCount = 0;
        foreach (var enemy in _enemyList)
        {
            if (enemy.activeInHierarchy)
            {
                _currentEnemyCount++;
            }
        }
    }
}
