using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class WaitState : State
{
    float waitTime;
    float startTime;
    BasicFSM stateMachine;
    public WaitState(BasicFSM FSM)
    {
        stateMachine = FSM;
        startTime = Time.time;
        this.waitTime = FSM.getCurrentWaypoint().waitTime;
        //Debug.Log("WaitTime of : " + waitTime);
        //Debug.Break();
        //transitions.Add(new Transition(isDoneWaiting, new MoveToState(FSM)));
    }

    
    public bool isDoneWaiting()
    {

        if(Time.time >= waitTime + startTime)
        {
            
            return true;
        }
        return false;
    }

    protected override void OnEnter()
    {
        waitTime = stateMachine.getCurrentWaypoint().waitTime;
        startTime = Time.time;
        Debug.Log("Starting wait of " + waitTime);
        base.OnEnter();
    }

    protected override void OnExit()
    {
        Debug.Log("Ending Wait!");
        stateMachine.incrementPoint();
        base.OnExit();
    }




}
