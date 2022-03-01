using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public  GameObject Protagonista;
    Animator m_Animator;
    public Animator illusionAnimator;
    public GameObject illusion;
    InteractionManager InteractionManager;
    public GameObject mainCamera;
    
    enum State
    {
        Nes,
        Heat,
        idle
    }

    MenuManager.State m_state = MenuManager.State.Nes;

    // Start is called before the first frame update
    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        InteractionManager = GameObject.Find("Struttura Utile").GetComponent<InteractionManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (illusionAnimator.GetCurrentAnimatorStateInfo(0).IsName("GetUp") && illusionAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Debug.Log("oi");
            illusion.SetActive(false);
            GameObject.Find("IllusionCamera").SetActive(false);
            mainCamera.SetActive(true);
            Protagonista.transform.position = new Vector2(-50, -7);
            InteractionManager.hidemenu();
        }

        //Gestione Animazioni
        switch (m_state)
        {
            case MenuManager.State.Nes:
                m_Animator.Play("Nes");
                if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Nes") && m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    m_state = MenuManager.State.Heat;
                }
                break;

            case MenuManager.State.Heat:
                m_Animator.Play("Heat");
                if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Heat") && m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
                {
                    m_state = MenuManager.State.idle;
                }
                break;

            case MenuManager.State.idle:
                m_Animator.Play("idle");
                break;
        }


    }

    public void NewGame()
    {
        illusionAnimator.Play("GetUp");

        GameData.ssgUnlock = false;
        GameData.woodenkatagiUnlock = false;
        GameData.devilblasterUnlock = false;
        GameData.firedischargeUnlock = false;
        GameData.devilblasterRepaired = false;
        GameData.gunUnlock = false;
        GameData.pistolUnlock = false;
        GameData.Cassetta = false;

        GameData.gunAmmo = 0;
        GameData.devilblasterAmmo = 0;
        GameData.firedischargeAmmo = 0;

        GameData.playerTeleport = Vector2.zero;
        GameData.saveroomValue = 0;

        GameData.ApBossDefeated = false;
        GameData.KeyAp = false;

        //Map001
        GameData.Map001unlock = false;
        GameData.flag1 = false;
        GameData.flag2 = false;
        GameData.flag3 = false;
        GameData.flag4 = false;
        GameData.flag5 = false;
        GameData.flag6 = false;
        GameData.flag7 = false;
        GameData.flag8 = false;
        GameData.flag9 = false;
        GameData.flag10 = false;
        GameData.flag11 = false;
        GameData.flag12 = false;
        GameData.flag13 = false;
        GameData.flag14 = false;
        GameData.flag15 = false;
        GameData.flag16 = false;
        GameData.flag17 = false;
        GameData.flag18 = false;
        GameData.flag19 = false;
        GameData.flag20 = false;
        GameData.flag21 = false;
        GameData.flag22 = false;
        GameData.flag23 = false;
        GameData.flag24 = false;
        GameData.flag25 = false;
        GameData.flag26 = false;
        GameData.flag27 = false;
        GameData.flag28 = false;


    }
}
