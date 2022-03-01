using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class InteractionManager : MonoBehaviour
{
    public bool cinema = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Porta(GameObject portaArrivo, GameObject Player)
    {
        Player.transform.position = new Vector2(portaArrivo.transform.position.x, portaArrivo.transform.position.y - 6.5f);
    }

    public void Porta2Scene(string Scene, Vector2 position)
    {

    }

    public void Cutscene1(GameObject Player, GameObject Illusione, PlayableDirector timeline, GestioneEquipManager gestioneEquipManager, Camera mainCamera, Camera illusionCamera, IllusionCameraManager illusionCameraManager)
    {
        //setup scena
        gestioneEquipManager.BracciaEquip();
        mainCamera.gameObject.SetActive(false);
        illusionCamera.gameObject.SetActive(true);
        illusionCameraManager.GetIllusion(Illusione);
        Player.transform.position = Illusione.transform.position;
        Illusione.SetActive(true);
        Player.SetActive(false);
        timeline.Play();
    }

    public void Cutscene2(GameObject Player, GameObject Illusione, PlayableDirector timeline, GestioneEquipManager gestioneEquipManager, Camera mainCamera, Camera illusionCamera, Camera movementCamera, IllusionCameraManager illusionCameraManager)
    {
        gestioneEquipManager.BracciaEquip();
        mainCamera.gameObject.SetActive(false);
        illusionCamera.gameObject.SetActive(true);
        illusionCameraManager.GetIllusion(Illusione);
        movementCamera.gameObject.SetActive(true);
        Player.transform.position = Illusione.transform.position;
        Illusione.SetActive(true);
        illusionCamera.gameObject.SetActive(false);
        Player.SetActive(false);
        timeline.Play();
    }

    public void Cutscene3(GameObject Player, GameObject Illusione, PlayableDirector timeline, GestioneEquipManager gestioneEquipManager, Camera mainCamera, Camera illusionCamera, IllusionCameraManager illusionCameraManager)
    {
        gestioneEquipManager.BracciaEquip();
        mainCamera.gameObject.SetActive(false);
        illusionCamera.gameObject.SetActive(true);
        illusionCameraManager.GetIllusion(Illusione);
        Player.transform.position = Illusione.transform.position;
        Illusione.SetActive(true);
        Player.SetActive(false);
        timeline.Play();
    }

    public void Cutscene4(GameObject Player, PlayableDirector timeline, Camera mainCamera, Camera illusionCamera, GameObject Illusione, IllusionCameraManager illusionCameraManager, Camera moveCamera)
    {
        illusionCameraManager.GetIllusion(Illusione);
        Player.transform.position = Illusione.transform.position;
        Illusione.SetActive(true);
        Player.SetActive(false);
        timeline.Play();
    }

    public void Cinema(Canvas canvas)
    {
        canvas.enabled = false;
    }

    public void noCinema(Canvas canvas)
    {
        canvas.enabled = true;
    }    

    public void hidemenu()
    {
        GameObject.Find("TitleScreen").SetActive(false);
    }
}



