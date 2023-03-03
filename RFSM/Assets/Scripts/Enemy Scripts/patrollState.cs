using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class patrollState : StateMachineBehaviour
{
    public float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent eAgent;

    //variables for chasing
    public float lookRadius = 5f;
    Transform player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        eAgent = animator.GetComponent<NavMeshAgent>();
        eAgent.speed = 1.5f;// agent speed
        timer = 0;
        GameObject go = GameObject.FindGameObjectWithTag("Waypoints");
        foreach(Transform t in go.transform)
        {
            wayPoints.Add(t);
        }
        eAgent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (eAgent.remainingDistance <= eAgent.stoppingDistance)
        {
            eAgent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }

        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("isPatrolling", false);
        }
        float distance = Vector3.Distance(player.position, animator.transform.position);
        
        if (distance < lookRadius)
        {
            animator.SetBool("isChasing", true);
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        eAgent.SetDestination(eAgent.transform.position);
       

      
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
