using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlayerController : MonoBehaviour
{
    public Rigidbody babyRB, leftArmRB, rightArmRB;
    public Vector3 armTurnDir, rollDir;
    public GameObject leftArm, rightArm;
    public float armTurnPower, rollPower;
    public ForceMode armForceMode, bodyForceMode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleArmInput();
        HandleRoll();

    }

    void HandleArmInput()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            leftArmRB.AddRelativeTorque(armTurnDir * armTurnPower, armForceMode);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            leftArmRB.AddRelativeTorque(armTurnDir * -armTurnPower, armForceMode);
        }
        if(Input.GetKey(KeyCode.W))
        {
            rightArmRB.AddRelativeTorque(armTurnDir * armTurnPower, armForceMode);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            rightArmRB.AddRelativeTorque(armTurnDir * -armTurnPower, armForceMode);
        }
    }

    void HandleRoll()
    {
        if(Input.GetKey(KeyCode.O))
        {
            babyRB.AddRelativeTorque(rollDir * rollPower, bodyForceMode);
        }
        else if(Input.GetKey(KeyCode.P))
        {
            babyRB.AddRelativeTorque(rollDir * -rollPower, bodyForceMode);

        }
    }

    
}