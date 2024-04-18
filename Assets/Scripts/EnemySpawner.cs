using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] runningEnemy;
    [SerializeField] private GameObject[] flyingEnemy;
    [SerializeField] private float spawnTimerMin;
    [SerializeField] private float spawnTimerMax;
    private GameObject[] enemies;
    [SerializeField] private Vector3 diffWithFlyingSpawn = new Vector3(0, 1.4f, 0);
    void Start()
    {
        enemies = flyingEnemy.Concat(runningEnemy).ToArray();
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        if (!GlobalData.isPaused)
        {
            yield return new WaitForSeconds(Random.Range(spawnTimerMin, spawnTimerMax));
            int rand = Random.Range(0, enemies.Length);
            if (rand < flyingEnemy.Length)
            {
                Instantiate(enemies[rand], gameObject.transform.position + diffWithFlyingSpawn, Quaternion.identity);
            }
            else
            {
                Instantiate(enemies[rand], transform.position, Quaternion.identity);
            }
            StartCoroutine(SpawnEnemy());
        }
    }
}
