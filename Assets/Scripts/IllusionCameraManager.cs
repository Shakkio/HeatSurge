using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionCameraManager : MonoBehaviour
{
    public GameObject Illusione;
    public static Camera mainCamera;
    public bool trovato = false;

    // Start is called before the first frame update

    public void GetIllusion(GameObject illusione)
    {
        Illusione =  illusione;
    }

    // Update is called once per frame
    void Update()
    {
        if(Illusione)
            transform.position = Illusione.transform.position;
    }
}
