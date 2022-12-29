using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    private AI _AI;
    [SerializeField]
    private int _score = 50;
    [SerializeField]
    private int _AICount = 20;
    // Start is called before the first frame update
    void Start()
    {
        _AI = GetComponent<AI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ShootBarriers();
            ShootRobots();
        }
    }

    void ShootBarriers()
    {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, 1 << 7))
        {
            Debug.Log("hit barrier");
            hitInfo.collider.GetComponent<Collider>();
            if (hitInfo.collider != null)
            {
                hitInfo.collider.gameObject.SetActive(false);
            }

        }
    }

    public void ShootRobots()
    {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, 1 << 6))
        {
            Debug.Log("hit robot");
            hitInfo.collider.GetComponent<Collider>();
            if (hitInfo.collider != null)
            {
                AddScore(50);
                removeAI(-1);
                hitInfo.collider.gameObject.SetActive(false);
            }
        }
    }

    public void AddScore(int points)
    {
        _score += points;
        UIManager.Instance.UpdateScore(_score);

    }

    public void removeAI(int count)
    {
        _AICount += count;
        UIManager.Instance.UpdateAICount(_AICount);
        WinCondition();
    }

    public void WinCondition()
    {
        if (_AICount == 0)
        {
            UIManager.Instance.WinConditionSequence();
        }
    }

    public void LossCondition()
    {

    }
}
