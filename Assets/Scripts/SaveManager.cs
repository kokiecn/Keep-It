using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Player
{
    public static int nbLevel = 9;
    public bool[] isClear = new bool[nbLevel];
}
public class SaveManager : MonoBehaviour
{
 
    private void Start()
    {
        Player player = new Player();
        if (File.Exists(Application.dataPath + "/savedata.json"))
        {
            player = loadPlayerData();
        }
        else
        {
            for (int i = 0; i < Player.nbLevel; i++)
            {
                player.isClear[i] = false;
            }

        }
        savePlayerData(player);
    }

    public void savePlayerData(Player player)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(player);

        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public Player loadPlayerData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<Player>(datastr);
    }
}