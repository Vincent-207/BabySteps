using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParentFSM : FiniteStateMachine
{
    ChaseFSM chaseFSM;
    BasicFSM patrolFSM;
    PlayerDetector playerDetector;
    NavMeshAgent navAgent;

    public ParentFSM(Waypoint[] waypoints, NavMeshAgent agent, PlayerDetector detector)
    {
        navAgent = agent;
        playerDetector = detector;
        currentState = patrolFSM = new BasicFSM(agent, waypoints);
        chaseFSM = new ChaseFSM(agent.transform.position, playerDetector, agent);

        patrolFSM.transitions.Add(new Transition(PlayerDetector.huntingPlayer, chaseFSM));
        chaseFSM.transitions.Add(new Transition(endChase, patrolFSM));

    }

    bool endChase()
    {
        return !PlayerDetector.huntingPlayer();
    }

}
