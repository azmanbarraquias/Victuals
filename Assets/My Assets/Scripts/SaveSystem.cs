using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // To work with file, when opening and closing
using System.Runtime.Serialization.Formatters.Binary; // To access the binary formatter 

public static class SaveSystem
{

    public static void SavePlayer(List<PlayerData> players)
    {
        var formatter = new BinaryFormatter();

        // Application.persistentDataPath this will get a path to a data directory on the operating system that will not change
        // string path = Path.Combine(Application.persistentDataPath, "/player.fun");
        string path = Application.persistentDataPath + "/player.fun";

        // Filestream is a stream of data contain in a file, and we can use a particular file steam to read and write form a file.
        // FileMode is a an action you want to do the the file
        var stream = new FileStream(path, FileMode.Create);

        // data to write 
        var playerDatas = new List<PlayerData>(players);

        // incert to a file, convert the data to binary, Serialize write down to the file
        formatter.Serialize(stream, playerDatas);

        Debug.Log("File has being save to " + path);

        stream.Close(); // close the stream after writing data
    }

    public static List<PlayerData> LoadPlayer()
    {
        // Application.persistentDataPath this will get a path to a data directory on the operating system that will not change
        string path = Application.persistentDataPath + "/player.fun";
        //string path = Path.Combine(Application.persistentDataPath, "/player.fun");


        if (File.Exists(path))
        {
            //check if the file exist
            var formatter = new BinaryFormatter();

            // Open the file
            var stream = new FileStream(path, FileMode.Open);

            // read the file stream, the convert to the player data
            List<PlayerData> playerData = formatter.Deserialize(stream) as List<PlayerData>;
            stream.Close(); // close the stream after writing data
            Debug.Log("File has being loaded from " + path);
            return playerData;

        }
        else
        {
            Debug.Log("Save file not found in " + path);
            //Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void DeletePlayerData()
    {
        // Application.persistentDataPath this will get a path to a data directory on the operating system that will not change
        string path = Application.persistentDataPath + "/player.fun";
        //string path = Path.Combine(Application.persistentDataPath, "/player.fun");


        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

}
