using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 0.08f;
    [SerializeField] private Vector2 dir = new Vector2(-1f, 0f);
    private AudioSource deathAudioSource;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip runSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private float runRange = -9f;
    [SerializeField] private int killEnemyPoints = 5;
    [SerializeField] private bool isKillable = true;
    [SerializeField] private bool isMovable = true;
    public bool IsKillable
    {
        get => isKillable;
    }
    void Start()
    {
        GlobalEventManager.Pause.AddListener(Pause);
        GlobalEventManager.Unpause.AddListener(Unpause);
        deathAudioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = runSound;
        audioSource?.Play();
    }
    void FixedUpdate()
    {
        if(!isMovable && GlobalData.isPaused)
        {
            return;
        } 
        transform.Translate(dir * speed, Space.World);
        if (gameObject.transform.position.x < runRange)
        {
            Destroy(gameObject);
        }
    }
    public void Death()
    {
        deathAudioSource?.PlayOneShot(deathSound);
        GlobalEventManager.PointGet(killEnemyPoints);
        Destroy(gameObject);
    }
    private void Pause()
    {
        audioSource?.Pause();
    }
    private void Unpause()
    {
        audioSource?.Play();
    }
}
