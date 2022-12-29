using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _startPoint;
   
    private GameObject _robots;
    
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

    private void Start()
    {
        StartCoroutine(SpawnTimer());

        
    }

    IEnumerator SpawnTimer()
    {
        
        while (true)
        {
            _robots = ObjectPool.Instance.GetPooledObject();
            if (_robots != null)
            {
                _robots.transform.position = _startPoint.transform.position;
                _robots.SetActive(true);
            }
            yield return new WaitForSeconds(Random.Range(3.0f, 8.0f));
        }
    }
}