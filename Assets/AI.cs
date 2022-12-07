using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _wayPoints;
    private NavMeshAgent _agent;
    private int _currentPoint = 0;
    private bool _inReverse = false;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        if (_agent != null)
        {
            _agent.destination = _wayPoints[_currentPoint].position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateAIMovement();
    }

    void CalculateAIMovement()
    {
        if (_agent.remainingDistance < 0.5f)
        {
            if (_inReverse == true)
            {
                Reverse();
            }
            else
            {
                Forward();
            }
            _agent.SetDestination(_wayPoints[_currentPoint].position);

        }

        void Forward()
        {
            if (_currentPoint == _wayPoints.Count - 1)
            {
                _inReverse = true;
                _currentPoint--;
            }

            else
            {
                _currentPoint++;
            }
        }
        void Reverse()
        {
            if (_currentPoint == 0)
            {
                _inReverse = false;
                _currentPoint++;
            }
            else
            {
                _currentPoint--;
            }
        }
    }
}
