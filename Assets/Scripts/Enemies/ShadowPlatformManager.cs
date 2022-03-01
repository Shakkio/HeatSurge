using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPlatformManager
{
    bool busy;
    Transform position;

    public ShadowPlatformManager(bool busy, Transform position) 
    {
        this.busy = busy;
        this.position = position;
    }

    public void SetBusy(bool busy)
    {
        this.busy = busy;
    }

    public void SetTransform(Transform position)
    {
        this.position = position;
    }

    public bool GetBusy()
    {
        return busy;
    }

    public Transform GetTransform()
    {
        return position;
    }
}

