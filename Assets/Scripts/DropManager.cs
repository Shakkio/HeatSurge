using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{

    int groundLayer = 1 << 8 | 1 << 9 | 1 << 10;
    bool triggered = false;
    AssistManager AssistManager;
    public int id;
    public int idT = 0;
    Rigidbody2D rigidbody2D;
    TutorialManager tutorialManager;


    void Awake()
    {
        tutorialManager = GameObject.Find("Struttura Utile").GetComponent<TutorialManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        AssistManager = GameObject.Find("Struttura Utile").GetComponent<AssistManager>();
    }

    public void GetId(int idEnemy)
    {
        id = idEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer))
        {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.gravityScale = 0;
        }

        if(triggered)
        {
            AssistManager.Ebutton();

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (id == 0)
                {
                    Debug.Log("wow hai droppato zi");
                }
                else if (id == 1)
                {
                    GameData.KeyAp = true;
                    tutorialManager.Tutorial(idT);
                }
                else if (id == 2)
                {
                    GameData.gunAmmo += Random.Range(10, 20);
                    tutorialManager.Tutorial(idT);
                }
                else if (id == 99)
                {
                    GameData.woodenkatagiUnlock = true;
                    tutorialManager.Tutorial(idT);
                }

                AssistManager.EbuttonDeactivate();
                this.gameObject.SetActive(false);
            }
        }
    }

    public void Getidt(int idt)
    {
        this.idT = idt;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggered = false;
            AssistManager.EbuttonDeactivate();
        }
    }
}
