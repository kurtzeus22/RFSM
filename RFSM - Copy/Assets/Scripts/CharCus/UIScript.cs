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
        SceneManager.LoadScene(backScene);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene); 
    }
}
