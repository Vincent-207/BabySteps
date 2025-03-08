using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseFSM : FiniteStateMachine, ITargetFSM
{
    Vector3 targetPos;
    PlayerDetector playerDetector;
    float recalcThreshould;
    NavMeshAgent navAgent;
    CatchState catchState;
    
    public ChaseFSM(Vector3 targetPos,PlayerDetector playerDetector, NavMeshAgent agent, float recalcThreshould = 1.0f)
    {
        navAgent = agent;
        this.targetPos = targetPos;
        this.playerDetector = playerDetector;
        this.recalcThreshould = recalcThreshould;
        catchState = new CatchState(GetTarget(), this, navAgent );
        currentState = catchState;
    }
    protected override void OnUpdate()
    {
        
        base.OnUpdate();
    }
    public Vector3 GetTarget()
    {
        return PlayerDetector.getLastSeen();
    }

    public override String ToString()
    {
        return "Chase State";

    }
}
