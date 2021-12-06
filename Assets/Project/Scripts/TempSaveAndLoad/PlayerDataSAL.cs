using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataSAL : MonoBehaviour
{
    public List<CustomizationItemData> unlocked;
    public int coins;
    public List<FrogColorScheme> unlockedColorSchemes;
    public CustomizationItemData hat;
    public FrogColorScheme currentScheme;

    public PlayerDataSAL(PlayerData playerData)
    {
        unlocked = playerData.unlocked;
        coins = playerData.coins;
        unlockedColorSchemes = playerData.unlockedColorSchemes;
        hat = playerData.hat;
        currentScheme = playerData.currentScheme;
    }
}
