using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayerData(PlayerData playerData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "frog.pd";
        FileStream fileStream = new FileStream(filePath, FileMode.Create);

        PlayerDataSAL playerDataSAL = new PlayerDataSAL(playerData);

        binaryFormatter.Serialize(fileStream, playerDataSAL);

        fileStream.Close();
    }

    public static PlayerDataSAL LoadPlayerData()
    {
        string filePath = Application.persistentDataPath + "frog.pd";
        
        if (File.Exists(filePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

            PlayerDataSAL playerDataSAL = binaryFormatter.Deserialize(fileStream) as PlayerDataSAL;
            fileStream.Close();

            return playerDataSAL;
        }
        else
        {
            Debug.LogError("Save File Not Found In " + filePath);
            return null;
        }
    }
}
