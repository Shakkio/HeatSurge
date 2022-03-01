using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager SharedInstance;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    public List<GameObject> pooledObject2;
    public GameObject objectToPool2;
    public int amountToPool2;

    public List<GameObject> pooledObject3;
    public GameObject objectToPool3;
    public int amountToPool3;

    public List<GameObject> pooledObject4;
    public GameObject objectToPool4;
    public int amountToPool4;

    public List<GameObject> pooledObjects5;
    public GameObject objectToPool5;
    public int amountToPool5;

    public List<GameObject> pooledObjects6;
    public GameObject objectToPool6;
    public int amountToPool6;

    // Start is called before the first frame update
    void Awake()
    {
        SharedInstance = this;
    }

    // Update is called once per frame
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        pooledObject2 = new List<GameObject>();
        GameObject tmp2;
        for (int i = 0; i < amountToPool2; i++)
        {
            tmp2 = Instantiate(objectToPool2);
            tmp2.SetActive(false);
            pooledObject2.Add(tmp2);
        }

        pooledObject3 = new List<GameObject>();
        GameObject tmp3;
        for (int i = 0; i < amountToPool3; i++)
        {
            tmp3 = Instantiate(objectToPool3);
            tmp3.SetActive(false);
            pooledObject3.Add(tmp3);
        }

        pooledObject4 = new List<GameObject>();
        GameObject tmp4;
        for (int i = 0; i < amountToPool4; i++)
        {
            tmp4 = Instantiate(objectToPool4);
            tmp4.SetActive(false);
            pooledObject4.Add(tmp4);
        }

        pooledObjects5 = new List<GameObject>();
        GameObject tmp5;
        for (int i = 0; i < amountToPool5; i++)
        {
            tmp5 = Instantiate(objectToPool5);
            tmp5.SetActive(false);
            pooledObjects5.Add(tmp5);
        }

        pooledObjects6 = new List<GameObject>();
        GameObject tmp6;
        for (int i = 0; i < amountToPool6; i++)
        {
            tmp6 = Instantiate(objectToPool6);
            tmp6.SetActive(false);
            pooledObjects6.Add(tmp6);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy) 
            { 
            return pooledObjects[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject2()
    {
        for (int i = 0; i < amountToPool2; i++)
        {
            if(!pooledObject2[i].activeInHierarchy)
            {
                return pooledObject2[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject3()
    {
        for (int i = 0; i < amountToPool3; i++)
        {
            if((!pooledObject3[i].activeInHierarchy))
            {
                return pooledObject3[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject4()
    {
        for (int i = 0; i < amountToPool4; i++)
        {
            if ((!pooledObject4[i].activeInHierarchy))
            {
                return pooledObject4[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject5()
    {
        for (int i = 0; i < amountToPool5; i++)
        {
            if ((!pooledObjects5[i].activeInHierarchy))
            {
                return pooledObjects5[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject6()
    {
        for (int i = 0; i < amountToPool6; i++)
        {
            if ((!pooledObjects6[i].activeInHierarchy))
            {
                return pooledObjects6[i];
            }
        }
        return null;
    }
}
