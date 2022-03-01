using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotation;
        rotation = transform.eulerAngles.y;
        transform.eulerAngles = new Vector2(transform.eulerAngles.x, rotation += 2);
    }
}
