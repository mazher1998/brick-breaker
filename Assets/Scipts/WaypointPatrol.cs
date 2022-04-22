using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
   public NavMeshAgent navMeshAgent;
   public Transform[] waypoints;
   int m_CurrentWaypointIndex=0;
    void Start()
    { 
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        // Debug.Log("1");
         navMeshAgent.SetDestination(waypoints[0].position);
      
        // Debug.Log("2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("3");
          if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
          {
              Debug.Log("first"+m_CurrentWaypointIndex);
             Debug.Log("4");
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            Debug.Log("Sec"+m_CurrentWaypointIndex);
            navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
            Debug.Log("third"+m_CurrentWaypointIndex);
          }
    }
}
