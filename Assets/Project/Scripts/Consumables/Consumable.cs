using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Consumable : MonoBehaviour
{
    public delegate void OnStuck();
    public OnStuck OnStuckCallback;


    public float mass = 1;
    [Range(0, 2)]public float massGainRatio = 0.75f;
    [Range(0, 2)] public float minGrabMultiplier = 0.75f;
    [Range(0, 5)] public float minEatMultiplier = 0.75f;

    Interactable interactable;

    void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.onInteractedCallback += FollowTongue;
    }

    void FollowTongue()
    {
        if (MassManager.Instance.CurrentMass >= mass * minGrabMultiplier)
        {
            transform.SetParent(Mouth.Instance.tongueObject.transform, true);
        }
    }

    public void TryEat()
    {
        if (MassManager.Instance.CurrentMass >= mass * minGrabMultiplier)
        {
            MassManager.Instance.ChangeMass(mass * massGainRatio);
            OtherEffects();
        }
    }

    public virtual void OtherEffects()
    {
        Debug.Log("Other Consumable Effects");
    }

    private void OnDestroy()
    {
        TryEat();
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
