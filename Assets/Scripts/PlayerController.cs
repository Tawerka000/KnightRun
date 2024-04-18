using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool onGround;
    [SerializeField] private int Forcejump;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpStartSound, jumpEndSound, deathSound, catchCoinSound, useShield;
    [SerializeField] private AudioClip[] stepSounds;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Animator animator;
    [SerializeField] private Shield shield;
    [SerializeField] private int pastEnemyPoint = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shield = GetComponent<Shield>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (GlobalData.isPaused)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpPlayer();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                JumpPlayer();
            }
        }
    }
    public void JumpPlayer()
    {
        if (onGround)
        {
            onGround = false;
            animator.SetTrigger("Jump");
            animator.SetBool("OnGround", false);
            audioSource.PlayOneShot(jumpStartSound);
            rb.AddForce(new Vector2(0, Forcejump));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("OnGround", true);
            onGround = true;
            audioSource.PlayOneShot(jumpEndSound);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (GlobalData.isPaused)
        {
            return;
        }
        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.GetComponent<EnemyMove>().IsKillable && shield.UseShield())
            {
                audioSource.PlayOneShot(useShield);
                animator.SetTrigger("Block");
                col.gameObject.GetComponent<EnemyMove>().Death();
            }
            else
            {
                Death();
                animator.updateMode = AnimatorUpdateMode.UnscaledTime;
                audioSource.PlayOneShot(deathSound);
                animator.SetTrigger("Death");
            }
        }
        else if(col.gameObject.tag == "score")
        {
            GlobalEventManager.PointGet(pastEnemyPoint);
            audioSource.PlayOneShot(catchCoinSound);
        }
     }
    private void Death()
    {
        GlobalData.Pause();
        gameOverScreen.SetActive(true);
        pauseScreen.SetActive(false);
        GlobalEventManager.SetBestScore();
    }
    public void PlayStepSound()
    {
        int rand = Random.Range(0, stepSounds.Length);
        audioSource.PlayOneShot(stepSounds[rand]);
    }
}
