using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Customization", menuName = "Data/Customization/NewCustomizable")]
public class CustomizationItemData : ScriptableObject
{
    public enum CustomizationSlot
    {
        Hat
    }

    public string name;
    public CustomizationSlot slot;
    public int cost;
    public GameObject item;
    public Sprite icon;
}
