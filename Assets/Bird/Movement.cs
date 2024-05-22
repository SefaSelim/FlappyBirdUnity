using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public AudioClip CoinSound;
    public AudioClip DeathSound;
    public AudioSource audioSource;

    bool forOnce;
    public GameObject DeathScreen;
    public GameManager manager;
    public bool isDead;

    float timer = 0;
    private Rigidbody2D bird;
    private Animator animator;
    
    public float jumpHeight;
    public bool isFlapping;


    void Start()
    {
        bird = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Time.timeScale = 0;
    }

    void Update()
    {

        timer += Time.deltaTime;

    if(timer<0.4 && Input.GetMouseButtonDown(0))
    {
        animator.SetBool("ForcedOut",true);
    }
    else
    {
        animator.SetBool("ForcedOut",false);
    }



        
        if(Input.GetMouseButtonDown(0))
        {
            bird.velocity = Vector2.up * jumpHeight;
            animator.SetBool("IsFlapping",true);
            timer = 0;
            if (!forOnce&&!isDead)
            {
                Time.timeScale = 1;
                forOnce = true;
            }
        }
        else if(timer>0.4)
        {
            animator.SetBool("IsFlapping",false);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "ScoreArea")
        {
            manager.updateScore();
            audioSource.PlayOneShot(CoinSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "DeathArea")
        {
            isDead = true;
            Time.timeScale = 0;
            DeathScreen.SetActive(true);
            forOnce = false;
            audioSource.PlayOneShot(DeathSound,1.5f);
        }
    }


}
