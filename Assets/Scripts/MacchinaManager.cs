using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MacchinaManager : MonoBehaviour
{
    Animator mAnimator;
    public static bool used = false;
    public GameObject Baloon;
    bool triggered = false;
    public GameObject DevilBlasterPickup;
    public GestioneEquipManager GestioneEquipManager;
    public Light2D light;

    enum State
    {
        idle,
        chew,
        idledone,
        ejecting
    }

    MacchinaManager.State m_state = MacchinaManager.State.idle;

    // Start is called before the first frame update
    void Awake()
    {
        mAnimator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_state)
        {

            case MacchinaManager.State.idle:

                mAnimator.Play("idle");
                if(triggered)
                {
                    if(GameData.devilblasterRepaired == false && GameData.Cassetta == true)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            GameData.devilblasterUnlock = false;
                            if(GameObject.Find("/Protagonista/Equip/DevilBlaster").activeInHierarchy == true)
                            {
                                GestioneEquipManager.BracciaEquip();
                            }
                            m_state = MacchinaManager.State.chew;
                        }
                    }

                    if (GameData.devilblasterRepaired == true)
                    {
                        MacchinaManager.State m_state = MacchinaManager.State.idledone;
                    }
                }

                break;

            case MacchinaManager.State.chew:

                mAnimator.Play("chew");

                if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("chew") && mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f )
                {
                    m_state = MacchinaManager.State.ejecting;
                }
                break;

            case MacchinaManager.State.ejecting:

                mAnimator.Play("ejecting");

                if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("ejecting") && mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    DevilBlasterPickup.SetActive(true);
                    DevilBlasterPickup.GetComponent<Rigidbody2D>().velocity = new Vector2(800, 0);
                    m_state = MacchinaManager.State.idledone;
                }
                break;

            case MacchinaManager.State.idledone:

                mAnimator.Play("idledone");
                light.color = Color.green;
                break;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_state == MacchinaManager.State.idle && GameData.devilblasterRepaired == false)
        {
            Baloon.SetActive(true);
            triggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Baloon.SetActive(false);
        triggered = false;
    }

}
