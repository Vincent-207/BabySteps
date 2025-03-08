using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParentAI : MonoBehaviour
{
    [SerializeField]
    PlayerDetector parentDetection;
    ParentFSM parentFSM;
    public Waypoint[] waypoints;
    NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        parentDetection = GetComponent<PlayerDetector>();
        navAgent = GetComponentInChildren<NavMeshAgent>();
        if(waypoints.Length >= 0)
        {
            parentFSM = new ParentFSM(waypoints, navAgent, parentDetection);

        }
        else{
            Debug.LogWarning("Need to set waypoints, parent ai FSM not created");
        }
    }

    // Update is called once per frame
    void Update()
    {
        parentFSM.Process();
    }
}
