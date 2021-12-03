using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticsManager : MonoBehaviour
{
    [SerializeField] PlayerData data;

    public Transform hatTransform;

    Material mat;
    GameObject currentHat = null;

    private void Start()
    {
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        
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
        mat.SetColor("_MainSkin", data.currentScheme.main);
        mat.SetColor("_SecondarySkin", data.currentScheme.secondary);
        mat.SetColor("_EyeWhites", data.currentScheme.eyeWhite);
        mat.SetColor("_Pupil", data.currentScheme.pupil);
    }
}
