using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWorldObject : MonoBehaviour
{
    [SerializeField] float sinkSpeed = 1.0f;
    float sinkTimer;
    Vector3 startPosition;
    [SerializeField] Transform core;

    bool sinking;
    private void Awake()
    {
        startPosition = transform.localPosition;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!sinking && other.CompareTag("Frog"))
        {
            //Debug.Log($"{name} has started sinking");
            StartCoroutine(Sink());
        }
    }

    IEnumerator Sink()
    {
        
        sinking = true;
        
        while(sinking)
        {

            transform.position = Vector3.Lerp(transform.position, core.transform.position, Time.deltaTime * sinkSpeed);

            //sinkTimer -= Time.deltaTime;
            if (transform.position == core.transform.position)
            {
                sinking = false;
                //Debug.Log($"{name} has finished sinking");
            }
            yield return null;
        }
        
        transform.localPosition = startPosition;
        //sinkTimer = sinkTime;
        sinking = false;
        yield return null;
        
    }
}
