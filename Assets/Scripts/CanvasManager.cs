using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CanvasManager : MonoBehaviour
{

    public TextMeshProUGUI textMeshDevilBlaster;
    public TextMeshProUGUI textMeshSSG;
    public TextMeshProUGUI textMeshGun;

    public GameObject GunOnCanvas;
    public GameObject ssgonCanvas;
    public GameObject devilblasteronCanvas;
    public GameObject pistolOnCanvas;

    public GameObject currentOnCanvas;
    public GameObject canvasNullo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshGun.text = GameData.gunAmmo.ToString();
        textMeshDevilBlaster.text = GameData.devilblasterAmmo.ToString();
    }
}
