using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportManager : MonoBehaviour
{
    public string mapName;
    public Vector2 positionPlayer;
    public GameObject Player;
    bool trigger = false;

    public Animator Mc;
    public Animator Mc2;
    public Animator transition;
    public float transitionTime = 1;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameData.playerTeleport = positionPlayer;
            trigger = true;
        }
    }

    private void Update()
    {
        if(trigger == true)
        {
            LoadScenepls();
        }
    }

    public void LoadScenepls()
    {
        PlayerManager.Occupato = true;
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Player.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(LoadScene(mapName));
    }

    IEnumerator LoadScene(string mapname)
    {
        transition.SetTrigger("Start");
        Mc2.SetTrigger("Trigger");
        Mc.SetTrigger("Trigger");

        yield return new WaitForSeconds(transitionTime);

        PlayerManager.Occupato = false;
        
        Player.GetComponent<BoxCollider2D>().enabled = true;
        SceneManager.LoadScene(mapName);

    }
}
