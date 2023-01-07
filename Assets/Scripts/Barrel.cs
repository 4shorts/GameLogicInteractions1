using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionBarrel;
    [SerializeField]
    private Renderer _renderer;
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _explosion;
  

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("The AudioSource on the player is NULL!");
        }
        else
        {
            _audioSource.clip = _explosion;
        }
    }
    public void Explode()
    {
        _explosionBarrel.SetActive(true);
        
        StartCoroutine(ExplosionTimer());
    }

    IEnumerator ExplosionTimer()
    {
        
        yield return new WaitForSeconds(0.45f);
        _audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        _renderer.enabled = false;
        yield return new WaitForSeconds(2.0f);
        this.gameObject.SetActive(false);
    }

    public void ExplostionDamage(Vector3 center, float radius)
    {

    }

    
    
}
