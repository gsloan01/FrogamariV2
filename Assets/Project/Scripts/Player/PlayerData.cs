using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]

public class PlayerData : ScriptableObject
{
    public List<CustomizationItemData> unlocked = new List<CustomizationItemData>();
    public int coins;
    public List<FrogColorScheme> unlockedColorSchemes = new List<FrogColorScheme>();
    public CustomizationItemData hat = null;
    public FrogColorScheme currentScheme;

    public void SavePlayer()
    {
        SaveSystem.SavePlayerData(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayerData();

        unlocked = data.unlocked;
        coins = data.coins;
        unlockedColorSchemes = data.unlockedColorSchemes;
        hat = data.hat;
        currentScheme = data.currentScheme;
    }
}
