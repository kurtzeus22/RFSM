using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Save : MonoBehaviour
{

    [SerializeField]
    static GameData Data;

    static SceneInfo sceneInfo;
    public SceneInfo sceneInfo1;

    void Start()
    {


    }

    private void Awake()
    {
        sceneInfo = ScriptableObject.CreateInstance<SceneInfo>();
    }


    void Update()
    {

    }

    public static void Savegame()
    {
        
        GameData gameData = new GameData(sceneInfo);
        SaveSystem.Save_Game(gameData);
    }

    public static void LoadGame()
    {
        SaveSystem.LoadGame();
        Data = SaveSystem.LoadGame();
        sceneInfo = new SceneInfo(Data);

    }

    public static void ResetData()
    {
        sceneInfo = ScriptableObject.CreateInstance<SceneInfo>();
        SaveSystem.defaultData();
        Savegame();
        LoadGame();
    }

    public void resetMusic()
    {
        sceneInfo1.BGM(-10f);
        sceneInfo1.sFX(-5f);
        SceneInfo.MusicValue = -10f;
        SceneInfo.SfxValue = -5f;
    }
}
