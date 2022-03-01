using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveRoomManager : MonoBehaviour
{
    public InteractionManager InteractionManager;
    public AssistManager AssistManager;
    public GameObject Player;
    bool triggered = false;
    public int saveValue;
    Vector2 positionPlayer;

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
        if (triggered && SceneManager.GetActiveScene().name != "SaveRoom")
        {
            AssistManager.Ebutton();
            if (Input.GetKeyDown(KeyCode.E))
            {
                positionPlayer = new Vector2(44, 185);
                GameData.playerTeleport = positionPlayer;
                GameData.saveroomValue = saveValue;
                SceneManager.LoadScene("SaveRoom");
            }
        }
        else if (triggered && SceneManager.GetActiveScene().name == "SaveRoom")
        {
            AssistManager.Ebutton();

            if (Input.GetKeyDown(KeyCode.E))
            {
                if(GameData.saveroomValue == 0)
                {
                    positionPlayer = new Vector2(473, 185);
                    GameData.playerTeleport = positionPlayer;
                    SceneManager.LoadScene("Map002");
                }
                else if(GameData.saveroomValue == 1)
                {
                    positionPlayer = new Vector2(160, 185);
                    GameData.playerTeleport = positionPlayer;
                    SceneManager.LoadScene("Map008");
                }
                
            }
        }
    }
}

