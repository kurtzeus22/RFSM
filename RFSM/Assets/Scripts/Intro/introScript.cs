using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introScript : MonoBehaviour
{
    public string toScene;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void toMainmenu()
    {
        SceneManager.LoadScene(toScene);
    }
}
