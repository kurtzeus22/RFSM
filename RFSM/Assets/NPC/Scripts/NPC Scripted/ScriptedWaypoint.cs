using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedWaypoint : MonoBehaviour
{
    public Transform[] allwaypoint;
    public float rotationspeed = 0.5f, movementSpeed = 0.5f;
    public int currentTarget;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CallOut()
    {
        Movement();
        Rotate();
        ChangeTarget();
    }

    public void Movement(){
        transform.position = Vector3.MoveTowards(transform.position, allwaypoint[currentTarget].position, movementSpeed*Time.deltaTime);
    }

    public void Rotate(){
        transform.rotation=Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(allwaypoint[currentTarget].position-transform.position),rotationspeed*Time.deltaTime);
    }

    public void ChangeTarget(){
        if(transform.position==allwaypoint[currentTarget].position)
        {
            currentTarget++;
            currentTarget=currentTarget % allwaypoint.Length;
        }
    }
}
