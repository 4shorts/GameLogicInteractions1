using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

   
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
        StartCoroutine(BarrierShotRoutine());
       
    }

    IEnumerator BarrierShotRoutine()
    {
        yield return new WaitForSeconds(.45f);
        _audioSource.Play();
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
        
    }



     
}
