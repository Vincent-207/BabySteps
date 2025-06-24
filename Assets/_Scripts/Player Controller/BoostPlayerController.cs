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
    KeyCode leftArmForward, leftArmBackward, rightArmForward, rightArmBackward;
    // Start is called before the first frame update
    void Start()
    {
        leftArmForward = (KeyCode) PlayerPrefs.GetInt("Left Arm Forward");
        leftArmBackward = (KeyCode) PlayerPrefs.GetInt("Left Arm Backward");
        rightArmForward = (KeyCode) PlayerPrefs.GetInt("Right Arm Forward");
        rightArmBackward = (KeyCode) PlayerPrefs.GetInt("Right Arm Backward");
    }

    // Update is called once per frame
    void Update()
    {
        HandleArmInput();
        HandleRoll();

    }

    void HandleArmInput()
    {
        if(Input.GetKey(leftArmForward))
        {
            leftArmRB.AddRelativeTorque(armTurnDir * armTurnPower, armForceMode);
        }
        else if(Input.GetKey(leftArmBackward))
        {
            leftArmRB.AddRelativeTorque(armTurnDir * -armTurnPower, armForceMode);
        }
        if(Input.GetKey(rightArmForward))
        {
            rightArmRB.AddRelativeTorque(armTurnDir * armTurnPower, armForceMode);
        }
        else if(Input.GetKey(rightArmBackward))
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