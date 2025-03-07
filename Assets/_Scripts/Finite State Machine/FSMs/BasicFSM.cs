using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class BasicFSM : FiniteStateMachine, ITargetFSM
{
    Waypoint[] waypoints;
    public int currentPoint = 0;
    MoveToState moveState;
    WaitState waitState;
    [SerializeField]
    State CurrentState;

    public NavMeshAgent navAgent;
    public float abba = 5;
    public State myState;

    public BasicFSM(NavMeshAgent navAgent, Waypoint[] points)
    {
        waypoints = points;
        CurrentState = currentState = moveState = new MoveToState(navAgent, this);
        waitState = new WaitState(this);

        moveState.transitions.Add(new Transition(moveState.closeToWaypoint, waitState));
        waitState.transitions.Add(new Transition(waitState.isDoneWaiting, moveState));
    }



    public Waypoint getCurrentWaypoint()
    {
        return waypoints[currentPoint];
    }

    public void incrementPoint()
    {
        currentPoint+= 1;
        if(currentPoint >= waypoints.Length)
        {
            currentPoint = 0;
        }
    }

    public Vector3 GetTarget()
    {
        return getCurrentWaypoint().position;
    }


    protected override void OnEnter()
    {
        //Debug.Log("Basic FSM Entered!");
        base.OnEnter();
    }
}
