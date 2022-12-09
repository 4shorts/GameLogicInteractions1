using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AI : MonoBehaviour
{
    
    [SerializeField]
    private List<Transform> _wayPoints;
    private NavMeshAgent _agent;
    private int _currentPoint = 0;
    [SerializeField]
    

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        

        if (_agent != null)
        {
            _agent.destination = _wayPoints[1].position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    
}
