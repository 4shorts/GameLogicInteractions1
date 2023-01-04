using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionBarrel;
    [SerializeField]
    private Renderer _renderer;

    public void Explode()
    {
        _explosionBarrel.SetActive(true);
        StartCoroutine(ExplosionTimer());
    }

    IEnumerator ExplosionTimer()
    {

        yield return new WaitForSeconds(2.0f);
        _renderer.enabled = false;
        yield return new WaitForSeconds(2.0f);
        this.gameObject.SetActive(false);
    }

    
    
}
