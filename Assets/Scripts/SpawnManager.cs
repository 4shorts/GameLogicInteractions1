using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _startPoint;
    [SerializeField]
    private GameObject _robotPrefab;
    
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Spawn manager is NULL");
            }
            return _instance;
        }
    }

    public void Awake()
    {
        _instance = this;
        
    }

    

 

    void SpawnRobots()
    {
       
    }
}
