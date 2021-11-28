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
            selectLevelUpCanvas.transform.DOMove(new Vector3(selectLevelParent.transform.position.x, selectLevelParent.transform.position.y + 0.25f, selectLevelParent.transform.position.z - .5f), 2f).SetLoops(-1, LoopType.Yoyo);
            //Debug.Log("Entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        selectLevelUpCanvas.SetActive(false);
    }
}
