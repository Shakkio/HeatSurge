using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PickUpManager : MonoBehaviour
{
    public int id;
    public int flag;
    TutorialManager TutorialManager;
    public int idT;

    // Update is called once per frame
    private void Awake()
    {
        if (GameData.flag1 && flag == 1)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag2 && flag == 2)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag3 && flag == 3)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag4 && flag == 4)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag5 && flag == 5)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag6 && flag == 6)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag7 && flag == 7)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag8 && flag == 8)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag9 && flag == 9)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag10 && flag == 10)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag11 && flag == 11)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag12 && flag == 12)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag13 && flag == 13)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag14 && flag == 14)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag15 && flag == 15)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag16 && flag == 16)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag17 && flag == 17)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag18 && flag == 18)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag19 && flag == 19)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag20 && flag == 20)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag21 && flag == 21)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag22 && flag == 22)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag23 && flag == 23)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag24 && flag == 24)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag25 && flag == 25)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag26 && flag == 26)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag27 && flag == 27)
        {
            Destroy(this.gameObject);
        }
        else if (GameData.flag28 && flag == 28)
        {
            Destroy(this.gameObject);
        }

        TutorialManager = GameObject.Find("Struttura Utile").GetComponent<TutorialManager>();
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (id == 0)
            {
                GameData.ssgUnlock = true;
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
                TutorialManager.Tutorial(idT);
            }
            else if (id == 1)
            {
                GameData.devilblasterUnlock = true;
                GameData.devilblasterAmmo += 12;
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
                TutorialManager.Tutorial(idT);
            }
            else if (id == 2)
            {
                GameData.gunUnlock = true;
                GameData.gunAmmo += 20;
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
                TutorialManager.Tutorial(idT);
            }
            else if (id == 3)
            {
                GameData.firedischargeUnlock = true;
                GameData.firedischargeAmmo += 50;
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
                TutorialManager.Tutorial(idT);
            }
            else if (id == 4)
            {
                GameData.gunAmmo += 20;
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
                TutorialManager.Tutorial(idT);
            }
            else if (id == 5)
            {
                GameData.devilblasterAmmo += 8;
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
                TutorialManager.Tutorial(idT);
            }
            else if (id == 6)
            {
                GameData.devilblasterAmmo += 8;
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.GetComponent<CircleCollider2D>().enabled = false;
                GameData.devilblasterUnlock = true;
                GameData.devilblasterRepaired = true;
                GameData.Cassetta = false;
                TutorialManager.Tutorial(idT);
            }
            else if (id == 7)
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
                GameData.Cassetta = true;
                TutorialManager.Tutorial(idT);
            }
            else if (id == 8)
            {
                GameData.pistolUnlock = true;
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
                TutorialManager.Tutorial(idT);
            }



            if (flag == 1)
            {
                GameData.flag1 = true;
            }
            else if (flag == 2)
            {
                GameData.flag2 = true;
            }
            else if(flag == 3)
            {
                GameData.flag3 = true;
            }
            else if(flag == 4)
            {
                GameData.flag4 = true;
            }
            else if (flag == 5)
            {
                GameData.flag5 = true;
            }
            else if (flag == 6)
            {
                GameData.flag6 = true;
            }
            else if (flag == 7)
            {
                GameData.flag7 = true;
            }
            else if (flag == 8)
            {
                GameData.flag8 = true;
            }
            else if (flag == 9)
            {
                GameData.flag9 = true;
            }
            else if (flag == 10)
            {
                GameData.flag10 = true;
            }
            else if (flag == 11)
            {
                GameData.flag11 = true;
            }
            else if (flag == 12)
            {
                GameData.flag12 = true;
            }
            else if (flag == 13)
            {
                GameData.flag13 = true;
            }
            else if (flag == 14)
            {
                GameData.flag14 = true;
            }
            else if (flag == 15)
            {
                GameData.flag15 = true;
            }
            else if (flag == 16)
            {
                GameData.flag16 = true;
            }
            else if (flag == 17)
            {
                GameData.flag17 = true;
            }
            else if (flag == 18)
            {
                GameData.flag18 = true;
            }
            else if (flag == 19)
            {
                GameData.flag19 = true;
            }
            else if (flag == 20)
            {
                GameData.flag20 = true;
            }
            else if (flag == 21)
            {
                GameData.flag21 = true;
            }
            else if (flag == 22)
            {
                GameData.flag22 = true;
            }
            else if (flag == 23)
            {
                GameData.flag23 = true;
            }
            else if (flag == 24)
            {
                GameData.flag24 = true;
            }
            else if (flag == 25)
            {
                GameData.flag25 = true;
            }
            else if (flag == 26)
            {
                GameData.flag26 = true;
            }
            else if (flag == 27)
            {
                GameData.flag27 = true;
            }
            else if (flag == 28)
            {
                GameData.flag28 = true;
            }
        }
    }
}
