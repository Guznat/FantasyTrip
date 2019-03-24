using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
  public static void SavePlayer(PlayerMovment player, Health playerHealth)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save_data.ng";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataHolder data = new DataHolder(player, playerHealth);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static DataHolder LoadPlayer()
    {
        string path = Application.persistentDataPath + "/save_data.ng";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataHolder data = formatter.Deserialize(stream) as DataHolder;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Can't be loaded from" + path);
            return null;
        }
    }

}
