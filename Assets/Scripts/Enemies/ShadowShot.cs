using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowShot : MonoBehaviour
{
    Vector2 direction;
    float speed = 200f;
    float timer = 8.0f;
    bool collided = false;
    Rigidbody2D rigidbody2D;
    Animator shdshotAnimator;
    PlayerManager PlayerManager;
    CircleCollider2D bxcollider2d;
    void Awake()
    {
        PlayerManager = GameObject.Find("Protagonista").GetComponent<PlayerManager>();
        shdshotAnimator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        bxcollider2d = GetComponent<CircleCollider2D>();

    }
    public void shadowShot(Vector2 direction)
    {
        this.direction = direction;
        bxcollider2d.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collided == false)
        {
            if (GetComponent<Renderer>().isVisible == false)
            {
                this.gameObject.SetActive(false);
            }

            timer -= Time.deltaTime;
            rigidbody2D.velocity = direction * speed;

            if (timer <= 0)
            {
                this.gameObject.SetActive(false);
                timer = 0.8f;
            }
        }

        if (shdshotAnimator.GetCurrentAnimatorStateInfo(0).IsName("destroy") && shdshotAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            this.gameObject.SetActive(false);
            collided = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "Player")
        {
            bxcollider2d.enabled = false;
            shdshotAnimator.Play("destroy");
            collided = true;
            rigidbody2D.velocity = Vector2.zero;
        }

        if (collision.tag == "Player")
        {
            PlayerManager.Death();
        }
    }


}
