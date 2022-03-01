using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //Miscellaneous
    bool Mainmenu = false;
    int groundLayer = 1 << 8 | 1 << 9 | 1 << 10;
    int effectorLayer = 1 << 9;
    RaycastHit2D hit;
    RaycastHit2D hit2;
    bool effectordone = false;
    Vector2 footpositionSx;
    Vector2 footpositionDx;
    float effectorCollidertimer = 0.2f;
    public static bool Occupato = false;
    public int PlatformId = 1;
    public bool gameisPaused = false;
    public GameObject PauseonCanvas;

    //stats
    public float speed;
    public float jumpForce;
    bool canjump;
    bool crouch;
    bool crouching;
    public static bool dying;
    bool spinta;
    float m_power = 0;
    Vector2 m_direction;
    public float resetPower = 2f;

    //componenti
    public GameData GameData;
    public GameObject Piedi;
    public Rigidbody2D Rigidbody;
    public BoxCollider2D boxCollider2D;
    public BoxCollider2D gambeBoxCollider2D;
    public Animator corpoAnimator;
    public Animator gambeAnimator;
    public Animator armaAnimator;
    public SpriteRenderer spriteCorpo;
    public SpriteRenderer spriteArma;
    public SpriteRenderer spriteGambe;
    public GestioneEquipManager GestioneEquipManager;
    public CheckPointManager CheckPointManager;
    public static bool corpoAnimatorOccupato = false;

    public Animator Mc;
    public Animator Mc2;
    public Animator transition;
    public float transitionTime = 1;

    private void Awake()
    {
        corpoAnimatorOccupato = false;
        GestioneEquipManager.Impegnato = false;
        GestioneEquipManager.Indaffarato = false;
        Reposition();
    }

    void Start()
    {

    }

    enum State
    {
        idle,
        walk,
        jump,
        crouch,
        death
    }

    PlayerManager.State m_state = PlayerManager.State.idle;


    // Update is called once per frame
    void Update()
    {
        footpositionSx = new Vector2(Piedi.transform.position.x - 5, Piedi.transform.position.y - 9);
        footpositionDx = new Vector2(Piedi.transform.position.x + 5, Piedi.transform.position.y - 9);

        if (Mainmenu == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameisPaused = !gameisPaused;
                PauseGame(gameisPaused);
            }
        
        

        if (Occupato == false && gameisPaused == false)
        {
            //Jump
            if (crouching == false)
            {
                if (canjump)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Rigidbody.velocity.y + jumpForce);
                    }
                }
            }


            //crouch
            if (Rigidbody.velocity == Vector2.zero)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    crouching = true;
                }
                else
                {
                    crouching = false;
                }
            }

            //Walk
            Rigidbody.velocity = new Vector2 (Input.GetAxis("Horizontal") * speed + m_power * m_direction.x, Rigidbody.velocity.y);

        if(spinta)
        {
                m_power -= resetPower;

                if (m_direction.x > 0)
                {
                    if(m_power * m_direction.x < 0)
                    {
                        m_power = 0;
                        spinta = false;
                    }
                }

                if (m_direction.x < 0 )
                {
                    if (m_power * m_direction.x > 0)
                    {
                        spinta = false;
                        m_power = 0;
                    }
                }
        }

        //GroundDetection
        if (Physics2D.Raycast(footpositionSx, Vector2.down, 1f, groundLayer) || Physics2D.Raycast(footpositionDx, Vector2.down, 1f, groundLayer))
        {
            canjump = true;
        }
        else
        {
            canjump = false;
        }

        //effectorDetection
        if (Physics2D.Raycast(footpositionSx, Vector2.down, 1f, effectorLayer) || Physics2D.Raycast(footpositionDx, Vector2.down, 1f, effectorLayer))
        {
            if (crouching)
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    hit = Physics2D.Raycast(footpositionSx, Vector2.down, 1f, effectorLayer);
                    hit2 = Physics2D.Raycast(footpositionDx, Vector2.down, 1f, effectorLayer);
                    if (hit)
                    {
                        hit.collider.GetComponent<BoxCollider2D>().enabled = false;
                        effectordone = true;
                    }
                    else if (hit2)
                    {
                        hit2.collider.GetComponent<BoxCollider2D>().enabled = false;
                        effectordone = true;
                    }
                }
        }

                //effectorReset
                if (effectordone)
        {
            effectorCollidertimer -= Time.deltaTime;

            if (effectorCollidertimer <= 0)
            {
                if (hit)
                {
                    hit.collider.GetComponent<BoxCollider2D>().enabled = true;
                    effectorCollidertimer = 0.2f;
                    effectordone = false;
                    hit = new RaycastHit2D();
                    hit2 = new RaycastHit2D();
                }
                else if (hit2)
                {
                    hit2.collider.GetComponent<BoxCollider2D>().enabled = true;
                    effectorCollidertimer = 0.2f;
                    effectordone = false;
                    hit = new RaycastHit2D();
                    hit2 = new RaycastHit2D();
                }
            }
        }
        }
        }

        //AnimationManager

        if (Rigidbody.velocity.x < 0)
        {
            spriteArma.flipX = true;
            if (GestioneEquipManager.Indaffarato == false) { spriteCorpo.flipX = true; };
            spriteGambe.flipX = true;
        }
        else if (Rigidbody.velocity.x > 0)
        {
            spriteArma.flipX = false;
            if (GestioneEquipManager.Indaffarato == false) { spriteCorpo.flipX = false; };
            spriteGambe.flipX = false;
        }

        //animazioni a terra
        if (dying == true)
        {
            m_state = PlayerManager.State.death;
        }
        else
        {
        if(Rigidbody.velocity.y == 0.0f)
        { 

            if (Rigidbody.velocity.x == 0.0f)
            {
                if(Input.GetKey(KeyCode.S))
                {
                    m_state = PlayerManager.State.crouch;
                }
                else
                {
                    m_state = PlayerManager.State.idle;
                }
            }
            else
            {
               m_state = PlayerManager.State.walk;
            }
        }
        else //animazioni in aria
        {
            m_state = PlayerManager.State.jump;
        }
        }

        switch (m_state)
        {
            case PlayerManager.State.idle:

                //idle
                if (corpoAnimatorOccupato == false) { corpoAnimator.Play("Idle"); }
                gambeAnimator.Play("Idle");
                if (armaAnimator.enabled == true) { armaAnimator.Play("Idle"); };
                break;

            case PlayerManager.State.walk:

                //walk
                if (corpoAnimatorOccupato == false) { corpoAnimator.Play("Walk"); }
                gambeAnimator.Play("Walk");
                if (armaAnimator.enabled == true) { armaAnimator.Play("Walk"); };
                break;

            case PlayerManager.State.jump:

                //jump
                if (corpoAnimatorOccupato == false) {corpoAnimator.Play("Jump"); }
                    gambeAnimator.Play("Jump");
                if (armaAnimator.enabled == true) { armaAnimator.Play("Jump"); } ;
                    break;

             case PlayerManager.State.crouch:
                //crouch
                if (corpoAnimatorOccupato == false) { corpoAnimator.Play("Crouch"); }
                 gambeAnimator.Play("Crouch");
                if (armaAnimator.enabled == true) { armaAnimator.Play("Crouch"); } ;
                 break;

            case PlayerManager.State.death:
                corpoAnimator.Play("Death");
                gambeAnimator.Play("Death");
                if(corpoAnimator.GetCurrentAnimatorStateInfo(0).IsName("Death") && corpoAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    Respawn();
                }
                break;
        }
  
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(footpositionDx, Vector2.down * 1);
        Gizmos.DrawRay(footpositionSx, Vector2.down * 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.collider.gameObject.tag == "Enemy" && dying == false)
        {
            Death();
        }

        if (collision.collider.gameObject.tag == "Shadow" && dying == false)
        {
            Death();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy" && dying == false)
        {
            Death();
        }
    }

    public void Death()
    {
        Rigidbody.velocity = new Vector2(0, 0);
        Rigidbody.bodyType = RigidbodyType2D.Static;
        boxCollider2D.enabled = false;
        gambeBoxCollider2D.enabled = false;
        Occupato = true;
        dying = true;
        GestioneEquipManager.armaCorrente.SetActive(false);
        LoadScenepls();
    }

    private void Respawn()
    {
        dying = false;
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        boxCollider2D.enabled = true;
        gambeBoxCollider2D.enabled = true;
        GestioneEquipManager.BracciaEquip();
        GestioneEquipManager.Impegnato = false;
        Occupato = false;
        spriteCorpo.enabled = true;
        spriteGambe.enabled = true;
        CheckPointManager.GetData();
    }

    private void Reposition()
    {
        dying = false;
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        boxCollider2D.enabled = true;
        gambeBoxCollider2D.enabled = true;
        GestioneEquipManager.BracciaEquip();
        GestioneEquipManager.Impegnato = false;
        Occupato = false;
        spriteCorpo.enabled = true;
        spriteGambe.enabled = true;
    }

    public void Spinta(float power, Vector2 direction)
    {

        if (crouching)
        {
            m_power = power / 100;
            m_direction = direction;
            Rigidbody.AddForce(direction * power / 100, ForceMode2D.Impulse);
        }
        else
        {
            m_direction = direction;
            m_power = power;
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, 0);
            Rigidbody.AddForce(direction * power, ForceMode2D.Impulse);
        }

        spinta = true;
    }

        public void SpintaGun(float power, Vector2 direction)
        {

            if (crouching)
            {
                m_power = power / 100;
                m_direction = direction;
                Rigidbody.AddForce(direction * power / 100, ForceMode2D.Impulse);
            }
            else
            {
                m_direction = direction;
                m_power = power;
                Rigidbody.AddForce(direction * power, ForceMode2D.Impulse);
            }

            spinta = true;
        }
    

    public void LoadScenepls()
    {
        Occupato = true;
        Rigidbody.velocity = Vector2.zero;
        StartCoroutine(LoadScene());
        
    }

    IEnumerator LoadScene()
    {
        transition.SetTrigger("Start");
        Mc.SetTrigger("Trigger");
        Mc2.SetTrigger("Trigger");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame(bool pause)
    {
        if(pause)
        {
            PauseonCanvas.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            Debug.Log("corri e salta dietro il pallone");
            PauseonCanvas.SetActive(false);
            gameisPaused = false;
            Time.timeScale = 1f;
        }
    }
}

