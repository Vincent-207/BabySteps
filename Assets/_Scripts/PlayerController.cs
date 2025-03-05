using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody leftArm, rightArm, leftLeg, rightLeg;
    [SerializeField]
    Vector3 turnDir;
    [SerializeField]
    float turnSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleIndividualInput(ForceMode.Force);
        if(Input.GetKey(KeyCode.T))
        {
            SpinLeftSide(ForceMode.Force);
        }
        if(Input.GetKey(KeyCode.Y))
        {
            SpinRightSide(ForceMode.Force);
        }
        if(Input.GetKey(KeyCode.U))
        {
            SpinAll(ForceMode.Force);
        }
    }

    void SpinLeftSide(ForceMode forceMode)
    {
        leftArm.AddRelativeTorque(turnDir * turnSpeed, forceMode);
        leftLeg.AddRelativeTorque(turnDir * turnSpeed, forceMode);
    }

    void SpinRightSide(ForceMode forceMode)
    {
        rightArm.AddRelativeTorque(turnDir * turnSpeed, forceMode);
        rightLeg.AddRelativeTorque(turnDir * turnSpeed, forceMode);
    }

    void SpinAll(ForceMode forceMode)
    {
        SpinLeftSide(forceMode);
        SpinRightSide(forceMode);
    }
    

    void HandleIndividualInput(ForceMode forceMode)
    {
        if(Input.GetKey(KeyCode.Q))
        {
            leftArm.AddRelativeTorque(turnDir * turnSpeed, forceMode);
        }
        if(Input.GetKey(KeyCode.A))
        {
            leftArm.AddRelativeTorque(turnDir * -turnSpeed, forceMode);
        }
        if(Input.GetKey(KeyCode.W))
        {
            rightArm.AddRelativeTorque(turnDir * turnSpeed, forceMode);
        }
        if(Input.GetKey(KeyCode.S))
        {
            rightArm.AddRelativeTorque(turnDir * -turnSpeed, forceMode);
        }
        if(Input.GetKey(KeyCode.E))
        {
            leftLeg.AddRelativeTorque(turnDir * turnSpeed, forceMode);
        }
        if(Input.GetKey(KeyCode.D))
        {
            leftLeg.AddRelativeTorque(turnDir * -turnSpeed, forceMode);
        }
        if(Input.GetKey(KeyCode.R))
        {
            rightLeg.AddRelativeTorque(turnDir * turnSpeed, forceMode);
        }
        if(Input.GetKey(KeyCode.F))
        {
            rightLeg.AddRelativeTorque(turnDir * -turnSpeed, forceMode);
        }
    }
}
