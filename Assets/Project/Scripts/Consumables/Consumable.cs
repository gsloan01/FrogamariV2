using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
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
}
