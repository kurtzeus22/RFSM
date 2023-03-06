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
        creditsPanel.SetActive(true);
    }

    public void CreditsPanelOff()
    {
        creditsPanel.SetActive(false);
    }

    public void SettingsPanelOn()
    {
        settingsPanel.SetActive(true);
    }

    public void SettingsPanelOff()
    {
        settingsPanel.SetActive(false);   
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Exit");
    }
}
