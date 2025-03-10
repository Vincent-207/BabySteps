using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatchState : State
{
    // Follow player
    float recalcThreshould;
    Vector3 lastSeenPlayerPos;
    NavMeshAgent navAgent;
    ITargetFSM chaseFSM;

    public CatchState(Vector3 lastSeen, ITargetFSM chaseFSM, NavMeshAgent agent, float recalc = 0.1f)
    {
        lastSeenPlayerPos = lastSeen;
        recalcThreshould = recalc;
        navAgent = agent;
        this.chaseFSM = chaseFSM;
    }

    protected override void OnEnter()
    {
        navAgent.enabled = true;
        navAgent.SetDestination(lastSeenPlayerPos);
        base.OnEnter();
    }

    protected override void OnUpdate()
    {
        Debug.DrawLine(navAgent.transform.position, lastSeenPlayerPos, Color.green);
        Vector3 accurateLastSeen = chaseFSM.GetTarget();
        float distance = (lastSeenPlayerPos - accurateLastSeen).magnitude;
        if(distance >= recalcThreshould)
        {
            Debug.DrawLine(navAgent.transform.position, accurateLastSeen, Color.blue);
            lastSeenPlayerPos = accurateLastSeen;
            navAgent.SetDestination(lastSeenPlayerPos);
        }
        
        base.OnUpdate();
    }
    protected override void OnExit()
    {
        navAgent.enabled = false;
        base.OnExit();
    }
    
}
