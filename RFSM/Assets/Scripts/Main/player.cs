using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int playerExperience;
    public int playerHealth;
    public Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveGame()
    {
        print("save");
        PlayerData data = new PlayerData(playerExperience);
        SaveSystem.SavePlayerData(data);
    }

    public void LoadGame()
    {
        print("loaded");
        PlayerData data = SaveSystem.LoadPlayerData();
        if (data != null)
        {
            //playerHealth = data.health;
            playerExperience = data.experience;
            //playerPosition = data.position;
        }
    }

}
