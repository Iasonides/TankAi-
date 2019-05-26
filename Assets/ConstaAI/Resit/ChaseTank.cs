using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTank : MonoBehaviour
{
    GameObject tank;
    Animation anim;
    GameObject[] waypoints;
    GameObject chaseTank;
    NavMeshAgent navMeshAgent;
    TankInfo tankInfo;

    // Start is called before the first frame update
    void Start()
    {
        tank = anim.gameObject;
        navMeshAgent = navMeshAgent.GetComponent<NavMeshAgent>();
        chaseTank = tankInfo.seeSomething;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
