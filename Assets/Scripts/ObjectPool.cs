using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> activePooledObjects;
    private List<GameObject> pooledObjects;
    [SerializeField]
    private GameObject objectToPool;
    [SerializeField]
    private int amountToPool;
    

    private static ObjectPool _instance;
    public static ObjectPool Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Object Pool is NULL");
            }
            return _instance; 
        }
    }

    public void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        pooledObjects = new List<GameObject>();
        activePooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, Vector3.zero, Quaternion.identity, this.transform);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        if (pooledObjects.Count > 0)
        {
            GameObject tmp = pooledObjects[0];
            activePooledObjects.Add(pooledObjects[0]);
            pooledObjects.Remove(pooledObjects[0]);
            return tmp;
        }
        else
        {
            return null;
        }
    }

    
}
