using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHeadManager : MonoBehaviour
{
    public Animator dragonAnimator;
    public Rigidbody2D dragonRigid;
    public SpriteRenderer dragonSprite;
    public BoxCollider2D dragonBox;
    public float flipTimer = 7.0f;
    LayerMask Enemymask = 1 << 6 | 1 << 9 | 1 << 8;
    public ObjectPoolingManager ObjectPoolingManager;
    float confusedTimer = 5f;
    bool attacking = false;
    bool slam = false;
    bool death = false;
    RaycastHit2D playerHit;
    float range = 256f;
    float speed = 250f;
    public float hp = 50f;
    public bool damaged = false;
    public bool redamaged = false;
    public float damagetimer = 1.0f;
    


    enum State
    {
        idle,
        attack,
        confused,
        slam,
        flip,
        flip2,
        recover,
        death
    }

    DragonHeadManager.State m_state = DragonHeadManager.State.idle;


    public IEnumerator FlashRed()
    {
        dragonSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        dragonSprite.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(attacking);


        if(hp <= 0)
        {
            death = true;
            m_state = DragonHeadManager.State.death;
        }


        if (death == false)
        {
            if (slam)
            {
                m_state = DragonHeadManager.State.slam;
            }
        }


        switch (m_state)
        {
            
            case DragonHeadManager.State.idle:

                dragonAnimator.Play("idle");
                this.gameObject.tag = "Enemy";
                if (dragonSprite.flipX == false)
                {
                    playerHit = Physics2D.Raycast(transform.position, Vector2.right, range, Enemymask);
                }
                else
                {
                    playerHit = Physics2D.Raycast(transform.position, Vector2.left, range, Enemymask);
                }
                   
                if (playerHit && playerHit.collider.gameObject.tag == "Player")
                {
                    m_state = DragonHeadManager.State.attack;
                    attacking = true;
                    flipTimer = 0.5f;
                }

                if(damaged && redamaged == false)
                {
                    redamaged = true;
                    flipTimer -= 7.0f;
                }

                if(redamaged == true)
                {
                    damagetimer -= Time.deltaTime;

                    if(damagetimer <= 0)
                    {
                        redamaged = false;
                        damagetimer = 1.0f;
                    }
                }


                flipTimer -= Time.deltaTime;

                if (flipTimer <= 0)
                {
                    if(dragonSprite.flipX == false)
                    {
                        m_state = DragonHeadManager.State.flip;
                        damaged = false;
                    }
                    else
                    {
                        m_state = DragonHeadManager.State.flip2;
                        damaged = false;
                    }
                    flipTimer = 7.0f;
                }
           break;

                case DragonHeadManager.State.attack:


                if (death == false)
                {
                    dragonAnimator.Play("attack");
                }
                if(dragonSprite.flipX == false)
                {
                    dragonRigid.velocity = Vector2.right * speed;
                }
                else
                {
                    dragonRigid.velocity = Vector2.left * speed;
                }

                dragonBox.size = new Vector2(31, 18);
                

                attacking = true;
                break;

            case DragonHeadManager.State.flip:


                if (death == false)
                {
                    dragonAnimator.Play("flip");
                } 
                if (dragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("flip") && dragonAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f )
                {
                    dragonSprite.flipX = true;

                    if (dragonAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        m_state = DragonHeadManager.State.idle;
                    }
                }
                break;

            case DragonHeadManager.State.flip2:

                if (death == false)
                {
                    dragonAnimator.Play("flip");
                }
                if (dragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("flip") && dragonAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f)
                {
                    dragonSprite.flipX = false;

                    if (dragonAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        m_state = DragonHeadManager.State.idle;
                    }
                }
                break;

            case DragonHeadManager.State.slam:
                dragonBox.size = new Vector2(31, 19);
                if (death == false) { dragonAnimator.Play("slam"); }
                if (dragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("slam") && dragonAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    slam = false;
                    m_state = DragonHeadManager.State.confused;
                }
                break;

            case DragonHeadManager.State.confused:

                this.gameObject.tag = "innocuo";
                if (death == false)
                {
                    dragonAnimator.Play("confused");
                }
                confusedTimer -= Time.deltaTime;
                if (confusedTimer <= 0)
                {
                    confusedTimer = 5.0f;
                    m_state = DragonHeadManager.State.recover;
                }
                break;

            case DragonHeadManager.State.recover:

                if (death == false)
                {
                    dragonAnimator.Play("recover");
                }
                if (dragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("recover") && dragonAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    m_state = DragonHeadManager.State.idle;
                }
                break;

            case DragonHeadManager.State.death:

                dragonRigid.velocity = Vector2.zero;
                dragonAnimator.Play("death");
                this.gameObject.tag = "innocuo";

                if (dragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("death") && dragonAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5)
                {
                    dragonRigid.gravityScale = 600f;
                    dragonRigid.mass = 100f;
                }

                if(Physics2D.Raycast(transform.position, Vector2.down, 10))
                {
                    dragonRigid.gravityScale = 0f;
                    dragonBox.enabled = false;
                }
                break;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(attacking)
        {
            if(collision.collider.tag == "Wall")
            {
                attacking = false;
                slam = true;
            }
        }

    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ssgProiettile")
        {
            StartCoroutine(FlashRed());
            damaged = true;
            hp -= collision.GetComponent<SSGProiettileManager>().dmg;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "dbpProiettile")
        {
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<DBProiettileManager>().dmg;
            damaged = true;
        }

        if (collision.tag == "slash")
        {
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<WoodenKatagiManager>().dmg;
            damaged = true;
        }

        if (collision.tag == "gunBullet")
        {
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<GunBulletManager>().dmg;
            damaged = true;
        }

        if (collision.tag == "PistolShot")
        {
            StartCoroutine(FlashRed());
            hp -= collision.GetComponent<PistolBulletManager>().dmg;
            damaged = true;
        }
    }

    private void OnDrawGizmos()
    {
        if(dragonSprite.flipX == false)
        {
            Gizmos.DrawRay(transform.position, Vector3.right * range);
        }
        else
        {
            Gizmos.DrawRay(transform.position, Vector3.left * range);
        }
       
    }
}
