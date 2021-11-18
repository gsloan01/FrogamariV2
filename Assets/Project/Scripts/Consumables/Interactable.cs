using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public delegate void onInteracted();
    public onInteracted onInteractedCallback;

    public void Interact()
    {
        onInteractedCallback?.Invoke();
    }
}
