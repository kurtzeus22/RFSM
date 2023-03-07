using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnim : MonoBehaviour
{

    public Animator anim;

    public GameObject[] selectedText;
    // Start is called before the first frame update
    void Start()
    {
        //anim.SetTrigger("DSelected");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void CardoPlay()
    {
        //print("Cardo anim");
        anim.SetTrigger("DSelected");
        selectedText[0].SetActive(true);
        selectedText[1].SetActive(false);
    }
    public void ChloePlay()
    {
        //print("chloe Anim");
        //anim.SetBool("se", true);
        anim.SetTrigger("Selected");
        selectedText[0].SetActive(false);
        selectedText[1].SetActive(true);
        
    }
}
