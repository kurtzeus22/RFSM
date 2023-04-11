using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Transform[] allwaypoint;
    public float rotationspeed = 0.5f, movementSpeed = 0.5f;
    public int currentTarget;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
        ChangeTarget();
    }

    void Movement(){
        transform.position = Vector3.MoveTowards(transform.position, allwaypoint[currentTarget].position, movementSpeed*Time.deltaTime);
    }

    void Rotate(){
        transform.rotation=Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(allwaypoint[currentTarget].position-transform.position),rotationspeed*Time.deltaTime);
    }

    void ChangeTarget(){
        if(transform.position==allwaypoint[currentTarget].position)
        {
            currentTarget++;
            currentTarget=currentTarget % allwaypoint.Length;
        }
    }
}
