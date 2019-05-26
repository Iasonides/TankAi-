using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ConstantinosPatrol : StateMachineBehaviour
{
    GameObject tank;
    Animator anim;
    GameObject[] waypointList;
    NavMeshAgent navMeshAgent;
    TankInfo tankInfo;

    private int count = 0;
    int shootableLayer;

    private void Start()
    {
        
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypointList = GameObject.FindGameObjectsWithTag("waypoint") ;
        tankInfo = animator.gameObject.GetComponent<TankInfo>();
        tank = animator.gameObject;
        anim = animator;
        navMeshAgent = tank.GetComponent<NavMeshAgent>();
        shootableLayer = LayerMask.GetMask("Shootable");
       

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMeshAgent.destination = waypointList[count].transform.position;
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            count = (count + 1) % waypointList.Length;

        }
        Look();
    }

    private void Look()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(tankInfo.fireTransform.position, tankInfo.fireTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shootableLayer))
        {
            Debug.DrawRay(tankInfo.fireTransform.position, tankInfo.fireTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            anim.SetBool("chase", true);
        }
    }

}
