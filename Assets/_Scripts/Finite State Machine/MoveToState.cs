using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToState : State
{
    NavMeshAgent navAgent;
    Waypoint waypoint;
    
    bool closeToWaypoint()
    {
        if(navAgent.transform.position.x == waypoint.position.x && navAgent.transform.position.z == waypoint.position.z)
        {
            Debug.Log("Close to waypoint!");
            return true;
        }
        else{
            return false;
        }
    }

    public MoveToState(NavMeshAgent agent, Waypoint point)
    {
        navAgent = agent;
        waypoint = point;
        
        transitions.Add(new Transition(closeToWaypoint, new WaitState(point.waitTime)));
    }
    protected override void OnExit()
    {
        Debug.LogWarning("Go to point!");
        base.OnExit();
    }
    protected override void OnEnter()
    {
        base.OnEnter();
        navAgent.SetDestination(waypoint.position);
        Debug.Log("Set Destination!");
    }


}
