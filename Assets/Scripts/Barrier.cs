using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    //private GameObject _barrier;
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _barrierShot;
    [SerializeField]
    private Renderer _renderer;

    

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("The AudioSource on the player is NULL!");
        }
        else
        {
            _audioSource.clip = _barrierShot;
        }
    }

    public void BarrierShot()
    {

        //_barrier = GameObject.FindWithTag("barrier");
        
        _audioSource.Play();
        Debug.Log("Barrier sound played");
        this.gameObject.SetActive(false);
    }



     
}
