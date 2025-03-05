using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FiniteStateMachine : State
{
    protected State currentState;

    protected override void OnUpdate()
    {
        currentState = currentState.Process();
        base.OnUpdate();
    }

    protected override void OnExit()
    {
        currentState.Interrupt();

        base.OnExit();
    }
}
