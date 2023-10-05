using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class jump : MonoBehaviour
{
    Rigidbody2D rb;
    public bool ReadyGround;
    public int Forcejump;
    public static int score;
    public Text scoreT;
    private AudioSource jump_audioSource, death_audioSource, run_audioSource, getting_score_sound;
    private GameObject jump_obj, death_obj, run_obj, run_anim_obj, getting_score_obj;
    public GameObject GameOver_Button;
    private Animator run_anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreT.text = score.ToString();
        score = 0;
        jump_obj = GameObject.FindWithTag("PlayerJump");
        jump_audioSource = jump_obj.GetComponent<AudioSource>();;
        death_obj = GameObject.FindWithTag("PlayerDeath");
        death_audioSource = death_obj.GetComponent<AudioSource>();
        run_obj = GameObject.FindWithTag("PlayerRun");
        run_audioSource = run_obj.GetComponent<AudioSource>();
        run_anim_obj = GameObject.FindWithTag("Player");
        run_anim = run_anim_obj.GetComponent<Animator>();
        getting_score_obj = GameObject.FindWithTag("GettingScore");
        getting_score_sound = getting_score_obj.GetComponent<AudioSource>();
    }
    void Update()
    {
        scoreT.text = score.ToString();
    }
    public void JumpPlayer()
    {
        if (ReadyGround)
        {
            StartCoroutine(JumpWithSound());
        }
    }
    IEnumerator JumpWithSound()
    {
        jump_audioSource.Play();
        run_audioSource.Stop();
        run_anim.SetInteger("JumpAndFall", 1);
        rb.AddForce(new Vector2(0, Forcejump));
        ReadyGround = false;
        yield return new WaitForSeconds(0.8f);
        run_audioSource.Play();
        run_anim.SetInteger("JumpAndFall", 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            ReadyGround = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            jump_audioSource.Stop();
            run_audioSource.Stop();
            death_audioSource.Play();
            MoveEnemy.sp = 0;
            MoveSpikes.sp = 0;
            Time.timeScale = 0;
            GameOver_Button.active = true;
            if (score > PlayerPrefs.GetInt("BestScore", 0))
                PlayerPrefs.SetInt("BestScore", score);
        }
        if(collision.gameObject.tag == "score")
        {
            getting_score_sound.Play();
            score++;
        }
     }
}
