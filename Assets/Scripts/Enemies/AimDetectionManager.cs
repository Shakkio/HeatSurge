using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDetectionManager : MonoBehaviour
{
    public GameObject Enemy;
    public int id = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(id == 0)
            {
                Enemy.GetComponent<OmbraManager>().detected = true;
            }
            else if (id == 1)
            {
                Enemy.GetComponent<ApManager>().detected = true;
            }
        }
    }
}
