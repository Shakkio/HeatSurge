using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistManager : MonoBehaviour
{
    public GameObject eButton;
    public GameObject Protagonista;
    public GameObject saveButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ebutton()
    {
        eButton.SetActive(true);
        eButton.transform.position = new Vector2(Protagonista.transform.position.x, Protagonista.transform.position.y + 15f);
    }

    public void SaveButton()
    {
        saveButton.SetActive(true);
        saveButton.transform.position = new Vector2(Protagonista.transform.position.x, Protagonista.transform.position.y + 15f);
    }

    public void EbuttonDeactivate()
    {
        eButton.SetActive(false);
    }

    public void SaveButtonDeactivate()
    {
        saveButton.SetActive(false);
    }
}
