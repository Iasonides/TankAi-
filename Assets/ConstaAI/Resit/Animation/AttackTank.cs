using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackTank : StateMachineBehaviour
{
    GameObject tank;
    Animator anim;
    GameObject[] waypointList;
    GameObject chaseTank;
    NavMeshAgent agent;
    TankInfo tankInfo;

    int shootableLayer;
    float tillFire;
    float afterFire;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tank = animator.gameObject;
        waypointList = GameObject.FindGameObjectsWithTag("waypoint");
        tankInfo = animator.gameObject.GetComponent<TankInfo>();
        anim = animator;
        agent = tank.GetComponent<NavMeshAgent>();
        shootableLayer = LayerMask.GetMask("Shootable");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        afterFire += Time.deltaTime;

        if(afterFire >= tillFire)
        {
            Fire();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    void Fire()
    {
        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(tankInfo.fireTransform.transform.position, tankInfo.fireTransform.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shootableLayer))
        {
            Debug.DrawRay(tankInfo.fireTransform.transform.position, tankInfo.fireTransform.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("fireeee");
        }
    }
    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
