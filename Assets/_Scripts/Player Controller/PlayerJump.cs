using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    
    [SerializeField]
    float jumpPower, jumpChargeTime, JumpCooldownTime, minJumpCharge;
    public bool grounded = false;

    [SerializeField]
    Rigidbody playerMainBody;
    float jumpChargeAmount, lastJumpTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Vector3.zero, playerMainBody.transform.forward * 10, Color.red, .1f);
        if(Input.GetKey(KeyCode.Space) && validJump())
        {
            jumpChargeAmount += Time.deltaTime ;
            jumpChargeAmount = Mathf.Clamp(jumpChargeAmount, 0, 1);
            Debug.Log("Jump Charge: " + jumpChargeAmount);
            
        }
        else if(Input.GetKeyUp(KeyCode.Space) && grounded)
        {
            Debug.Log("checking jump!");
            if(jumpChargeAmount >= minJumpCharge)
            {
                Debug.Log("Jumping!");  
                Vector3 jumpVector = (playerMainBody.transform.forward * jumpPower) * jumpChargeAmount;
                Debug.DrawRay(playerMainBody.transform.position, jumpVector, Color.red);
                playerMainBody.AddForce(jumpVector, ForceMode.Impulse);   
                lastJumpTime = Time.time;
            }
            
            jumpChargeAmount = 0;

        }
        
    }

    public float getJumpCharge()
    {
        return jumpChargeAmount;
    }

    bool validJump()
    {
        if( Time.time >= lastJumpTime + JumpCooldownTime)
        {
            if(grounded)
            {
                return true;

            }
        }

        return false;
    }
}
