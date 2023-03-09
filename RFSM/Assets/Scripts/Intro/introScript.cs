using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introScript : MonoBehaviour
{
    public string toScene;
    public GameObject Intro;
    public GameObject mainMenu;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DisableIntro()
    {
        mainMenu.SetActive(true);
        Intro.SetActive(false);
    }
    public void toMainmenu()
    {
        SceneManager.LoadScene(toScene);
    }
}
