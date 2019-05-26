using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankInfo : MonoBehaviour
{
    public float speed;
    public Transform fireTransform;
    public float totalHealth;
    public Rigidbody shell;
    public Transform tankTurret;
    public float launchForce;
    public float fireBetweenTime = 1f;
    public GameObject seeSomething;
    private NavMeshAgent navMeshAgent;
    public float currentHealth;
    private bool isDead = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = totalHealth;
        isDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tank") 
        {
            seeSomething = other.gameObject;
            anim.SetBool("chase", true);
        }
    }
}

