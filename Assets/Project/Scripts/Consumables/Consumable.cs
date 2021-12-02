using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Consumable : MonoBehaviour
{
    public float mass = 1;
    [Range(0, 2)]public float massGainRatio = 0.75f;
    [Range(0, 2)] public float minGrabMultiplier = 0.75f;
    [Range(0, 5)] public float minEatMultiplier = 0.75f;

    Interactable interactable;

    void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.onInteractedCallback += Interacted;
    }

    protected virtual void Interacted()
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
            MainEffect();
            OtherEffects();
        }
    }

    public virtual void MainEffect()
    {
        MassManager.Instance.ChangeMass(mass * massGainRatio);
    }

    public virtual void OtherEffects()
    {
        //Put anything other than sizing in here
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
