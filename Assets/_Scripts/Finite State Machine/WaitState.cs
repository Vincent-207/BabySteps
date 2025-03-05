using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : State
{
    float waitTime;
    float startTime;
    public WaitState(float waitTime)
    {
        
        startTime = Time.time;
        this.waitTime = waitTime;
        //transitions.Add(new Transition(isDoneWaiting, new MoveToState(FSM.navAgent, FSM)));
    }

    
    bool isDoneWaiting()
    {
        if(Time.time >= waitTime + startTime)
        {
            
            return true;
        }
        return false;
    }

    


}
