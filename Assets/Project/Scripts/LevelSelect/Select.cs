using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Select : MonoBehaviour
{
    public GameObject selectLevelUpCanvas;
    public Transform selectLevelParent;

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
            //selectLevelUpCanvas.transform.DOMove(new Vector3(selectLevelUpCanvas.transform.position.x, selectLevelUpCanvas.transform.position.y + 0.25f, selectLevelUpCanvas.transform.position.z), 2f).SetLoops(-1, LoopType.Yoyo);
            selectLevelUpCanvas.transform.DOMove(new Vector3(selectLevelUpCanvas.transform.position.x - 750, selectLevelUpCanvas.transform.position.y, selectLevelUpCanvas.transform.position.z), 1.5f);
            //Debug.Log("Entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        selectLevelUpCanvas.SetActive(false);
        //selectLevelUpCanvas.transform.DOMove(new Vector3(selectLevelUpCanvas.transform.position.x + 750, selectLevelUpCanvas.transform.position.y, selectLevelUpCanvas.transform.position.z), 1.5f);

        if (selectLevelUpCanvas.transform.position.x >= selectLevelUpCanvas.transform.position.x + 300)
            selectLevelUpCanvas.SetActive(false);
    }
}
