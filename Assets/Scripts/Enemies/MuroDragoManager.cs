using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroDragoManager : MonoBehaviour
{
    Animator wallAnimator;

    private void Awake()
    {
        wallAnimator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (wallAnimator.GetCurrentAnimatorStateInfo(0).IsName("destroy") && wallAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if(collision.collider.gameObject.tag == "Enemy")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            wallAnimator.Play("destroy");
        }
    }
}
