using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectSpawn : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Sprite[] objectSprites;
    [SerializeField] private GameObject[] backgroundObjects;
    [SerializeField] private float spawnTimerMin;
    [SerializeField] private float spawnTimerMax;
    private void Start()
    {
        StartCoroutine(SpawnObject());
    }
    IEnumerator SpawnObject()
    {
        if (!GlobalData.isPaused)
        {
            yield return new WaitForSeconds(Random.Range(spawnTimerMin, spawnTimerMax));
            int rand = Random.Range(0, backgroundObjects.Length);
            Instantiate(backgroundObjects[rand], transform.position, Quaternion.identity);
            //obj.GetComponent<SpriteRenderer>().sprite = objectSprites[rand];
            StartCoroutine(SpawnObject());
        }
    }
}
