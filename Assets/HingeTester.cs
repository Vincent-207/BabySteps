using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeTester : MonoBehaviour
{
    [SerializeField]
    Rigidbody leftArmRB, rightArmRB, leftLegRB, rightLegRB;
    [SerializeField]
    Vector3 torqueDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            leftArmRB.AddRelativeTorque(torqueDir, ForceMode.Impulse);
            Debug.Log("Adding Torque left arm");
        }
        else if(Input.GetKey(KeyCode.F))
        {
            leftArmRB.AddRelativeTorque(-torqueDir, ForceMode.Impulse);
            Debug.Log("Adding reverse Torque left arm");
        }

        if(Input.GetKey(KeyCode.E))
        {
            
            Debug.Log("Adding Torque right arm");
            rightArmRB.AddRelativeTorque(torqueDir, ForceMode.Acceleration);
            
        }
        if(Input.GetKey(KeyCode.D))
        {
            rightArmRB.AddRelativeTorque(-torqueDir, ForceMode.Acceleration);
            Debug.Log("Adding  Torque right arm");
        }

        if(Input.GetKey(KeyCode.T))
        {
            
            Debug.Log("Adding Torque both arms");
            rightArmRB.AddRelativeTorque(torqueDir, ForceMode.Force);
            leftArmRB.AddRelativeTorque(torqueDir, ForceMode.Force);
            
        }

        if(Input.GetKey(KeyCode.T))
        {
            
            Debug.Log("Adding Torque both arms");
            leftLegRB.AddRelativeTorque(torqueDir, ForceMode.Force);
            rightLegRB.AddRelativeTorque(torqueDir, ForceMode.Force);
            
        }
    }

    void SpinLeft(Vector3 torqueVector, ForceMode forceMode)
    {
        leftArmRB.AddRelativeTorque(torqueVector, forceMode);
        leftLegRB.AddRelativeTorque(torqueVector, forceMode);
    }

    
}
