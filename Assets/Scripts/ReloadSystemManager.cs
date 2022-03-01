using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSystemManager : MonoBehaviour
{
    public SSGManager SSGManager;
    public float maxReloadingtime = 4.0f;
    public float SSGreloadingTime = 4.0f;
    public bool ssgReloaded = false;

    void Awake()
    {
        SSGreloadingTime = maxReloadingtime;
    }

    // Update is called once per frame
    void Update()
    {
        if (SSGManager.isReloading)
        {
            SSGreloadingTime -= Time.deltaTime;
            if (SSGreloadingTime <= 0)
            {
                SSGreloadingTime = maxReloadingtime;
                SSGManager.isReloading = false;
                ssgReloaded = true;
            }
        }


    }
}
