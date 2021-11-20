using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public GameObject selectLevelUpCanvas;

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
            selectLevelUpCanvas.SetActive(true);

            //Debug.Log("Entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        selectLevelUpCanvas.SetActive(false);
    }
}
