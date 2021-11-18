using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class Consumable : MonoBehaviour
{
    Interactable interactable;

    public float mass;
    [Range(0, 2)]public float massGainRatio;

    void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.onInteractedCallback += Eat;
    }

    void Eat()
    {

    }
}
