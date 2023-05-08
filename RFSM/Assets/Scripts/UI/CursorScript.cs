using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Texture2D cursorTexture; // The texture of the custom cursor

    public Vector2 hotSpot = Vector2.zero; // The hotspot of the custom cursor

    //Cursor Inactivity
    public float inactivityTime = 10.0f;
    public GameObject[] hideObjects;
    [Header("Show Effect")]
    public GameObject[] effectObjects;

    private float timeSinceMove;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);

        timeSinceMove = 0.0f;
    }

    void Update()
    {
        if(SceneInfo.effectEnabled)
        {
            effectShow();
            if (Input.GetAxis("Mouse X") != 0.0f || Input.GetAxis("Mouse Y") != 0.0f)
            {
                timeSinceMove = 0.0f;
                ShowObjects();
            }
            else
            {
                timeSinceMove += Time.deltaTime;
                if (timeSinceMove >= inactivityTime)
                {
                    HideObjects();
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                timeSinceMove = 0.0f;
                ShowObjects();
            }
        }
        else
        {
            effectHide();
        }
        
    }

    void HideObjects()
    {
        Cursor.visible = false;
        foreach (GameObject obj in hideObjects)
        {
            obj.SetActive(false);
        }
    }

    void ShowObjects()
    {
        Cursor.visible = true;
        foreach (GameObject obj in hideObjects)
        {
            obj.SetActive(true);
        }
    }

    void effectShow()
    {
        foreach (GameObject effectObj in effectObjects)
        {
            effectObj.SetActive(true);
        }
    }

    void effectHide()
    {
        foreach (GameObject effectObj in effectObjects)
        {
            effectObj.SetActive(false);
        }
    }
}
