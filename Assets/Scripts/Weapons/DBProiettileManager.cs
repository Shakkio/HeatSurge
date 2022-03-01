using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBProiettileManager : MonoBehaviour
{
    float speed = 500f;
    public float dmg = 6f;
    Vector2 direction;
    Vector2 randomDirection;
    float timer = 5.0f;
    bool collided = false;
    Rigidbody2D rigidbody2D;
    Animator dbpAnimator;
    CircleCollider2D circle;

    void Awake()
    {
        circle = GetComponent<CircleCollider2D>();
        dbpAnimator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        circle.enabled = true;
    }

    public void devilShot1(Vector2 direction)
    {
        this.direction = direction;
    }

    public void devilShot2(Vector2 direction)
    {
        randomDirection = new Vector2(Random.Range(-0.5f, +0.5f), Random.Range(-0.5f, +0.5f));
        this.direction = direction + randomDirection;
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

            if (timer < 0)
            {
                this.gameObject.SetActive(false);
                timer = 5.0f;
            }
        }

        if (dbpAnimator.GetCurrentAnimatorStateInfo(0).IsName("destroy") && dbpAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Debug.Log("ueueueeuueueu");
            this.gameObject.SetActive(false);
            collided = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "Wall" || collision.tag == "innocuo" || collision.tag == "Shadow")
        {
            circle.enabled = false;
            dbpAnimator.Play("destroy");
            collided = true;
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
