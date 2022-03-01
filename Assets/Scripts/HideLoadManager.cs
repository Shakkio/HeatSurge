using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class HideLoadManager : MonoBehaviour
{
    string dataPath;
    // Start is called before the first frame update

    private void Awake()
    {
        FileStream file;
        dataPath = Application.dataPath + "/saveFile.wad";

        if (File.Exists(dataPath) == false)
        {
            this.gameObject.SetActive(false);
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}
