using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenKatagiManager : MonoBehaviour
{
    public float dmg = 7f;
    public float power = 50f;
    public SpriteRenderer katagiSprite;
    public SpriteRenderer spriteTorso;
    public GameObject katagiMirino;
    public Animator katagiAnimator;
    public BoxCollider2D katagiCollider;
    Vector2 mousePos;
    public Rigidbody2D McRigid;
    public PlayerManager PlayerManager;

    bool Ready2Shoot = true;
    bool theFrame = false;
    bool groundAnimation = false;
    bool airAnimation = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.gameisPaused == false)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            katagiMirino.transform.position = new Vector3(mousePos.x, mousePos.y, 0.0f);
            Vector3 toTargetVector = katagiMirino.transform.position - transform.position;

            if (Input.mousePosition.x < Screen.width / 2)
            {
                katagiSprite.flipX = true;
                spriteTorso.flipX = true;
            }
            else if (Input.mousePosition.x > Screen.width / 2)
            {
                katagiSprite.flipX = false;
                spriteTorso.flipX = false;
            }


            if (Ready2Shoot)
            {
                katagiAnimator.Play("Hold");
                if (Input.GetMouseButtonDown(0))
                {
                    GestioneEquipManager.Impegnato = true;
                    Ready2Shoot = false;
                    theFrame = true;
                }
                airAnimation = false;
                groundAnimation = false;
            }
            else if (theFrame == true)
            {
                if (McRigid.velocity.y == 0)
                {
                    groundAnimation = true;
                    PlayerManager.Spinta(power, toTargetVector.normalized);
                }
                else
                {
                    airAnimation = true;
                    PlayerManager.Spinta(power, toTargetVector.normalized);
                }

                theFrame = false;
            }

            if (groundAnimation)
            {
                katagiAnimator.Play("onGround");


                if (katagiAnimator.GetCurrentAnimatorStateInfo(0).IsName("onGround") && katagiAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.25f)
                {
                    katagiCollider.enabled = true;
                    if (katagiSprite.flipX == false)
                    {
                        katagiCollider.offset = new Vector2(15, 4);
                    }
                    else
                    {
                        katagiCollider.offset = new Vector2(-15, 4);
                    }
                }
                else
                {
                    katagiCollider.enabled = false;
                }

                if (katagiAnimator.GetCurrentAnimatorStateInfo(0).IsName("onGround") && katagiAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    Ready2Shoot = true;
                    GestioneEquipManager.Impegnato = false;
                }
            }
            else if (airAnimation)
            {
                katagiAnimator.Play("onAir");

                if (katagiAnimator.GetCurrentAnimatorStateInfo(0).IsName("onAir") && katagiAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.25f)
                {
                    katagiCollider.enabled = true;
                    if (katagiSprite.flipX == false)
                    {
                        katagiCollider.offset = new Vector2(15, 4);
                    }
                    else
                    {
                        katagiCollider.offset = new Vector2(-15, 4);
                    }
                }
                else
                {
                    katagiCollider.enabled = false;
                }

                if (katagiAnimator.GetCurrentAnimatorStateInfo(0).IsName("onAir") && katagiAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    Ready2Shoot = true;
                    GestioneEquipManager.Impegnato = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "innocuo")
        {
            Debug.Log("incredibile");
        }

    }
}
