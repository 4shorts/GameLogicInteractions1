using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    [SerializeField]
    private int _agentCount;
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _audioClip;

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
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("AudioSource in GameManager is NULL");
        }
        else
        {
            _audioSource.clip = _audioClip;
        }
        
        _agentCount++;
        _audioSource.Play();
        if (_agentCount == 10)
        {
            UIManager.Instance.LoseConditonSequence();
        }
    }
}
