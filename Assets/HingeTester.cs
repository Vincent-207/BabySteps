using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HingeTester : MonoBehaviour
{
    [SerializeField]
    Rigidbody leftArmRB, rightArmRB, leftLegRB, rightLegRB;
    [SerializeField]
    Vector3 torqueDir;
    [SerializeField]
    float torqueAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        HandleLeftArm();
        HandleRightArm();
        HandleLeftLeg();
        HandleRightLeg();

        if(Input.GetKey(KeyCode.T))
        {
            SpinLeftSide(torqueDir, torqueAmount, ForceMode.Force);
        }
        
        if(Input.GetKey(KeyCode.Y))
        {
            SpinRightSide(torqueDir, torqueAmount, ForceMode.Force);
        }

        if(Input.GetKey(KeyCode.U))
        {
            turnLeftFront(torqueDir, torqueAmount, ForceMode.Force);
        }
        else if(Input.GetKey(KeyCode.I))
        {
            turnRightFront(torqueDir, torqueAmount, ForceMode.Force);
        }
        
        
    }

    void HandleLeftArm()
    {
        // Spin front left arm based on input
        if(Input.GetKey(KeyCode.Q))
        {
            leftArmRB.AddRelativeTorque(torqueDir, ForceMode.Impulse);
            Debug.Log("Adding Torque left arm");
        }
        else if(Input.GetKey(KeyCode.A))
        {
            leftArmRB.AddRelativeTorque(-torqueDir, ForceMode.Impulse);
            Debug.Log("Adding reverse Torque left arm");
        }
    }

    void HandleRightArm()
    {
         // Sping Front right arm
        if(Input.GetKey(KeyCode.W))
        {
            
            Debug.Log("Adding Torque right arm");
            rightArmRB.AddRelativeTorque(torqueDir, ForceMode.Acceleration);
            
        }
        if(Input.GetKey(KeyCode.S))
        {
            rightArmRB.AddRelativeTorque(-torqueDir, ForceMode.Acceleration);
            Debug.Log("Adding  Torque right arm");
        }
    }

    void HandleLeftLeg()
    {
         // Sping Front right arm
        if(Input.GetKey(KeyCode.E))
        {
            
            Debug.Log("Adding Torque left leg");
            leftLegRB.AddRelativeTorque(torqueDir, ForceMode.Acceleration);
            
        }
        if(Input.GetKey(KeyCode.D))
        {
            leftLegRB.AddRelativeTorque(-torqueDir, ForceMode.Acceleration);
            Debug.Log("Adding  Torque left leg");
        }
    }
    
    void HandleRightLeg()
    {
         // Sping Front right arm
        if(Input.GetKey(KeyCode.R))
        {
            
            Debug.Log("Adding Torque right leg");
            rightLegRB.AddRelativeTorque(torqueDir, ForceMode.Acceleration);
            
        }
        if(Input.GetKey(KeyCode.F))
        {
            rightLegRB.AddRelativeTorque(-torqueDir, ForceMode.Acceleration);
            Debug.Log("Adding  Torque right leg");
        }
    }

    void SpinLeftSide(Vector3 torqueVector, float torquePower, ForceMode forceMode)
    {
        leftArmRB.AddRelativeTorque(torqueVector * torquePower, forceMode);
        leftLegRB.AddRelativeTorque(torqueVector * torquePower, forceMode);
    }

    void SpinRightSide(Vector3 torqueVector, float torquePower, ForceMode forceMode)
    {
        rightArmRB.AddRelativeTorque(torqueVector * torquePower, forceMode);
        rightLegRB.AddRelativeTorque(torqueVector * torquePower, forceMode);
    }

    void turnLeftFront(Vector3 torqueVector, float torquePower, ForceMode forceMode)
    {
        rightArmRB.AddRelativeTorque(torqueVector * torquePower, forceMode);
        leftArmRB.AddRelativeTorque(torqueVector * -torquePower, forceMode);
        
    }

    void turnRightFront(Vector3 torqueVector, float torquePower, ForceMode forceMode)
    {
        rightArmRB.AddRelativeTorque(torqueVector * -torquePower, forceMode);
        leftArmRB.AddRelativeTorque(torqueVector * torquePower, forceMode);
    }

    void SpinFront(Vector3 torqueVector, float torquePower, ForceMode forceMode)
    {
        rightArmRB.AddRelativeTorque(torqueVector * torquePower, forceMode);
        leftArmRB.AddRelativeTorque(torqueVector * torquePower, forceMode);
    }

    void SpinBack(Vector3 torqueVector, float torquePower, ForceMode forceMode)
    {
        rightLegRB.AddRelativeTorque(torqueVector * torquePower, forceMode);
        leftLegRB.AddRelativeTorque(torqueVector * torquePower, forceMode);
    }

    void fullSpin(Vector3 torqueVector, float torquePower, ForceMode forceMode)
    {
        SpinFront(torqueVector, torquePower, forceMode);
        SpinBack(torqueVector, torquePower, forceMode);

    }

    
}
