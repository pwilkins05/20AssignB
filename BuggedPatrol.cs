// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{
    public Transform player;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private int counter = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;									//bug here (should be false) - fixed DH

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 00)									//bug here
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    void OnTriggerStay(Collider other)
    {
        if ( other.gameObject.CompareTag("Player"))
        {
            agent.destination = player.position;
            counter = 1;
        }
    }

    void OnTriggerEnter(Collider other)                        		//bug here (should be onExit)
    {
        counter = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && counter == 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   

    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}