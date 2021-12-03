using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]

public class PlayerData : ScriptableObject
{
    public List<CustomizationItemData> unlocked = new List<CustomizationItemData>();
    public int coins;
    public List<FrogColorScheme> unlockedColorSchemes = new List<FrogColorScheme>();
    public CustomizationItemData hat = null;
    public FrogColorScheme currentScheme;
}
