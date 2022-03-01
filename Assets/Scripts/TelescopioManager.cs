using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopioManager : MonoBehaviour
{
    public GameObject Ebutton;
    public Camera mainCamera;
    public Camera illusionCamera;
    public GameObject Protagonista;
    public GameObject Illusion;
    public AssistManager AssistManager;
    public GestioneEquipManager GestioneEquipManager;
    bool triggered;
    bool zoom = false;
    public float Speed = 0.0125f;

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
            AssistManager.EbuttonDeactivate();
            triggered = false;
        }
    }

    private void Update()
    {
        if (triggered || Illusion.activeInHierarchy)
        {
            if(Protagonista.activeInHierarchy)
            {
                AssistManager.Ebutton();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if(zoom == true)
                {
                    Ebutton.SetActive(false);
                    PlayerManager.Occupato = false;
                    mainCamera.gameObject.SetActive(true);
                    illusionCamera.gameObject.SetActive(false);
                    Illusion.SetActive(false);
                    Protagonista.SetActive(true);
                    mainCamera.orthographicSize = 110;
                    zoom = false;
                }
                else
                {
                    Ebutton.SetActive(true);
                    GestioneEquipManager.BracciaEquip();
                    PlayerManager.Occupato = true;
                    mainCamera.gameObject.SetActive(false);
                    illusionCamera.gameObject.SetActive(true);
                    illusionCamera.orthographicSize = 300;
                    Illusion.SetActive(true);
                    Protagonista.SetActive(false);
                    zoom = true;
                }
               
            }
        }
    }
}


