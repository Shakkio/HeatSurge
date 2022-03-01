using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public Animator textAnimator;
    public TextMeshProUGUI text;
    int id = 0;

    private bool trigger = false;
    float timerText = 2.0f;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(trigger == true)
        {
            timerText -= Time.deltaTime;
        }

        if(timerText <= 0)
        {
            trigger = false;
            textAnimator.Play("Fade");
        }

        if(textAnimator.GetCurrentAnimatorStateInfo(0).IsName("Fade") && textAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            textAnimator.gameObject.SetActive(false);
        }
    }

    public void Tutorial(int idT)
    { 
        if(idT == 0)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai raccolto: Proiettili per GUN.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
        else if (idT == 1)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai raccolto: Proiettili per DevilBlaster.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
        else if (idT == 2)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai raccolto: GUN.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
        else if (idT == 3)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai raccolto: DevilBlaster danneggiato.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
        else if (idT == 4)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai raccolto: Katagi di Legno.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
        else if (idT == 5)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai raccolto: SSG.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
        else if (idT == 6)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai raccolto: DevilBlaster riparato.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
        else if (idT == 7)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai raccolto: Pistola.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
        else if (idT == 8)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai raccolto: Cassetta per Riparazioni.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
        else if (idT == 9)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai raccolto: Chiave di Ap il Terribile.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
        else if (idT == 10)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai trovato una stanza segreta.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
        else if (idT == 11)
        {
            text.gameObject.SetActive(true);
            text.text = "Hai salvato la partita.";
            trigger = true;
            timerText = 2.0f;
            textAnimator.Play("TextStatico");
        }
    }
}

