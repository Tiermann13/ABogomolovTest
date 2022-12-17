using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject smallEnemy;
    
    [SerializeField] 
    private GameObject smallEnemySpawnPoint;
    
    [SerializeField] 
    private GameObject bigEnemy;
    
    [SerializeField] 
    private GameObject bigEnemySpawnPoint;
    
    static public int enemiesCounter = 0;
    void Start()
    {
        SwapEnemies();
    }

    private void SwapEnemies()
    {
        Instantiate(smallEnemy, smallEnemySpawnPoint.transform);
        enemiesCounter++;
        Instantiate(bigEnemy, bigEnemySpawnPoint.transform);
        enemiesCounter++;
    }
    
    void Update()
    {
        if (enemiesCounter == 0)
        {
            SwapEnemies();
        }
    }
}
