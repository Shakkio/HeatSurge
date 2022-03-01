using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSGProiettileManager : MonoBehaviour
{
    //base per ogni proiettile
    float timer = 5.0f;
    float speed = 300f;
    public float dmg = 7f;
    Vector2 direction;


    void Start()
    {
    }

    public void SSGShot(Vector2 direction)
    {
        this.direction = direction;
    }
    

    // Update is called once per frame
    void Update()
    {
        //INFOBASE per ogni proiettile
       

       if (GetComponent<Renderer>().isVisible == false)
       {
           this.gameObject.SetActive(false);
       }

        timer -= Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = direction*speed;

        if (timer < 0)
        {
            Debug.Log("ue");
            this.gameObject.SetActive(false);
            timer = 5.0f;
        }
    }
}
