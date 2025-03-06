using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    float waitTime;
    float startTime;

    public IdleState(float waitTime)
    {
        this.waitTime = waitTime;
    }
    protected override void OnEnter()
    {
        startTime = Time.time;
        base.OnEnter();
    }

    
}
