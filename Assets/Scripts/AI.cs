using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private enum AIState
    {
        Run,
        Hide,
        Death
    };
    [SerializeField]
    private List<Transform> _hidingPlace;
    private NavMeshAgent _agent;
    private int _currentHidingPlace = 0;
    [SerializeField]
    private AIState _currentState;
    private bool _isHiding = false;
  
    private float _speed = 4.0f;
    private Animator _anim;
    [SerializeField]
    private int _agentCount = 0;
    
  
  
 

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        

        if (_anim == null)
        {
            Debug.Log("Failed to connect the Animator");
        }

        _hidingPlace = new List<Transform>();
        BoxCollider[] hidingBoxes = GameObject.Find("HidingPlaces").GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider hidingBox in hidingBoxes)
        {
            _hidingPlace.Add(hidingBox.transform);
        }



        if (_agent != null)
        {
            _agent.destination = _hidingPlace[_currentHidingPlace].position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        AIStates();
    }

    public void AIStates()
    {
        switch (_currentState)
        {
            case AIState.Run:
                Debug.Log("Running...");
                CalculateAIMovement();
                break;
            case AIState.Hide:
                Debug.Log("Hiding...");
                
                if (_isHiding == false)
                {
                    StartCoroutine(HidingRoutine());
                    _isHiding = true;
                }
                if (_hidingPlace.Count-1 == _currentHidingPlace)
                {
                    GameManager.Instance.Count();
                    _agent.gameObject.SetActive(false);
                }

                break;
            case AIState.Death:
                Debug.Log("Dead...");
                StartCoroutine(DeathRoutine());
                
                break;
        }
    }

    void CalculateAIMovement()
    {

        if (_agent.remainingDistance < 0.2f)
        {
            _currentState = AIState.Hide;

        }
        _anim.SetFloat("Speed", _speed);
        
        
    }

    IEnumerator HidingRoutine()
    {
        _anim.SetBool("Hiding", true);
        yield return new WaitForSeconds(Random.Range(1.0f, 5.0f));
        _anim.SetBool("Hiding", false);
        _currentHidingPlace++;
        _agent.SetDestination(_hidingPlace[_currentHidingPlace].position);
        _currentState = AIState.Run;
        _isHiding = false;
        
    }

    public IEnumerator DeathRoutine()
    {

        _agent.isStopped = true;
        _anim.SetTrigger("Death");
        yield return new WaitForSeconds(4.0f);
        _agent.gameObject.SetActive(false);

    }

    

    public void RobotShot()
    {
        _currentState = AIState.Death;
    }


}
