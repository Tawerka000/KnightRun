using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed;
    public static float sp;
    public Vector2 dir;
    public int health;
    private AudioSource audioSource;
    private GameObject obj;
    public string str;
    public float limit;
    
    void Start()
    {
        sp = speed;
        obj = GameObject.FindWithTag(str);
        audioSource = obj.GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        transform.Translate(dir * sp, Space.World);
        if(gameObject.transform.position.x < limit)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Shield")
        {
            if (Shield.capacity >= health)
            {
                audioSource.Play();
                Destroy(gameObject);
                Shield.capacity = Shield.capacity - health;
                jump.score = jump.score + 5;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
