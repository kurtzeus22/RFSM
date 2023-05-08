using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorParticle : MonoBehaviour
{
    public GameObject particles;
    Vector2 mousePos;

    void Start()
    {

    }


    void Update()
    {
        if(SceneInfo.effectEnabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(particles, mousePos, Quaternion.identity);
                particles.transform.position = mousePos;
            }
        }
        
    }
}
