using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    [SerializeField] GameObject Taptap;

    private float Intensity = 0.1f;

    public AudioClip WooshSound;
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
        StaticSettings.isGameFreezed = true;
    }

    void Update()
    {
        audioSource.volume = StaticSettings.SoundValue;


        if (StaticSettings.isGameFreezed)
        {
            bird.gravityScale = 0;
            bird.velocity = Vector2.zero;
        }
        else if (!StaticSettings.isGameFreezed)
        {
            bird.gravityScale = 1;   
        }


        timer += Time.deltaTime;

    if(timer<0.4 && Input.GetMouseButtonDown(0))
    {
        animator.SetBool("ForcedOut",true);
    }
    else
    {
        animator.SetBool("ForcedOut",false);
    }


        if(Input.GetMouseButtonDown(0)&&!isDead&&!EventSystem.current.IsPointerOverGameObject())
        {
            if (Taptap.activeSelf)
            {
                Taptap.SetActive(false);
            }

            if (!forOnce && !isDead)
            {
                StaticSettings.isGameFreezed = false;
                forOnce = true;
            }


            Intensity = (float)StaticSettings.CurrentScore / 1000;
            ScreenShake.Instance.Shake(StaticSettings.CurrentScore / 50, Intensity);



            audioSource.PlayOneShot(WooshSound,0.1f);
            bird.velocity = Vector2.up * jumpHeight;
            animator.SetBool("IsFlapping",true);
            timer = 0;

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
            ScreenShake.Instance.Shake(3, .5f);

            audioSource.PlayOneShot(DeathSound,1.5f);
            isDead = true;
            DeathScreen.SetActive(true);
            forOnce = false;
        }
    }


}
