using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeModel : MonoBehaviour
{
    public GameObject[] heads;
    private int currentHead;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < heads.Length; i++)
        {
            if (i == currentHead)
            {
                heads[i].SetActive(true);
            }
            else
            {
                heads[i].SetActive(false);
            }
        }
    }

    public void SwitchHeads()
    {
        if(currentHead== heads.Length - 1)
        {
            currentHead = 0;
        } else
        {
            currentHead++;
        }
    }
}
