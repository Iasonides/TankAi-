﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTank : StateMachineBehaviour
{
    GameObject tank;
    Animator anim;
    GameObject[] waypointList;
    GameObject chaseTank;
    NavMeshAgent agent;
    TankInfo tankInfo;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = tank.GetComponent<NavMeshAgent>();
        tankInfo = animator.gameObject.GetComponent<TankInfo>();
        tank = animator.gameObject;
        anim = animator;
        chaseTank = tankInfo.seeSomething;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         if(chaseTank != null)
        {
            tankInfo.tankTurret.LookAt(chaseTank.transform.position);
            agent.destination = chaseTank.transform.position;

            if (Vector3.Distance(chaseTank.transform.position, tank.transform.position) < tankInfo.metersToShoot)
            {
                animator.SetBool("Attack", true);
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Chase", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
