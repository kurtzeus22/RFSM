using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class FatBabyScript : MonoBehaviour
{

    public float speed;

    //patrol
    public Transform[] points;
    private int i;

    bool run = true;

    void Start()
    {

    }


    void Update()
    {
        if (run)
        {
            if (Vector3.Distance(transform.position, points[i].position) < 0.02f)
            {
                i++;
                
            }
            
            if (i >= points.Length)
            {
                run = false;
                //idle

            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
            }
        }


    }


}
