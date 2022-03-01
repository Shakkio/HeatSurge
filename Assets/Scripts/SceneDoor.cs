using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : MonoBehaviour
{
    public AssistManager AssistManager;
    public GameObject Player;
    public string Scene;
    public Vector2 positionPlayer;
    bool triggered = false;

    public Animator Mc;
    public Animator Mc2;
    public Animator transition;
    public float transitionTime = 1;

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


    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            AssistManager.Ebutton();

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameData.playerTeleport = positionPlayer;
                LoadScenepls();
            }
        }
    }

    public void LoadScenepls()
    {
        PlayerManager.Occupato = true;
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Player.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(LoadScene(Scene));
    }

    IEnumerator LoadScene(string Scene)
    {
        transition.SetTrigger("Start");
        Mc2.SetTrigger("Trigger");
        Mc.SetTrigger("Trigger");

        yield return new WaitForSeconds(transitionTime);

        PlayerManager.Occupato = false;

        Player.GetComponent<BoxCollider2D>().enabled = true;
        SceneManager.LoadScene(Scene);

    }
}


