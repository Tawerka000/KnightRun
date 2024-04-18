using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectMove : MonoBehaviour
{
    [SerializeField] private float speed = 0.08f;
    [SerializeField] private Vector2 dir = new Vector2(-1f, 0f);
    [SerializeField] private float runRange = -9f;

    private void FixedUpdate()
    {
        if (GlobalData.isPaused)
        {
            return;
        }
        transform.Translate(dir * speed, Space.World);
        if (gameObject.transform.position.x < runRange)
        {
            Destroy(gameObject);
        }
    }
}
