using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    //varie
    public GameObject mirinoGun;
    public GameObject Guncanna;
    public GestioneEquipManager GestioneEquipManager;
    public PlayerManager PlayerManager;
    Vector3 mousePos;
    public SpriteRenderer spriteTorso;
    bool UnColpo = true;

    //Componenti
    public Animator GunAnimator;
    public SpriteRenderer GunSprite;
    public bool Ready2shoot = true;
    bool TheFrame;
    public float power = 50f;
    float theframeTime = 0.1f;

    void Start()
    {
        mirinoGun = GestioneEquipManager.mirinoCorrente;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.gameisPaused == false)
        { 
        //setupMouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mirinoGun.transform.position = new Vector3(mousePos.x, mousePos.y, 0.0f);
        Vector3 toTargetVector = mirinoGun.transform.position - transform.position;
        float zRotation = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));

        //Arma e Torso che devono stare sani
        if (zRotation > 90 || zRotation < -90)
        {
            GunSprite.flipY = true;
            spriteTorso.flipX = true;
        }
        else
        {
            GunSprite.flipY = false;
            spriteTorso.flipX = false;
        }

        if (Ready2shoot)
        {
            GunAnimator.Play("Hold");
            if(GameData.gunAmmo > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameData.gunAmmo -= 1;
                    Ready2shoot = false;
                    TheFrame = true;
                }
            }
        }

        if (TheFrame)
        {
            GunAnimator.Play("Shoot");
            if (UnColpo)
            {
                GameObject bullet = ObjectPoolingManager.SharedInstance.GetPooledObject4();
                Vector2 Gundirection = this.gameObject.transform.right;
                if (bullet != null)
                {
                    bullet.GetComponent<GunBulletManager>().gunShot(Gundirection);
                    bullet.transform.position = Guncanna.transform.position;
                    bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
                    bullet.SetActive(true);
                    PlayerManager.SpintaGun(power, -Gundirection);
                    UnColpo = false;
                }
            }

            theframeTime -= Time.deltaTime;

            if(theframeTime <= 0)
            {
                UnColpo = true;
                Ready2shoot = true;
                TheFrame = false;
            }

        }
        }
    }
}