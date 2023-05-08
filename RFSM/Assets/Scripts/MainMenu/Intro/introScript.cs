using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introScript : MonoBehaviour
{
    public GameObject Intro;
    public GameObject Splash;

    public GameObject IntroManager;

    public GameObject BGMusic;
    void Start()
    {
        BGMusic.SetActive(false);
    }

    void Update()
    {
        if(SceneInfo.hasIntro)
        {
            IntroManager.SetActive(true);
        } else
        {
            IntroManager.SetActive(false);
            BGMusic.SetActive(true);
        }
    }

    public void DisableIntro()
    {
        BGMusic.SetActive(true);
        Splash.SetActive(true);
        Intro.SetActive(false);
    }
    
}
