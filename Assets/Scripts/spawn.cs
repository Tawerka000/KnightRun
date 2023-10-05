using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public Transform SpawnPosRunning;
    public Transform SpawnPosFlying;
    public GameObject[] Enemy;
    int ArrNum;
    public int ArrLenght;
    public float time_min;
    public float time_max;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Repeat()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        ArrNum = Random.Range(0, ArrLenght);
        if (ArrNum == 0)
        {
            yield return new WaitForSeconds(Random.Range(time_min, time_max));
            Instantiate(Enemy[ArrNum], SpawnPosFlying.position, Quaternion.identity);
            Repeat();
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(time_min, time_max));
            Instantiate(Enemy[ArrNum], SpawnPosRunning.position, Quaternion.identity);
            Repeat();
        }
    }
}
