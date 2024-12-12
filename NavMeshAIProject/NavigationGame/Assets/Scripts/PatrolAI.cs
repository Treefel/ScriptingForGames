using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointsIndex;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[0].position);
        }
    }

    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            currentWaypointsIndex = (currentWaypointsIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypointsIndex].position);
        }
    }
}
