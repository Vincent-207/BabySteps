using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundChecker : MonoBehaviour
{
    [SerializeField]
    PlayerJump playerJump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            playerJump.grounded = true;
        }      
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            playerJump.grounded = true;
        }      
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            playerJump.grounded = false;
        }
    }
}
