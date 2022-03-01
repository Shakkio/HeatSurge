using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBulletManager : MonoBehaviour
{
    float speed = 500f;
    public float dmg = 4f;
    Vector2 direction;
    float timer = 5.0f;
    bool collided = false;
    Rigidbody2D rigidbody2D;
    Animator pbAnimator;
    BoxCollider2D pbBox;

    void Awake()
    {
        pbBox = GetComponent<BoxCollider2D>(); 
        pbAnimator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        pbBox.enabled = true;
    }

    public void PistolShot(Vector2 direction)
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

            if (timer < 0)
            {
                this.gameObject.SetActive(false);
                timer = 5.0f;
            }
        }

        if (pbAnimator.GetCurrentAnimatorStateInfo(0).IsName("destroy") && pbAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Debug.Log("ueueueeuueueu");
            this.gameObject.SetActive(false);
            collided = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Wall" || collision.tag == "innocuo" || collision.tag == "Shadow")
        {
            pbAnimator.Play("destroy");
            pbBox.enabled = false;
            collided = true;
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
