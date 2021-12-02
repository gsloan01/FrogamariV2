using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticsManager : MonoBehaviour
{
    [SerializeField] PlayerData data;

    public Transform hatTransform;

    GameObject currentHat = null;

    private void Start()
    {
        UpdateHat();
        UpdateColor();
    }
    public void UpdateHat()
    {
        if(currentHat != null) Destroy(currentHat);
        if(data.hat != null) currentHat = Instantiate(data.hat.item, hatTransform);
    }

    public void UpdateColor()
    {
        
    }
}
