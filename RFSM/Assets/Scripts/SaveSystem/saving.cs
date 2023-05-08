using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public float MusicValue;
    public float SfxValue;
    public bool fpsOn;
    public bool fpsEnabled;
    public bool effectOn;
    public bool effectEnabled;

   

    public GameData(SceneInfo sceneInfo)
    {
        MusicValue = SceneInfo.MusicValue;
        SfxValue = SceneInfo.SfxValue;
        fpsOn = SceneInfo.fpsOn;
        fpsEnabled = SceneInfo.fpsEnabled;
        effectOn = SceneInfo.effectOn;
        effectEnabled = SceneInfo.effectEnabled;
    }
}

public static class SaveSystem
{
    public static string saveFilePath;
    static SceneInfo sceneInfo;
    static SaveSystem()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "save.sav");
    }

    public static void Save_Game(GameData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(saveFilePath, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
        //Debug.Log("Game saved.");
    }

    public static GameData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(saveFilePath, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            //Debug.Log("Game loaded.");
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + saveFilePath);
            return null;
        }
    }

    public static void DeleteSaveData()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
            Debug.Log("Save file deleted.");
        }
        else
        {
            Debug.LogError("Save file not found in " + saveFilePath);
        }
    }

    public static void defaultData()
    {
        SceneInfo.fpsOn = false;
        SceneInfo.fpsEnabled = false;
        SceneInfo.effectOn = true;
        SceneInfo.effectEnabled = true;

        SceneInfo.MusicValue = -10f;
        SceneInfo.SfxValue = -5f;
    }

}