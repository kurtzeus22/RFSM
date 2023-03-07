using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // this is to reference tha player always
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
    void Start()
    {
        print("Game Start!");   
    }

}
