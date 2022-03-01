using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCameraManager : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Map001")
        {
            transform.position = new Vector2(Mathf.Clamp(Player.transform.position.x, -9999, 3705), Player.transform.position.y);
        }
        else if (SceneManager.GetActiveScene().name == "Map002")
        {
            transform.position = new Vector2(Mathf.Clamp(Player.transform.position.x, 196, 1770), (Mathf.Clamp(Player.transform.position.y, -224, 2400)));
        }
        else if(SceneManager.GetActiveScene().name == "Map004")
        {
            transform.position = new Vector2(Mathf.Clamp(Player.transform.position.x, -9999, 9999), (Mathf.Clamp(Player.transform.position.y, 142, 9999)));
        }
        else if(SceneManager.GetActiveScene().name == "Map005")
        {
            transform.position = new Vector2(Mathf.Clamp(Player.transform.position.x, -77, 9999), (Mathf.Clamp(Player.transform.position.y, 188, 9999)));
        }
        else if (SceneManager.GetActiveScene().name == "Map007")
        {
            transform.position = new Vector2(Mathf.Clamp(Player.transform.position.x, -99999, 9999), (Mathf.Clamp(Player.transform.position.y, 130, 9999)));
        }
        else if (SceneManager.GetActiveScene().name == "Map008")
        {
            transform.position = new Vector2(Mathf.Clamp(Player.transform.position.x, 198, 9999), (Mathf.Clamp(Player.transform.position.y, -446, 9999)));
        }
        else if (SceneManager.GetActiveScene().name == "Map009")
        {
            transform.position = new Vector2(Mathf.Clamp(Player.transform.position.x, 198, 9999), (Mathf.Clamp(Player.transform.position.y, -647, -242)));
        }
        else
        {
            transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y, transform.position.z);
        }
    }
}
