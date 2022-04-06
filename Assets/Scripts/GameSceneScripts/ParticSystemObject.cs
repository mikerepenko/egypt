using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticSystemObject : MonoBehaviour
{
    public ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem.Stop();
        //StartCoroutine(TimePart());
    }

    public IEnumerator TimePart()
    {
        Debug.Log(0);
        particleSystem.Play();
        yield return new WaitForSeconds(1f);
        Debug.Log(1);
        particleSystem.Stop();
        Debug.Log(particleSystem.isStopped);
    }
}