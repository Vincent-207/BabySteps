using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class MoveToState : State
{
    NavMeshAgent navAgent;
    Waypoint waypoint;
    Vector3 target;
    Vector3 targetPosition;
    BasicFSM stateMachine;
    ITargetFSM targetFSM;
    float distanceThreshold;
    
    public bool closeToWaypoint()
    {
        
        Vector3 toWaypoint = target - navAgent.transform.position;
        float distance = toWaypoint.magnitude;
        
        if(distance <= distanceThreshold + .1)
        {
            Debug.Log("Close to waypoint!");
            return true;
        }
        else{
            return false;
        }
    }

    private void SetTargetPos()
    {
        target = targetFSM.GetTarget();
        navAgent.SetDestination(target);
        targetPosition = target;
    }

    public MoveToState(NavMeshAgent navAgent, ITargetFSM targetFSM, float distanceThreshold = 1f)
    {
        //stateMachine = FSM;
        this.navAgent = navAgent;
        this.targetFSM = targetFSM;
        this.distanceThreshold = distanceThreshold;
        
        //transitions.Add(new Transition(closeToWaypoint, new WaitState(FSM)));
    }
    protected override void OnEnter()
    {
        navAgent.enabled = true;
        target = targetFSM.GetTarget();
        SetTargetPos();
        Debug.Log("Set Destination!");
        base.OnEnter();
    }

    protected override void OnUpdate()
    {
        
        base.OnUpdate();
    }
    protected override void OnExit()
    {
        navAgent.enabled = false;
        Debug.LogWarning("Got to point!");
        base.OnExit();
    }


}
