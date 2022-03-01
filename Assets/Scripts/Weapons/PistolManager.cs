using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolManager : MonoBehaviour
{
    public GameObject mirinopistol;
    public GameObject Canna;
    public GestioneEquipManager GestioneEquipManager;
    Vector3 mousePos;
    public SpriteRenderer spriteTorso;
    public SpriteRenderer pistolSprite;

    bool Ready2Shoot = true;
    public GameData GameData;
    bool TheFrame;
    float theframeTimer = 0.5f;
    public Animator PistolAnimator;
    PlayerManager PlayerManager;

    private void Awake()
    {
        PlayerManager = GameObject.Find("Protagonista").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.gameisPaused == false)
        {
            //setupMouse
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mirinopistol.transform.position = new Vector3(mousePos.x, mousePos.y, 0.0f);
            Vector3 toTargetVector = mirinopistol.transform.position - transform.position;
            float zRotation = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));

            //Arma e Torso che devono stare sani
            if (zRotation > 90 || zRotation < -90)
            {

                pistolSprite.flipY = true;
                spriteTorso.flipX = true;
            }
            else
            {
                pistolSprite.flipY = false;
                spriteTorso.flipX = false;
            }

            if (Ready2Shoot)
            {
                PistolAnimator.Play("hold");

                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 pistoldirection = this.gameObject.transform.right;

                    GameObject bullet = ObjectPoolingManager.SharedInstance.GetPooledObject6();

                    bullet.GetComponent<PistolBulletManager>().PistolShot(pistoldirection);
                    if (bullet != null)
                    {
                        Debug.Log("fozza napoli");
                        bullet.transform.position = Canna.transform.position;
                        bullet.SetActive(true);
                    }

                    Ready2Shoot = false;
                    TheFrame = true;
                }
            }

            if (TheFrame)
            {
                PistolAnimator.Play("shoot");

                theframeTimer -= Time.deltaTime;
                if (theframeTimer < 0)
                {
                    Debug.Log("oh");
                    theframeTimer = 0.3f;
                    TheFrame = false;
                    Ready2Shoot = true;
                }
            }
        }
    }
}

