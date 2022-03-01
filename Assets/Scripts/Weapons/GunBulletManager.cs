using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBulletManager : MonoBehaviour
{
    float speed = 500f;
    public float dmg = 3f;
    Vector2 direction;
    float timer = 5f;
    bool collided = false;
    Rigidbody2D rigidbody2D;
    Animator gunAnimator;
    BoxCollider2D box;

    void Awake()
    {
        gunAnimator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        box.enabled = true;
    }

    public void gunShot(Vector2 direction)
    {
        this.direction = direction;
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
                timer = 5f;
            }
        }

        

        if (gunAnimator.GetCurrentAnimatorStateInfo(0).IsName("destroy") && gunAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            this.gameObject.SetActive(false);
            collided = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Wall" || collision.tag == "innocuo" || collision.tag == "Shadow")
        {
            box.enabled = false;
            gunAnimator.Play("destroy");
            collided = true;
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
