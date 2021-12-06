using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSaveData : MonoBehaviour
{
    public PlayerData playerData;

    public void SavePlayer()
    {
        SaveSystem.SavePlayerData(playerData);
        Debug.Log("saved coins: " + playerData.coins);
    }

    public void LoadPlayer()
    {
        PlayerDataSAL data = SaveSystem.LoadPlayerData();

        playerData.unlocked = data.unlocked;
        playerData.coins = data.coins;
        playerData.unlockedColorSchemes = data.unlockedColorSchemes;
        playerData.hat = data.hat;
        playerData.currentScheme = data.currentScheme;
    }
}
