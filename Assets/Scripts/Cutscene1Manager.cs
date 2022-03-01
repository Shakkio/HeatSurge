using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Cutscene1Manager : MonoBehaviour
{
    public InteractionManager InteractionManager;
    public AssistManager AssistManager;
    public GestioneEquipManager GestioneEquipManager;
    public Canvas canvas;
    public GameObject Illusione;
    public GameObject Player;
    public PlayableDirector timeline;
    public Camera mainCamera;
    public Camera illusionCamera;
    public Camera movementCamera;
    public IllusionCameraManager illusionCameraManager;


    public int id = 0;

    bool activated;
    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (id == 0)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("collisione");
                triggered = true;
            }
        }

        if (id == 1)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("collisione");
                triggered = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (id == 0)
        {
            if (collision.tag == "Player")
            {
                AssistManager.EbuttonDeactivate();
                triggered = false;
            }
        }
    }

    private void Update()
    {
        if(id == 99)
        { 
        if (SceneManager.GetActiveScene().name == "Map001" && GameData.Map001unlock == false)
        {
            InteractionManager.Cinema(canvas);
            InteractionManager.Cutscene3(Player, Illusione, timeline, GestioneEquipManager, mainCamera, illusionCamera, illusionCameraManager);
            GameData.Map001unlock = true;
        }

        if (timeline.state != PlayState.Playing)
        {
            Player.SetActive(true);
            Illusione.SetActive(false);
            InteractionManager.noCinema(canvas);
            activated = false;
            mainCamera.gameObject.SetActive(true);
            illusionCamera.gameObject.SetActive(false);
        }
        }


        if (id == 0)
        {
            if (triggered)
            {
                AssistManager.Ebutton();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    InteractionManager.Cinema(canvas);
                    InteractionManager.Cutscene1(Player, Illusione, timeline, GestioneEquipManager, mainCamera, illusionCamera, illusionCameraManager);
                    activated = true;
                }

            }
        }

        if (triggered)
        if (id == 1)
        {
            activated = true;
            InteractionManager.Cinema(canvas);
            InteractionManager.Cutscene2(Player, Illusione, timeline, GestioneEquipManager, mainCamera, illusionCamera, movementCamera, illusionCameraManager);
        }


        if (activated)
        {
            //Cutscene1
            if(id == 0)
            {
                if (timeline.state != PlayState.Playing)
                {
                    Debug.Log("eheh  uora ua");
                    Debug.Log("uora");
                    Player.transform.position = new Vector2(-40, 2409);
                    Player.SetActive(true);
                    Illusione.SetActive(false);
                    InteractionManager.noCinema(canvas);
                    activated = false;
                    mainCamera.gameObject.SetActive(true);
                    illusionCamera.gameObject.SetActive(false);
                }
            }

            //Cutscene2
            if (id == 1)
            {
                triggered = false;
                Debug.Log("non so che dire davvero");
                if (timeline.state != PlayState.Playing)
                {
                    Debug.Log("eheh");
                    SceneManager.LoadScene("Map001");
                }
            }
        }
    }
}

