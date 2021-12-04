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

        binaryFormatter.Serialize(fileStream, playerData);

        fileStream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        string filePath = Application.persistentDataPath + "frog.pd";
        
        if (File.Exists(filePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

            PlayerData playerData = binaryFormatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();

            return playerData;
        }
        else
        {
            Debug.LogError("Save File Not Found In " + filePath);
            return null;
        }
    }
}
