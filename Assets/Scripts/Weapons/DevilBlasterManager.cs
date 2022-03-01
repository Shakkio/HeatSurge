using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBlasterManager : MonoBehaviour
{
    //Base
    public GameObject mirinodevil;
    public GestioneEquipManager GestioneEquipManager;
    Vector3 mousePos;
    public SpriteRenderer spriteTorso;
    public SpriteRenderer devilBlasterSprite;

    //DevilBlasterSpecific
    bool Ready2Shoot = true;
    public GameData GameData;
    bool TheFrame;
    float theframeTimer = 0.3f;
    public Animator blasterAnimator;
    public GameObject devilCanna1;
    public GameObject devilCanna2;
    PlayerManager PlayerManager;

    private void Awake()
    {
        PlayerManager = GameObject.Find("Protagonista").GetComponent<PlayerManager>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.gameisPaused == false)
        {
            //setupMouse
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mirinodevil.transform.position = new Vector3(mousePos.x, mousePos.y, 0.0f);
            Vector3 toTargetVector = mirinodevil.transform.position - transform.position;
            float zRotation = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));

            //Arma e Torso che devono stare sani
            if (zRotation > 90 || zRotation < -90)
            {
                devilBlasterSprite.flipY = true;
                spriteTorso.flipX = true;
            }
            else
            {
                devilBlasterSprite.flipY = false;
                spriteTorso.flipX = false;
            }


            if (Ready2Shoot && GameData.devilblasterRepaired == false)
            {
                blasterAnimator.Play("DevilBlasterBroken");
                if (GameData.devilblasterAmmo > 1 && Input.GetMouseButtonDown(0))
                {
                    Vector2 devildirection = this.gameObject.transform.right;

                    GameObject bullet = ObjectPoolingManager.SharedInstance.GetPooledObject2();

                    bullet.GetComponent<DBProiettileManager>().devilShot1(devildirection);
                    if (bullet != null)
                    {
                        Debug.Log("fozza napoli");
                        bullet.transform.position = devilCanna1.transform.position;
                        bullet.SetActive(true);
                    }

                    GameObject bullet2 = ObjectPoolingManager.SharedInstance.GetPooledObject2();

                    bullet2.GetComponent<DBProiettileManager>().devilShot2(devildirection);
                    if (bullet2 != null)
                    {
                        Debug.Log("viva fesu");
                        bullet2.transform.position = devilCanna2.transform.position;
                        bullet2.SetActive(true);
                    }

                    GameData.devilblasterAmmo -= 2;
                    Ready2Shoot = false;
                    TheFrame = true;
                }
            }

            if (TheFrame && GameData.devilblasterRepaired == false)
            {
                //Spara


                blasterAnimator.Play("DevilBlasterBrokenShooting");
                theframeTimer -= Time.deltaTime;
                if (theframeTimer < 0)
                {
                    Debug.Log("oh");
                    theframeTimer = 0.3f;
                    TheFrame = false;
                    Ready2Shoot = true;
                }
            }

            if (Ready2Shoot && GameData.devilblasterRepaired == true)
            {
                blasterAnimator.Play("DevilBlasterSane");
                if (GameData.devilblasterAmmo > 1 && Input.GetMouseButtonDown(0))
                {
                    Vector2 devildirection = this.gameObject.transform.right;

                    GameObject bullet = ObjectPoolingManager.SharedInstance.GetPooledObject2();

                    bullet.GetComponent<DBProiettileManager>().devilShot1(devildirection);
                    if (bullet != null)
                    {
                        Debug.Log("uora ma minu ueue");
                        bullet.transform.position = devilCanna1.transform.position;
                        bullet.SetActive(true);
                    }

                    GameObject bullet2 = ObjectPoolingManager.SharedInstance.GetPooledObject2();

                    bullet2.GetComponent<DBProiettileManager>().devilShot1(devildirection);
                    if (bullet2 != null)
                    {
                        Debug.Log("uora ma minu ueue");
                        bullet2.transform.position = devilCanna2.transform.position;
                        bullet2.SetActive(true);
                    }
                    //Spara
                    GameData.devilblasterAmmo -= 2;
                    Ready2Shoot = false;
                    TheFrame = true;
                }
            }



            if (TheFrame && GameData.devilblasterRepaired == true)
            {

                blasterAnimator.Play("DevilBlasterSaneShooting");

                theframeTimer -= Time.deltaTime;
                if (theframeTimer < 0)
                {
                    theframeTimer = 0.1f;
                    TheFrame = false;
                    Ready2Shoot = true;
                }
            }
        }
    }
}
