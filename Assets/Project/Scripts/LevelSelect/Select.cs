using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public Image popUpImage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collider)
    //{
    //    if (collider.gameObject.tag == "Player")
    //    {
    //        popUpImage.gameObject.SetActive(true);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            popUpImage.gameObject.SetActive(true);

            Debug.Log("Entered");
        }
    }
}
