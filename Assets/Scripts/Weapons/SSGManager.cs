using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSGManager : MonoBehaviour
{
    //varie
    public GameObject mirinoSSG;
    public GameObject SSGcanna;
    public GestioneEquipManager GestioneEquipManager;
    public PlayerManager PlayerManager;
    Vector3 mousePos;
    public SpriteRenderer spriteTorso;
    public ReloadSystemManager ReloadSystemManager;

    //Componenti
    public Animator ssgAnimator;
    public SpriteRenderer ssgSprite;
    public bool Ready2shoot = true;
    bool UnColpo;
    bool isCharging;
    bool TheFrame;
    public static bool isReloading;
    public float power = 250f;
    public float maxChargingtime = 1.0f;
    float theframeTime = 0.1f;
    float chargingTime = 1.0f;

    private void Awake()
    {
        isReloading = false;
    }

    void Start()
    {

        mirinoSSG = GestioneEquipManager.mirinoCorrente;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.gameisPaused == false)
        {
            //setupMouse
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mirinoSSG.transform.position = new Vector3(mousePos.x, mousePos.y, 0.0f);
            Vector3 toTargetVector = mirinoSSG.transform.position - transform.position;
            float zRotation = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));

            //Arma e Torso che devono stare sani
            if (zRotation > 90 || zRotation < -90)
            {
                ssgSprite.flipY = true;
                spriteTorso.flipX = true;
            }
            else
            {
                ssgSprite.flipY = false;
                spriteTorso.flipX = false;
            }

            if (Ready2shoot)
            {
                ssgAnimator.Play("Hold");
                if (Input.GetMouseButtonDown(0))
                {
                    GestioneEquipManager.Impegnato = true;
                    Ready2shoot = false;
                    isCharging = true;
                }
            }

            if (isCharging)
            {
                ssgAnimator.Play("Loading");
                chargingTime -= Time.deltaTime;
                if (chargingTime <= 0)
                {
                    isCharging = false;
                    chargingTime = maxChargingtime;
                    TheFrame = true;
                    UnColpo = true;
                }
            }

            if (TheFrame)
            {
                if (UnColpo)
                {
                    GameObject bullet = ObjectPoolingManager.SharedInstance.GetPooledObject();
                    Vector2 SSGdirection = this.gameObject.transform.right;
                    bullet.GetComponent<SSGProiettileManager>().SSGShot(SSGdirection);
                    if (bullet != null)
                    {
                        Debug.Log("uora ma minu ueue");
                        bullet.transform.position = SSGcanna.transform.position;
                        bullet.SetActive(true);
                        UnColpo = false;
                        PlayerManager.Spinta(power, -SSGdirection);
                    }
                }

                theframeTime -= Time.deltaTime;
                ssgAnimator.Play("TheFrame");
                if (theframeTime <= 0)
                {
                    GestioneEquipManager.Impegnato = false;
                    TheFrame = false;
                    isReloading = true;
                    theframeTime = 0.1f;
                }
            }

            if (isReloading)
            {
                ssgAnimator.Play("Reloading");
            }

            if (ReloadSystemManager.ssgReloaded)
            {
                Ready2shoot = true;
                ReloadSystemManager.ssgReloaded = false;
            }
        }
    }
}
