using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public string backScene;
    public string gameScene;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Back()
    {
        print("main menu");
        SceneManager.LoadScene(backScene);
    }

    public void StartGame()
    {
        print("scene");
        SceneManager.LoadScene(gameScene); 
    }
}
