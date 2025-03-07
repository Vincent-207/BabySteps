using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField]
    IMeshGen coneGen;
    Mesh viewCone;
    MeshFilter meshFilter;
    MeshCollider viewCol;
    

    // Chase variables
    static float lastDetectedPlayerTime;
    public static float playerChaseTime = 5;
    public static Vector3 lastSeenPlayerPos = new Vector3();
    static bool canSeePlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        coneGen = GetComponent<IMeshGen>();
        viewCone = coneGen.GetMesh();
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = viewCone;
        viewCol = GetComponent<MeshCollider>();
        viewCol.sharedMesh = viewCone;

    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by : " + other.name);
        if(other.CompareTag("Player"))
        {
            detectedPlayer(other);
            canSeePlayer = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            detectedPlayer(other);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            detectedPlayer(other);
            canSeePlayer = false;
        }
    }
    private void detectedPlayer(Collider playerCol)
    {
        lastSeenPlayerPos = playerCol.transform.position;
        lastDetectedPlayerTime = Time.time;
        Debug.Log("Saw player!");
    }

    public static bool huntingPlayer()
    {
        if(Time.time < lastDetectedPlayerTime + playerChaseTime)
        {
            return true;
        }
        return false;
    }

    public static bool searchingPlayer()
    {
        if(huntingPlayer() && canSeePlayer == false)
        {
            return true;
        }
        return false;
    }

    public static Vector3 getLastSeen()
    {
        return lastSeenPlayerPos;
    }

    
}
