using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject myGameObject = GameObject.Find("Global Volume");
        if (!SceneInfo.effectEnabled)
        {
            
            if (myGameObject != null)
            {
                myGameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
