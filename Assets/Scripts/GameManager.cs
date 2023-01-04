using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    private int _agentCount;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is NULL");
            }
            return _instance;
        }
    }

    public void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Keyboard.current.rKey.isPressed && _isGameOver == true)
        {
            SceneManager.LoadScene(0);
        }

        if (Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }
    }


    public void GameOver()
    {
        Debug.Log("GameManager::GameOver() Called");
        _isGameOver = true;
    }

    
    public void Count()
    {
        _agentCount++;
        if (_agentCount == 10)
        {
            UIManager.Instance.LoseConditonSequence();
        }
    }
}
