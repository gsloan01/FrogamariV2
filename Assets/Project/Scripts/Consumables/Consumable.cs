using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Collider))]
public class Consumable : MonoBehaviour
{
    Interactable interactable;

    public float mass = 1;
    [Range(0, 2)]public float massGainRatio = 0.75f;

    void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.onInteractedCallback += FollowTongue;
    }

    void FollowTongue()
    {
        transform.SetParent(Mouth.Instance.tongueObject.transform, true);
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        if (LickUIManager.Instance.TryGetLickUI(interactable, out LickUI found))
    //        {
    //            found.Open();
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        if (LickUIManager.Instance.TryGetLickUI(interactable, out LickUI found))
    //        {
    //            found.Close();
    //        }
    //    }
    //}
}
