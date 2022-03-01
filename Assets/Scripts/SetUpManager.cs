using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpManager : MonoBehaviour
{
    public List <ShadowPlatformManager> platforms;


    private void Awake()
    {
        platforms = new List<ShadowPlatformManager>();
        GameObject[] plats = GameObject.FindGameObjectsWithTag("ShadowPlatform");
        foreach(GameObject plat in plats)
        {
            ShadowPlatformManager shadowPlatformManager;
            shadowPlatformManager = new ShadowPlatformManager(false, plat.transform);
            platforms.Add(shadowPlatformManager);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
