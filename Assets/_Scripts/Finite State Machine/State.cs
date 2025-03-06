using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;


public abstract class State 
{
    public enum StatePhase 
    {
        enter,
        update,
        exit,
        interrupted
    }
    StatePhase statePhase = StatePhase.enter;

    public List<Transition> transitions = new List<Transition>();
    State nextState;
    
    protected virtual void OnEnter()
    {
        statePhase = StatePhase.update;
    }

    protected virtual void OnUpdate()
    {
        for(int i = 0; i < transitions.Count; i++)
        {
            if(transitions[i].condition())
            {
                // If can transistion set nextSate to corresponding nextState. Set phase to exit. 
                nextState = transitions[i].nextState;
                statePhase = StatePhase.exit;

            }
        }
    }

    protected virtual void OnExit()
    {

    }

    public virtual void Interrupt()
    {
        statePhase = StatePhase.interrupted;
    }

    public virtual State Process()
    {
        if(statePhase == StatePhase.enter)
        {
            OnEnter();
        }
        else if(statePhase == StatePhase.update)
        {
            OnUpdate();
        }
        else if(statePhase == StatePhase.interrupted)
        {
            OnExit();
            Debug.LogWarning("What the flip dude. Don't interrupt me " + this);
            // Reset state phase for when we come back to this state.
            statePhase = StatePhase.enter;
        }
        else if(statePhase == StatePhase.exit)
        {
            OnExit();
            // Reset state phase for when we come back to this state.
            statePhase = StatePhase.enter;
            return nextState;
        }

        return this;
    }
}
