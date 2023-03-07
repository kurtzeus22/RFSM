using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelector : MonoBehaviour
{
    //public GameObject optionPrefab;

    public Transform prevCharacter;
    public Transform selectedCharacter;

    public Animation walk;

    private void Start()
    {
        
    }

    public void SelectCharacter()
    {
        foreach (Character c in GameManager.instance.characters)
        {
            GameManager.instance.SetCharacter(c);
            if (selectedCharacter != null)
            {
                prevCharacter = selectedCharacter;
            }
        } 
    }

    public void selectCardo()
    {
        //anim.Play("BasicMotions@Walk01 - Forwards");
        
        /*foreach (Character c in GameManager.instance.characters)
        {
            GameManager.instance.SetCharacter(c);
        }*/
    }
    public void selectChloe()
    {

        foreach (Character a in GameManager.instance.characters)
        {
            GameManager.instance.SetCharacter(a);
        }
    }
}
