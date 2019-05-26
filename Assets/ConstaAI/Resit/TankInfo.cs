using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankInfo : MonoBehaviour
{
    public float speed;
    public Transform fireTransform;
    public float totalHealth;
    public Rigidbody bullet;
    public Transform tankTurret;
    public float powerOfBullet;
    public float fireBetweenTime = 1f;
    public GameObject seeSomething;
    public NavMeshAgent agent;
    public float currentHealth;
    private bool isDead = false;
    Animator anim;
    public float metersToShoot;


    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = speed;
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
            //anim.SetBool("chase", true);
        }
    }
}

