using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmbraManager : MonoBehaviour
{
    public GameObject AimDetection;
    public GameObject armaCanna;
    public GameObject arma;
    public Animator ombraAnimator;
    public BoxCollider2D ombraBox;
    public SpriteRenderer ombraSprite;
    public SpriteRenderer armaSprite;
    public ObjectPoolingManager ObjectPoolingManager;
    public AimDetectionManager aimDetectionManager;
    public GameObject Player;
    public SetUpManager SetUpManager;
    GameObject selectedPlatform;
    int index;
    public bool detected = false;
    public int id = 2;
    int i = -99;
    bool Bdrop = false;
    bool death = false;
    bool trovato = false;
    bool disoccupazione;

    float disappearTimer = 3.0f;
    float shadowCounter = 0;
    float attackspeed = 1f;
    public float hp = 8f;
    LayerMask enemyMask = 1 << 6;

    enum State
    {
        idle,
        disappear,
        appear,
        death,
        aim
    }

    public IEnumerator FlashRed()
    {
        ombraSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        ombraSprite.color = Color.white;
    }


    OmbraManager.State m_state = OmbraManager.State.idle;

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            death = true;
            m_state = OmbraManager.State.death;
        }

        if (Physics2D.Raycast(transform.position, Vector2.down, 99) == false)
        {
            m_state = OmbraManager.State.disappear;
        }


        switch (m_state)
        {
            case OmbraManager.State.idle:

                ombraAnimator.Play("idle");
                arma.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                armaSprite.flipX = false;
                armaSprite.flipY = false;
                ombraSprite.flipX = false;


                if (detected == true)
                {
                    m_state = OmbraManager.State.aim;
                }
                break;



            case OmbraManager.State.aim:

                ombraAnimator.Play("aim");

                if (death == false)
                {
                    Vector3 toTargetVector = Player.transform.position - transform.position;
                    float zRotation = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;
                    arma.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));


                    if (zRotation > 90 || zRotation < -90)
                    {
                        armaSprite.flipY = true;
                        ombraSprite.flipX = true;
                    }
                    else
                    {
                        armaSprite.flipY = false;
                        ombraSprite.flipX = false;
                    }

                    attackspeed -= Time.deltaTime;

                    if (shadowCounter == 3)
                    {
                        m_state = OmbraManager.State.disappear;
                        shadowCounter = 0;
                    }



                    if (attackspeed <= 0)
                    {

                        GameObject bullet = ObjectPoolingManager.SharedInstance.GetPooledObject5();
                        Vector2 ArmaDirection = arma.transform.right;

                        if (bullet != null)
                        {
                            bullet.GetComponent<ShadowShot>().shadowShot(ArmaDirection);
                            bullet.transform.position = armaCanna.transform.position;
                            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
                            bullet.SetActive(true);
                        }
                        attackspeed = 1.0f;
                        shadowCounter += 1;

                    }
                }
                break;

            case OmbraManager.State.disappear:
                {
                    arma.SetActive(false);
                    ombraAnimator.Play("disappear");
                    disappearTimer -= Time.deltaTime;
                    ombraBox.enabled = false;
                    Debug.Log(SetUpManager.platforms[1].GetBusy());

                    if(disoccupazione == false && i != -99)
                    {
                        SetUpManager.platforms[i].SetBusy(false);
                        disoccupazione = true;
                    }

                    if (ombraAnimator.GetCurrentAnimatorStateInfo(0).IsName("disappear") && ombraAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        ombraSprite.enabled = false;
                    }

                        while(trovato == false)
                        {
                            i = Random.Range(0, SetUpManager.platforms.Count);
                            if (SetUpManager.platforms[i].GetBusy() == false)
                            {
                                SetUpManager.platforms[i].SetBusy(true);
                                trovato = true;
                            }
                            else
                            {
                                return;
                            }
                        }
                        
                    if (disappearTimer < 0 && trovato)
                    {
                        trovato = false;
                        m_state = OmbraManager.State.appear;
                        disappearTimer = 1.0f;
                        transform.position = new Vector2(SetUpManager.platforms[i].GetTransform().position.x, SetUpManager.platforms[i].GetTransform().position.y + 17);
                    }

                    break;
                }

            case OmbraManager.State.appear:
                {
                    ombraSprite.enabled = true;
                    disoccupazione = false;
                    ombraAnimator.Play("reappear");

                    if (ombraAnimator.GetCurrentAnimatorStateInfo(0).IsName("reappear") && ombraAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        arma.SetActive(true);
                        ombraBox.enabled = true;
                        m_state = OmbraManager.State.idle;
                    }
                }
                break;

            case OmbraManager.State.death:

                ombraAnimator.Play("death");
                arma.SetActive(false);
                this.gameObject.tag = "innocuo";
                if(i != -99)
                {
                    SetUpManager.platforms[i].SetBusy(false);
                }
                
                if (ombraAnimator.GetCurrentAnimatorStateInfo(0).IsName("death") && ombraAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    if (Bdrop == false)
                    {
                        GameObject drop = ObjectPoolingManager.SharedInstance.GetPooledObject3();
                        drop.GetComponent<DropManager>().GetId(id);
                        if (drop != null)
                        {
                            drop.transform.position = new Vector2(transform.position.x, transform.position.y);
                            drop.SetActive(true);
                            Bdrop = true;
                        }
                    }
                    Destroy(AimDetection);
                    Destroy(this.gameObject);
                }
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ssgProiettile")
        {
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<SSGProiettileManager>().dmg;
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "dbpProiettile")
        {
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<DBProiettileManager>().dmg;
        }

        if (collision.tag == "slash")
        {
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<WoodenKatagiManager>().dmg;
        }

        if (collision.tag == "gunBullet")
        {
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<GunBulletManager>().dmg;
        }

        if (collision.tag == "PistolShot")
        {
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<PistolBulletManager>().dmg;
        }
    }

    
}
