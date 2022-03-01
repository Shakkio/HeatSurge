using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDischargeManager : MonoBehaviour
{

    public float dmg = 0.1f;
    public SpriteRenderer DischargeSprite;
    public SpriteRenderer spriteTorso;
    public GameObject DischargeMirino;
    public Animator DischargeAnimator;
    public Animator corpoAnimator;
    public Rigidbody2D mcRigid;
    public GameObject fireCircle;
    Vector2 mousePos;
    PlayerManager PlayerManager;

    float chargingtimer = 1f;
    bool Bdischarge = false;
    bool charging = false;

    bool Ready2Shoot = true;

    private void Awake()
    {
        PlayerManager = GameObject.Find("Protagonista").GetComponent<PlayerManager>();
    }

    void Update()
    {
        if (PlayerManager.gameisPaused == false)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            DischargeMirino.transform.position = new Vector3(mousePos.x, mousePos.y, 0.0f);
            Vector3 toTargetVector = DischargeMirino.transform.position - transform.position;
            Debug.Log(mousePos.normalized);

            if (charging == false && Bdischarge == false)
            {
                if (Input.mousePosition.x < Screen.width / 2)
                {
                    DischargeSprite.flipX = true;
                    spriteTorso.flipX = true;
                }
                else if (Input.mousePosition.x > Screen.width / 2)
                {
                    DischargeSprite.flipX = false;
                    spriteTorso.flipX = false;
                }
            }


            if (Ready2Shoot)
            {
                DischargeAnimator.Play("Hold");
                if (Input.GetMouseButtonDown(0))
                {
                    GestioneEquipManager.Impegnato = true;
                    Ready2Shoot = false;
                    charging = true;
                }
            }
            else if (charging == true)
            {
                mcRigid.velocity = Vector2.zero;
                PlayerManager.Occupato = true;
                PlayerManager.corpoAnimatorOccupato = true;
                mcRigid.gravityScale = 0;
                DischargeAnimator.Play("Charge");
                corpoAnimator.Play("Corpo_FireCharge");
                chargingtimer -= Time.deltaTime;
                fireCircle.SetActive(true);
                if (chargingtimer <= 0)
                {

                    charging = false;
                    Bdischarge = true;
                    chargingtimer = 1f;
                }
            }
            else if (Bdischarge == true)
            {
                Debug.Log("Discharge");
                DischargeAnimator.Play("Discharge");
                corpoAnimator.Play("Corpo_FireDischarging");
                fireCircle.SetActive(false);

                if (DischargeAnimator.GetCurrentAnimatorStateInfo(0).IsName("Discharge") && DischargeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    mcRigid.gravityScale = 100;
                    PlayerManager.Occupato = false;
                    PlayerManager.corpoAnimatorOccupato = false;
                    GestioneEquipManager.Impegnato = false;
                    Bdischarge = false;
                    Ready2Shoot = true;
                }
            }
        }
    }
}
