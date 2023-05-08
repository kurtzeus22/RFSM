using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScript : MonoBehaviour
{

    public GameObject Splash;
    public GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toMenu()
    {
        SceneInfo.hasIntro = false;
        mainMenu.SetActive(true);
        Splash.SetActive(false);
    }
}
