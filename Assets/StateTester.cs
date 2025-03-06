using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;

public class StateTester : MonoBehaviour
{
    public Waypoint[] waypoints;
    NavMeshAgent navAgent;
    [SerializeField]
    BasicFSM bFSM;

    public void Start()
    {
        navAgent = transform.GetComponent<NavMeshAgent>();
        Debug.Log("BSFM Set!");
        bFSM = new BasicFSM(navAgent, waypoints);
        
    }

    public void FixedUpdate()
    {
        bFSM.Process();
    }
}
