using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRenderMode : MonoBehaviour
{
    //public RenderMode renderMode;
    //enum RenderModeStates { camera, overlay, world };
    //RenderModeStates m_RenderModeStates;

    Canvas m_Canvas;

    // Use this for initialization
    void Start()
    {
        
    }

    void Awake()
    {
        m_Canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStateCamera()
    {
        m_Canvas.renderMode = RenderMode.ScreenSpaceCamera;
        
    }

    public void ChangeStateOverlay()
    {
        m_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
    }
}
