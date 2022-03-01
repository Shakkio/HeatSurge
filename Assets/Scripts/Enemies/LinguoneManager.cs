using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinguoneManager : MonoBehaviour
{
    int groundLayer = 1 << 8 | 1 << 9 | 1 << 10;
    public Animator linguoneAnimator;
    public Rigidbody2D linguoneRigid;
    public SpriteRenderer linguoneSprite;
    public BoxCollider2D linguoneBox;
    LayerMask Enemymask = 1 << 6 | 1 << 11;
    public GameObject warning;
    bool death = false;
    RaycastHit2D playerHit;
    public float range = 64f;
    public float speed = 75f;
    public float hp = 20f;
    public int id = 1;
    bool Bdrop = false;
    public float waitTimer = 10.0f;
    public float walkProc = 15f;
    public Animator linguaAnimatorsx;
    public Animator linguaAnimatordx;
    public GameObject linguasx;
    public GameObject linguadx;
    bool attacksx;
    bool attackdx;
    public Transform footpositionSx;
    public Transform footpositionDx;
    float lickCooldown = 0.75f;


    enum State
    {
        idle,
        walk,
        lick,
        slam,
        flip,
        flip2,
        death
    }

    LinguoneManager.State m_state = LinguoneManager.State.idle;

    public IEnumerator FlashRed()
    {
        linguoneSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        linguoneSprite.color = Color.white;
    }


    void Update()
    {
        if (hp <= 0)
        {
            death = true;
            m_state = LinguoneManager.State.death;
        }

        switch (m_state)
        {
            case LinguoneManager.State.idle:

                if (death == false)
                {
                    linguoneAnimator.Play("Idle");

                    waitTimer -= Time.deltaTime;
                    if (waitTimer < 0)
                    {
                        m_state = LinguoneManager.State.walk;
                        waitTimer = 10.0f;
                        walkProc = 15.0f;
                    }

                        if (linguoneSprite.flipX == true)
                        {
                            playerHit = Physics2D.Raycast(transform.position, Vector2.right, range, Enemymask);
                        }
                        else
                        {
                            playerHit = Physics2D.Raycast(transform.position, Vector2.left, range, Enemymask);
                        }

                        if(lickCooldown < 0 && playerHit)
                        {
                        if (playerHit.collider.gameObject.tag == "Player")
                        {
                            lickCooldown = 0.75f;
                            m_state = LinguoneManager.State.lick;
                        }
                        }

                        if(lickCooldown > 0)
                        {
                        lickCooldown -= Time.deltaTime;
                        }

                    Debug.Log(playerHit);
                }
                break;

            case LinguoneManager.State.lick:

                linguoneAnimator.Play("Lick");
                warning.SetActive(true);

                if (death == false)
                {
                    if (linguoneAnimator.GetCurrentAnimatorStateInfo(0).IsName("Lick") && linguoneAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        if(linguoneSprite.flipX == false)
                        {
                            linguasx.SetActive(true);
                            linguaAnimatorsx.enabled = true;
                            linguaAnimatorsx.Play("Attack");
                            attacksx = true;
                        }
                        else
                        {
                            linguadx.SetActive(true);
                            linguaAnimatordx.enabled = true;
                            linguaAnimatordx.Play("Attack");
                            attackdx = true;
                        }
                        
                    }

                    if(attacksx)
                    if (linguaAnimatorsx.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        linguaAnimatorsx.enabled = false;
                        linguasx.SetActive(false);
                        m_state = LinguoneManager.State.idle;
                        warning.SetActive(false);
                        attacksx = false;
                    }

                    if(attackdx)
                        if (linguaAnimatordx.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                        {
                            linguaAnimatordx.enabled = false;
                            linguadx.SetActive(false);
                            m_state = LinguoneManager.State.idle;
                            warning.SetActive(false);
                            attackdx = false;
                            Debug.Log("rest of life");
                        }
                }
                break;


            case LinguoneManager.State.walk:


                if (death == false)
                {
                    linguoneAnimator.Play("Walk");

                    walkProc -= Time.deltaTime;

                    if(walkProc > 0)
                    { 
                    if (linguoneSprite.flipX == false)
                    {
                        linguoneRigid.velocity = speed * Vector2.left;
                        if (Physics2D.Raycast(footpositionSx.position, Vector2.down, 1f, groundLayer) == false)
                        {
                            linguoneRigid.velocity = Vector2.zero;
                            m_state = LinguoneManager.State.flip;
                        }
                    }
                    else if (linguoneSprite.flipX == true)
                    {
                        linguoneRigid.velocity = speed * Vector2.right;

                        if (Physics2D.Raycast(footpositionDx.position, Vector2.down, 1f, groundLayer) == false)
                        {
                                linguoneRigid.velocity = Vector2.zero;
                            m_state = LinguoneManager.State.flip2;
                        }
                    }
                    }
                    else if (walkProc <= 0)
                    {
                        waitTimer = 10.0f;
                        linguoneRigid.velocity = Vector2.zero;
                        m_state = LinguoneManager.State.idle;
                    }
                }
                break;

            case LinguoneManager.State.flip:


                if (death == false)
                {
                    linguoneSprite.flipX = true;
                    linguoneAnimator.Play("Flip");
                    if (linguoneAnimator.GetCurrentAnimatorStateInfo(0).IsName("Flip") && linguoneAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                    {
                        if (walkProc >= 0)
                        {
                            m_state = LinguoneManager.State.walk;
                        }
                        else
                        {
                            m_state = LinguoneManager.State.idle;
                        }
                    }
                }
                break;

            case LinguoneManager.State.flip2:

                if (death == false)
                {
                    linguoneSprite.flipX = false;
                    linguoneAnimator.Play("Flip");
                    if (linguoneAnimator.GetCurrentAnimatorStateInfo(0).IsName("Flip") && linguoneAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                    {
                        if (walkProc >= 0)
                        {
                            m_state = LinguoneManager.State.walk;
                        }
                        else
                        {
                            m_state = LinguoneManager.State.idle;
                        }
                    }
                }
                break;

            case LinguoneManager.State.death:

                warning.SetActive(false);
                linguasx.SetActive(false);
                linguadx.SetActive(false);
                linguoneRigid.velocity = Vector2.zero;
                linguoneAnimator.Play("Death");
                this.gameObject.tag = "innocuo";

                if (linguoneAnimator.GetCurrentAnimatorStateInfo(0).IsName("Death") && linguoneAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5)
                {
                    linguoneRigid.gravityScale = 100f;
                    linguoneRigid.mass = 100f;
                    linguoneBox.enabled = false;
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
            waitTimer -= 2f;
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<DBProiettileManager>().dmg;
        }

        if (collision.tag == "slash")
        {
            waitTimer -= 2f;
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<WoodenKatagiManager>().dmg;
        }

        if (collision.tag == "gunBullet")
        {
            waitTimer -= 2f;
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<GunBulletManager>().dmg;
        }

        if (collision.tag == "PistolShot")
        {
            waitTimer -= 2f;
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<PistolBulletManager>().dmg;
        }
    }

    private void OnDrawGizmos()
    {
        if (linguoneSprite.flipX == true)
        {
            Gizmos.DrawRay(transform.position, Vector3.right * range);
        }
        else
        {
            Gizmos.DrawRay(transform.position, Vector3.left * range);
        }

    }
}
