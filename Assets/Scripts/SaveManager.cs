using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SaveManager : MonoBehaviour
{
    public AssistManager AssistManager;
    public GameObject Player;
    public SpriteRenderer playerSprite;
    public GameObject Illusione;
    public Animator illusioneAnimatore;
    public GameData GameData;
    public SpriteRenderer frigoSprite;
    public Sprite FrigoAperto;
    public Sprite FrigoChiuso;
    public InteractionManager InteractionManager;
    public Canvas canvas;
    public Camera mainCamera;
    public Camera illusionCamera;
    public GestioneEquipManager GestioneEquipManager;
    public IllusionCameraManager IllusionCameraManager;
    public TutorialManager tutorialManager;
    public Light2D light;
    bool triggered = false;
    int idt = 11;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("collisione");
            triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            frigoSprite.sprite = FrigoChiuso;
            AssistManager.SaveButtonDeactivate();
            triggered = false;
        }
    }

    void Update()
    {
        if(frigoSprite.sprite == FrigoAperto)
        {
            light.intensity = 1.2f;
        }
        else
        {
            light.intensity = 0;
        }

        if(triggered)
        {
            if(frigoSprite.sprite == FrigoChiuso)
            {
                frigoSprite.sprite = FrigoAperto;
            }
            AssistManager.SaveButton();

            if(Input.GetKeyDown(KeyCode.E))
            {
                GameData.Save();
                GestioneEquipManager.BracciaEquip();
                mainCamera.gameObject.SetActive(false);
                illusionCamera.gameObject.SetActive(true);
                IllusionCameraManager.GetIllusion(Illusione);
                Player.transform.position = Illusione.transform.position;
                Illusione.SetActive(true);
                Player.SetActive(false);
                playerSprite.flipX = false;
                InteractionManager.Cinema(canvas);
                frigoSprite.sprite = FrigoAperto;
            }
        }


        if (illusioneAnimatore.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            tutorialManager.Tutorial(idt);
            Debug.Log("ueue");
            Player.SetActive(true);
            mainCamera.gameObject.SetActive(true);
            illusionCamera.gameObject.SetActive(false);
            Illusione.SetActive(false);
            InteractionManager.noCinema(canvas);
        }
    }
}
