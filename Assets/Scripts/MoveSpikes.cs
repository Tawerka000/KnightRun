using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpikes : MonoBehaviour
{
    public float speed;
    public static float sp;
    public Vector2 dir;
    public int health;
    public float limit;
    void Start()
    {
        sp = speed;
    }
    void FixedUpdate()
    {
        transform.Translate(dir * sp, Space.World);
        if (gameObject.transform.position.x < limit)
        {
            Destroy(gameObject);
        }
    }

}
