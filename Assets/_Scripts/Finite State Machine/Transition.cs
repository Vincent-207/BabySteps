using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition 
{
    public Func<bool> condition;
    public State nextState;

    public Transition(Func<bool> condition, State nextState)
    {
        this.condition = condition;
        this.nextState = nextState;
    }
}
