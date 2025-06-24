using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField]
    Vector3 eyePos;
    [SerializeField]
    LayerMask viewBlockingLayers;
    IMeshGen coneGen;
    Mesh viewCone;
    MeshFilter meshFilter;
    MeshCollider viewCol;
    
    [SerializeField]
    AudioSource calm, action;


    // Chase variables
    static float lastDetectedPlayerTime = -5;
    public static float playerChaseTime = 5;
    public static Vector3 lastSeenPlayerPos = new Vector3();
    static bool canSeePlayer = false;
    //int abba = 2;
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
    void Update()
    {
        if(Time.time >= lastDetectedPlayerTime + playerChaseTime)
        {
            calm.enabled = true;
            action.enabled = false;
        }   
        else
        {
            calm.enabled = false;
            action.enabled = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by : " + other.name);
        if(other.CompareTag("Player") && isPlayerViewable(other))
        {
            detectedPlayer(other);
            canSeePlayer = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && isPlayerViewable(other))
        {
            detectedPlayer(other);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && isPlayerViewable(other))
        {
            detectedPlayer(other);
            canSeePlayer = false;
        }
    }
    private void detectedPlayer(Collider playerCol)
    {
        lastSeenPlayerPos = playerCol.transform.position;
        lastDetectedPlayerTime = Time.time;
        //Debug.Log("Saw player!");
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

    private bool isPlayerViewable(Collider other)
    {
        bool isViewBlocked = Physics.Linecast(transform.position + eyePos, other.transform.position, viewBlockingLayers);
        Debug.DrawLine(transform.position + eyePos, other.transform.position, Color.yellow, 50f);
        if(isViewBlocked)
        {
            canSeePlayer = false;
            Debug.Log("Blocking Object");
        }
        else
        {
            canSeePlayer = true;
        }

        return !isViewBlocked;
    }


    
}
