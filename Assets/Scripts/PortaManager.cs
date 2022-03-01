using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaManager : MonoBehaviour
{
    public GameObject portaArrivo;
    public InteractionManager InteractionManager;
    public AssistManager AssistManager;
    public GameObject Player;
    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
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
        if(triggered)
        {
            AssistManager.Ebutton();
            if (Input.GetKeyDown(KeyCode.E))
            {
            InteractionManager.Porta(portaArrivo, Player);
            }
        }
    }
}
