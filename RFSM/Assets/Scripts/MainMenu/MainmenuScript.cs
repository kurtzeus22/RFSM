using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuScript : MonoBehaviour
{
    public string SceneName;
    public GameObject creditsPanel;
    public GameObject settingsPanel;
    public GameObject exitPanel;

    public GameObject mainMenu;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void toCharacterSelect()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ExitPanelOn()
    {
        exitPanel.SetActive(true);
    }

    public void ExitPanelOff()
    {
        exitPanel.SetActive(false);
    }

    public void CreditsPanelOn()
    {
        mainMenu.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void CreditsPanelOff()
    {
        mainMenu.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void SettingsPanelOn()
    {
        mainMenu.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void SettingsPanelOff()
    {
        mainMenu.SetActive(true);
        settingsPanel.SetActive(false);   
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Exit");
    }
}
