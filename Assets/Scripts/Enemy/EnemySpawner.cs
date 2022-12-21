using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private Enemy smallEnemy;
    
    [SerializeField] 
    private GameObject smallEnemySpawnPoint;
    
    [SerializeField] 
    private Enemy bigEnemy;
    
    [SerializeField] 
    private GameObject bigEnemySpawnPoint;

    private List<Enemy> enemyList = new List<Enemy>();

    void Start()
    {
        SwapnEnemies();
    }

    private void SwapnEnemies()
    {
        enemyList.Add(Instantiate(smallEnemy, smallEnemySpawnPoint.transform));
        enemyList.Add(Instantiate(bigEnemy, bigEnemySpawnPoint.transform));
        foreach (Enemy enemy in enemyList)
        {
            enemy.OnDied += OnEnemyDiedHandler;
        }
    }

    private void OnEnemyDiedHandler(Enemy enemy)
    {
        enemy.OnDied -= OnEnemyDiedHandler;
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);

        if (enemyList.Count == 0)
        {
            SwapnEnemies();
        }
    }
}