using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SerraturaManager : MonoBehaviour
{
    bool activated = false;
    bool triggered = false;
    Animator mAnimator;
    AssistManager AssistManager;
    InteractionManager InteractionManager;
    public GestioneEquipManager GestioneEquipManager;
    public GameObject apOnCanvas;
    public GameObject PortaScene;
    public GameObject Protagonista;
    public GameObject Monster;
    public GameObject AP;
    public PlayableDirector timeline;

    
    public GameObject Illusion;
    public Camera MainCamera;
    public Camera IllusionCamera;
    public Camera moveCamera;
    public IllusionCameraManager IllusionCameraManager;
    public bool bossBattle = false;

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
        AssistManager = GameObject.Find("Struttura Utile").GetComponent<AssistManager>();
        InteractionManager = GameObject.Find("Struttura Utile").GetComponent<InteractionManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered == true && bossBattle == false)
        {
            AssistManager.Ebutton();

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameData.KeyAp == true)
                {
                    mAnimator.Play("Shatter");

                }
                else if (GameData.KeyAp == false && GameData.ApBossDefeated == true)
                {
                    mAnimator.Play("Drift");
                }
                else
                {
                    Debug.Log("oi");
                    activated = true;
                    bossBattle = true;
                    mAnimator.Play("Drift");
                }
            }
        }

        if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Shatter") && mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            PortaScene.SetActive(true);
            Destroy(this.gameObject);
        }

        if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Drift"))
        {
            Debug.Log("eddai");
            PlayerManager.Occupato = true;
            Protagonista.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Drift") && mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            if (activated == true && GameData.ApBossDefeated == false)
            {
                PlayerManager.Occupato = true;
                GestioneEquipManager.BracciaEquip();
                InteractionManager.Cutscene4(Protagonista, timeline, MainCamera, IllusionCamera, Illusion, IllusionCameraManager, moveCamera);
                mAnimator.Play("Idle");
            }
            else
            {
                mAnimator.Play("Idle");
            }
        }

        if (timeline.time > 13f)
        {
            Protagonista.SetActive(true);
            MainCamera.gameObject.SetActive(true);
            moveCamera.gameObject.SetActive(false);
            Illusion.SetActive(false);
            IllusionCamera.gameObject.SetActive(false);
            PlayerManager.Occupato = false;
        }

        if(timeline.time >= 14.87f)
        {
            Monster.SetActive(true);
            Monster.GetComponent<Rigidbody2D>().AddForce(new Vector2(70, 0), ForceMode2D.Impulse);
            AP.SetActive(true);
            apOnCanvas.SetActive(true);
        }
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            triggered = true;
        }
         
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            triggered = false;
            AssistManager.EbuttonDeactivate();
        }
    }

}
