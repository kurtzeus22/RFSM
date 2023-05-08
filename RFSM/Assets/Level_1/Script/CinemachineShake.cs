using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    CinemachineImpulseSource impulse;
    public static bool isShaking; 

    // Start is called before the first frame update
    void Start()
    {
        isShaking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking == true)
        {
            impulse = transform.GetComponent<CinemachineImpulseSource>();
            
            Invoke("shake", 0f);
        }
    }

    void shake()
    {
        impulse.GenerateImpulse(1f);
    }
}
