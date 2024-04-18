using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapMove : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private int numOfGrounds = 3;
    [SerializeField] private float speed = 0.08f;
    [SerializeField] private Vector2 dir = new Vector2(-1f, 0f);
    [SerializeField] private List<GameObject> grounds;
    [SerializeField] private float deleteCoordinate = -11f;
    [SerializeField] private Vector2 shiftSize = new Vector2(8f, 0f);
    void Start()
    {
        for(int i = grounds.Count; i < numOfGrounds; i++)
        {
            CreateNewGround();
        }
    }
    void FixedUpdate()
    {
        if (GlobalData.isPaused)
        {
            return;
        }
        foreach(GameObject ground in grounds)
        {
            ground.transform.Translate(dir * speed, Space.World);
        }
        if (grounds[0].transform.position.x < deleteCoordinate)
            {
                GameObject firstGround = grounds[0];
                grounds.Remove(grounds[0]);
                Destroy(firstGround);
                CreateNewGround();
            }
    }
    private void CreateNewGround()
    {
        if (grounds.Count < numOfGrounds)
        {
            grounds.Add(Instantiate(groundPrefab, 
                        grounds[grounds.Count-1].transform.position + (Vector3)shiftSize,
                        Quaternion.identity));
        }
    }
}
