using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrollig : MonoBehaviour
{
    private NavMeshAgent agent;
    public float range;
    private Vector3 centrePoint;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        centrePoint = new Vector3(16.67f, 2.7f, -15.34f);
    }
    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            if(RandomPoint(centrePoint, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
    }
    bool RandomPoint(Vector3 center , float range , out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    //void Start()
    //{
    //    UpDateDetination();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Vector3.Distance(transform.position, target) < 1)
    //    {
    //        IterateWaypintsIndex();
    //        UpDateDetination();
    //    }

    //}
    //void UpDateDetination()
    //{
    //    target = waypoints[waypointIndex].position;
    //    agent.SetDestination(target);
    //}
    //void IterateWaypintsIndex()
    //{
    //    waypointIndex++;
    //    if(waypointIndex == waypoints.Length)
    //    {
    //        waypointIndex = 0;
    //    }
    //}
}
