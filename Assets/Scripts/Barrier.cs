using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    private GameObject _barrier;

    private void Start()
    {
        _barrier = GameObject.FindWithTag("barrier");
    }
    public void BarrierShot()
    {
        
        _barrier.SetActive(false);
        //StartCoroutine(BarrierTimer());
        
    }

    //IEnumerator BarrierTimer()
    //{
    //    _barrier.SetActive(false);
      
    //    yield return new WaitForSeconds(10.0f);
    //    //_barrier.GetComponent<Renderer>().enabled = true;
    //}
}
