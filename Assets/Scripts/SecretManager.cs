using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretManager : MonoBehaviour
{
    public GameObject Mask;
    public TutorialManager tutorialManager;

    int idt = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Mask.GetComponent<Animator>().Play("fade");
            tutorialManager.Tutorial(idt);
        }
    }
}
