using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicFSM : FiniteStateMachine
{
    Waypoint waypoint;
    Waypoint[] waypoints;
    int currentPoint = 0;

    public NavMeshAgent navAgent;
    public BasicFSM(NavMeshAgent navAgent, Waypoint[] points)
    {
        Debug.Log("Starting ctor!");
        this.navAgent = navAgent;
        waypoints = points;
        Debug.Log("Set Current State");
        currentState = new MoveToState(navAgent, waypoints[currentPoint]);
        
    }

    public Waypoint getCurrentWaypoint()
    {
        return waypoints[currentPoint];
    }

    public void incrementPoint()
    {
        currentPoint+= 1;
        if(currentPoint <= waypoints.Length)
        {
            currentPoint = 0;
        }

        currentState = new MoveToState(navAgent, waypoints[currentPoint]);

    }



    protected override void OnEnter()
    {
        Debug.Log("Basic FSM Entered!");
        base.OnEnter();
    }
}
