using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApManager : MonoBehaviour
{
    public HealthBarAp HealthBarAp;
    public GameObject healthBarObj;
    public float speed = 75f;
    public float jumpForce = 20000f;
    public float hp = 250;
    bool stop = false;
    SpriteRenderer mSprite;
    Animator mAnimator;
    Rigidbody2D mRigidbody2D;
    BoxCollider2D boxCollider2D;
    public GameObject Protagonista;
    public GameObject footpositionDx;
    public GameObject footpositionSx;
    public ObjectPoolingManager ObjectPoolingManager;
    int groundLayer = 1 << 8;
    int wallLayer = 1 << 11 | 1 << 12;
    bool bDestroyTimer = false;
    float destroyTimer = 2.0f;

    public bool detected = false;
    Vector2 size = new Vector2(1,1);

    bool Bdrop = false;
    int id = 1;
    int idt = 9;
    public float attackReady = 2f;
    public float reset = 2.0f;
    float timeout = 0.5f;
    public float timecheck = 0.3f;
    public float timerAttack = 2.0f;
    PlayerManager PlayerManager;
    public SerraturaManager serraturaManager;


    enum State
    {
        idle,
        attack1,
        walk,
        jomp,
        startjomp0,
        startjomp1,
        startjomp2,
        death
    }

    ApManager.State m_state = ApManager.State.idle;


    public IEnumerator FlashRed()
    {
        mSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        mSprite.color = Color.white;
    }

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        mAnimator = GetComponent<Animator>();
        mRigidbody2D = GetComponent<Rigidbody2D>();
        mSprite = GetComponent<SpriteRenderer>();
        PlayerManager = GameObject.Find("Protagonista").GetComponent<PlayerManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CheckPositionPlayer
        timecheck -= Time.deltaTime;

        if (timecheck<= 0)
        {
            if(Protagonista.transform.position.x > transform.position.x)
        {
                mSprite.flipX = false;
                timecheck = 0.3f;
        }
        else
        {
                mSprite.flipX = true;
                timecheck = 0.3f;
        }
        }

        if(bDestroyTimer == true)
        {
            destroyTimer -= Time.deltaTime;
        }

        if(destroyTimer <= 0)
        {
            this.gameObject.SetActive(false);
        }
        
        if(destroyTimer <= 0)
        {

        }

        switch (m_state)
        {
            case ApManager.State.idle:

                mAnimator.Play("idle");

                timerAttack -= Time.deltaTime;

                if(timerAttack <= 0)
                {
                    m_state = ApManager.State.walk;
                }
                break;

            case ApManager.State.startjomp0:

                mAnimator.Play("startJomp");

                if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("startJomp") && mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    mRigidbody2D.velocity = new Vector2( 0 , mRigidbody2D.velocity.y + jumpForce);
                    m_state = ApManager.State.jomp;
                }
                break;

            case ApManager.State.startjomp2:

                mAnimator.Play("startJomp");

                if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("startJomp") && mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    mRigidbody2D.velocity = new Vector2(mRigidbody2D.velocity.x + 200, mRigidbody2D.velocity.y + jumpForce);
                    m_state = ApManager.State.jomp;
                }
                break;

            case ApManager.State.startjomp1:

                mAnimator.Play("startJomp");

                if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("startJomp") && mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    mRigidbody2D.velocity = new Vector2(mRigidbody2D.velocity.x - 200, mRigidbody2D.velocity.y + jumpForce);
                    m_state = ApManager.State.jomp;
                }
                break;



            case ApManager.State.jomp:

                timeout -= Time.deltaTime;

                mAnimator.Play("jomp");

                if(timeout <= 0)
                {
                    if (Physics2D.Raycast(footpositionDx.transform.position, Vector2.down, 2f, groundLayer) == true || (Physics2D.Raycast(footpositionSx.transform.position, Vector2.down, 2f, groundLayer) == true))
                    {
                        Debug.Log("ue");
                        m_state = ApManager.State.idle;
                        mRigidbody2D.velocity = Vector2.zero;
                        timeout = 0.5f;
                    }
                }

                break;

            case ApManager.State.walk:

                mAnimator.Play("walk");

                if (mSprite.flipX == false)
                {
                    mRigidbody2D.velocity = speed * Vector2.right;
                }
                else
                {
                    mRigidbody2D.velocity = speed * Vector2.left;
                }

                attackReady -= Time.deltaTime;

                if (hp <= 0)
                {
                    Debug.Log("uora ma minu ueueueueueue");
                    m_state = ApManager.State.death;
                }

                if (attackReady <= 0 && detected)
                {
                    Debug.Log("ue00");
                        attackReady = 3f;
                        m_state = ApManager.State.attack1;
                        mRigidbody2D.velocity = Vector2.zero;
                }

                if (Physics2D.Raycast(footpositionSx.transform.position, Vector2.down, 1f, groundLayer) == false && (Physics2D.Raycast(transform.position, Vector2.left, 16f, wallLayer) == false) && mSprite.flipX == true)
                {
                    m_state = ApManager.State.startjomp1;
                    mRigidbody2D.velocity = Vector2.zero;
                    
                }

                if (Physics2D.Raycast(footpositionDx.transform.position, Vector2.down, 1f, groundLayer) == false && (Physics2D.Raycast(transform.position, Vector2.right, 16f, wallLayer) == false) && mSprite.flipX == false)
                {
                    m_state = ApManager.State.startjomp2;
                    mRigidbody2D.velocity = Vector2.zero;

                }

                if (Physics2D.Raycast(footpositionDx.transform.position, Vector2.down, 1f, groundLayer) == false && (Physics2D.Raycast(transform.position, Vector2.right, 16f, wallLayer) == true) && mSprite.flipX == false)
                {
                    Debug.Log("POGGERS");
                    m_state = ApManager.State.startjomp0;
                    mRigidbody2D.velocity = Vector2.zero;

                }

                if (Physics2D.Raycast(footpositionDx.transform.position, Vector2.down, 1f, groundLayer) == false && (Physics2D.Raycast(transform.position, Vector2.left, 16f, wallLayer) == true) && mSprite.flipX == true)
                {
                    Debug.Log("POGGERS2");
                    m_state = ApManager.State.startjomp0;
                    mRigidbody2D.velocity = Vector2.zero;
                }
                break;

            case ApManager.State.attack1:

                mAnimator.Play("attack1");

                if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("attack1") && mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    Mathf.Clamp(size.x, 1, 8);
                    Mathf.Clamp(size.y, 1, 8);

                    if(stop == false)
                    {
                        size = new Vector2(size.x + Time.deltaTime * 8, size.y + Time.deltaTime * 8);
                        this.transform.localScale = new Vector2(size.x, size.y);
                    }

                    if(size.x >= 8)
                    {
                        reset -= Time.deltaTime;
                        stop = true;
                    }

                    if(reset <= 0)
                    {
                        size = new Vector2(size.x - Time.deltaTime * 12, size.y - Time.deltaTime * 12);
                        this.transform.localScale = new Vector2(size.x, size.y );
                    }

                    if(reset <= 0 && size.x <= 1)
                    {
                        size = new Vector2(1, 1);
                        this.transform.localScale = new Vector2(size.x, size.y);
                        reset = 2.0f;
                        stop = false;
                        m_state = ApManager.State.idle;
                    }
                }
                break;

                case ApManager.State.death:

                mAnimator.Play("death");

                GameData.ApBossDefeated = true;
                serraturaManager.bossBattle = false;
                mRigidbody2D.AddForce(Vector2.up * 500, ForceMode2D.Impulse);
                mRigidbody2D.gravityScale = 35f;
                bDestroyTimer = true;
               
                if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("death") && mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.1f)
                {
                    boxCollider2D.enabled = false;
                    healthBarObj.SetActive(false);
                    GameObject drop = ObjectPoolingManager.GetPooledObject3();
                    drop.GetComponent<DropManager>().GetId(id);
                    drop.GetComponent<DropManager>().Getidt(idt);
                    if (Bdrop == false)
                    {
                        if (drop != null)
                        {
                            drop.transform.position = new Vector2(transform.position.x, transform.position.y);
                            drop.SetActive(true);
                            Bdrop = true;
                        }
                    }
                }
                break;
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "dbpProiettile")
        {
            StartCoroutine(FlashRed());
            HealthBarAp.TakeDamage(collision.GetComponent<DBProiettileManager>().dmg);
        }

        if (collision.tag == "slash")
        {
            StartCoroutine(FlashRed());
            HealthBarAp.TakeDamage(collision.GetComponent<WoodenKatagiManager>().dmg);
        }

        if (collision.tag == "gunBullet")
        {
            StartCoroutine(FlashRed());
            HealthBarAp.TakeDamage(collision.GetComponent<GunBulletManager>().dmg);
        }

        if (collision.tag == "PistolShot")
        {
            StartCoroutine(FlashRed());
            HealthBarAp.TakeDamage(collision.GetComponent<PistolBulletManager>().dmg);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ssgProiettile")
        {
            StartCoroutine(FlashRed());
            HealthBarAp.TakeDamage(collision.GetComponent<SSGProiettileManager>().dmg);
        }

    }


}
